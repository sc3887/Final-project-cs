using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tools;

namespace Dal;

[Serializable]
internal class ImplementationClient :IClient
{
    static string file_path = "../xml/clients.xml";
    static XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));
    public int Create(Client item)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to create a customer");

            List<Client> clients = new List<Client>();
            // אם הקובץ קיים, טוען את הלקוחות הקיימים
            if (File.Exists(file_path))
            {
                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.ReadWrite))
                {
                    clients = (List<Client>)serializer.Deserialize(fs);
                }
            }
            Client findCustomer = clients.FirstOrDefault(c => c.clientId == item.clientId);
            if (findCustomer != null)
            {
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed to create customer: id already exists");
                throw new DO.DalIdIsExistsException("id already exists");
            }
            // הוספת הלקוח החדש לרשימה
            clients.Add(item);

            // שומר את הלקוחות לקובץ XML
            using (FileStream fs = new FileStream(file_path, FileMode.Create))
            {
                serializer.Serialize(fs, clients);
            }
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to create a customer");
            return item.clientId;
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to create customer: {ex.Message}");
            throw;
        }
    }

    public Client? Read(int id)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to read a customer");

            if (File.Exists(file_path))
            {
                List<Client> clients;
                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                {
                    clients = (List<Client>)serializer.Deserialize(fs) ?? new List<Client>();
                }
                Client client = clients.FirstOrDefault(c => c.clientId == id);
                if (client == null)
                {
                    LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed to read customer: id not exists");
                    throw new InvalidOperationException($"Client with ID {id} does not exist.");
                }
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read a customer");
                return client;
            }
            throw new KeyNotFoundException($"Client with ID {id} not found.");
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to read customer: {ex.Message}");
            throw;
        }
    }

    public Client? Read(Func<Client, bool>? filter = null)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to read a customer with filter");
            if (File.Exists(file_path))
            {
                List<Client> clients;
                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                {
                    clients = (List<Client>)serializer.Deserialize(fs) ?? new List<Client>();
                }
                if (filter != null)
                {
                    return clients.FirstOrDefault(filter);
                }
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read a customer with filter");
                return clients.FirstOrDefault();
            }
            return null;
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to read customer with filter: {ex.Message}");
            throw;
        }
    }

    public List<Client>? ReadAll(Func<Client, bool>? filter = null)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to create a customer");

            if (File.Exists(file_path))
            {
                List<Client> clients;
                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                {
                    clients = (List<Client>)serializer.Deserialize(fs);
                }

                // אם יש פילטר, החזיר רק את הלקוחות שעונים עליו
                if (filter != null)
                {
                    LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read all customers with filter");
                    return clients.Where(filter).ToList();
                }

                // אם אין פילטר, החזיר את כל הלקוחות
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read all customers");
                return clients;
            }
            throw new KeyNotFoundException($"No clients found.");
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to read all customers: {ex.Message}");
            throw;
        }
    }


    public void Delete(int clientId)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to delete a customer");
            
            List<Client> clients;
            using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
            {
                clients = (List<Client>)serializer.Deserialize(fs) ?? new List<Client>();
            }
            Client clientToDelete = clients.FirstOrDefault(c => c.clientId == clientId);
            if (clientToDelete == null)
            {
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed to delete customer: id not exists");
                throw new InvalidOperationException($"Client with ID {clientId} does not exist.");
            }
            clients.Remove(clientToDelete);
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to delete a customer");
            using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, clients);
            }
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to delete customer: {ex.Message}");
            throw;
        }
    }
    public void Update(Client client)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to update a customer");

            Delete(client.clientId);
            Create(client);
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to update a customer");

        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to update customer: {ex.Message}");
            throw;
        }

    }



}
