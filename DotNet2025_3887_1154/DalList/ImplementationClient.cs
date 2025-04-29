
namespace Dal;
using DO;
using DalApi;
using System.Collections.Generic;
using System.Reflection;
using Tools;
using System;

internal class ImplementationClient : IClient
{

    //CRUD - מימוש פונקציות ה
    public int Create(Client item) 
    {
        Client client = DataSource.Clients.FirstOrDefault(c => c.clientId == item.clientId);
        if (client != null)
            throw new DalIdIsExistsException("הלקוח כבר קיים ואי אפשר להוסיפו");  
        DataSource.Clients.Add(item);
        string projecName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        string massege = "נוצר בהצלחה!";
        LogManager.writingToLog(projecName, funcName, $"{item.clientName} {massege}" );
        Console.WriteLine($"{item.clientName} נוסף בהצלחה!");
        return item.clientId;
    }
    public Client? Read(Func<Client, bool> filter)
    {
        return DataSource.Clients.Where(f => filter(f)).FirstOrDefault();   
    }

    public Client? Read(int id)
    {
        Client client = DataSource.Clients.FirstOrDefault(c => c.clientId == id);
        if (client != null)
        {
            string projecName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            string funcName = MethodBase.GetCurrentMethod().Name;
            string massege = "in func read";
            LogManager.writingToLog(projecName, funcName, $"{client.clientName} {massege}");
            Console.WriteLine(client.ToString());
            return client;
        }  
        throw new DalIdNotExistsException("!מזהה לא קיים");
    }
    public List<Client?> ReadAll(Func<Client, bool>? filter = null)
    {
        if(filter == null)
        {
            string projecName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            string funcName = MethodBase.GetCurrentMethod().Name;
            string massege = "in func readAll";
            LogManager.writingToLog(projecName, funcName, $"{massege}");
            Console.WriteLine(DataSource.Clients);
            return DataSource.Clients;
        }
        return DataSource.Clients.Where(f => filter(f)).ToList();
        
         
    }

    public void Update(Client item)
    {
        string projecName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        string massege = "עודכן";
        LogManager.writingToLog(projecName, funcName, $"{item.clientName} {massege}");
        Delete(item.clientId);  
        DataSource.Clients.Add(item);  
           
    }
    public void Delete(int id)
    {
        Client clientFind = Read(id);
        if (clientFind != null)
        {
            string projecName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            string funcName = MethodBase.GetCurrentMethod().Name;
            string massege = "נמחק";
            LogManager.writingToLog(projecName, funcName, $"{massege}");
            DataSource.Clients.Remove(clientFind);
        }
        else
            throw new DalIdNotExistsException("!מזהה לא קיים");
    }
}
