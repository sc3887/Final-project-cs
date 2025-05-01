//using DalApi;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DO;
//using System.Xml.Serialization;


//namespace Dal;

//internal class ImplementationSale:ISale
//{
//    static string file_path = "../xml/sales";
//    static XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
//    public int Create(Sale sale)
//    {
//        try
//        {
//            if (!File.Exists(file_path))
//            {
//                using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write))
//                {
//                    serializer.Serialize(fs, new List<Sale>());
//                }
//            }
//            List<Sale> sales;
//            using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//            {
//                sales = (List<Sale>)serializer.Deserialize(fs) ?? new List<Sale>();
//            }
//            if (sales.Any(s => s.saleId == sale.saleId))
//            {
//                throw new InvalidOperationException($"Sale with ID {sale.saleId} already exists.");
//            }
//            sales.Add(sale);
//            using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write))
//            {
//                serializer.Serialize(fs, sales);
//            }
//            return sale.saleId;
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while creating the sale.", ex);
//        }
//    }
//    public Sale? Read(int id)
//    {
//        try
//        {
//            if (File.Exists(file_path))
//            {
//                List<Sale> sales;
//                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//                {
//                    sales = (List<Sale>)serializer.Deserialize(fs) ?? new List<Sale>();
//                }
//                return sales.FirstOrDefault(s => s.saleId == id);
//            }
//            else
//            {
//                throw new FileNotFoundException($"File {file_path} not found.");
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while reading the sale.", ex);
//        }
//    }
//    public Sale? Read(Func<Sale, bool>? filter = null)
//    {
//        try
//        {
//            if (File.Exists(file_path))
//            {
//                List<Sale> sales;
//                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//                {
//                    sales = (List<Sale>)serializer.Deserialize(fs) ?? new List<Sale>();
//                }
//                return sales.FirstOrDefault(filter);
//            }
//            else
//            {
//                throw new FileNotFoundException($"File {file_path} not found.");
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while reading the sale with filter.", ex);
//        }
//    }
//    public List<Sale>? ReadAll(Func<Sale, bool>? filter = null)
//    {
//        try
//        {
//            if (File.Exists(file_path))
//            {
//                List<Sale> sales;
//                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//                {
//                    sales = (List<Sale>)serializer.Deserialize(fs) ?? new List<Sale>();
//                }
//                if (filter != null)
//                {
//                    return sales.Where(filter).ToList();
//                }
//                return sales;
//            }
//            else
//            {
//                throw new FileNotFoundException($"File {file_path} not found.");
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while reading all sales.", ex);
//        }
//    }
//    public void Update(Sale sale)
//    {
//        try
//        {
//            if (File.Exists(file_path))
//            {
//                List<Sale> sales;
//                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//                {
//                    sales = (List<Sale>)serializer.Deserialize(fs) ?? new List<Sale>();
//                }
//                Sale? existingSale = sales.FirstOrDefault(s => s.saleId == sale.saleId);
//                if (existingSale != null)
//                {
//                    sales.Remove(existingSale);
//                    sales.Add(sale);
//                    using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write))
//                    {
//                        serializer.Serialize(fs, sales);
//                    }
//                }
//                else
//                {
//                    throw new InvalidOperationException($"Sale with ID {sale.saleId} does not exist.");
//                }
//            }
//            else
//            {
//                throw new FileNotFoundException($"File {file_path} not found.");
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while updating the sale.", ex);
//        }
//    }
//    public void Delete(int id)
//    {
//        try
//        {
//            if (File.Exists(file_path))
//            {
//                List<Sale> sales;
//                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//                {
//                    sales = (List<Sale>)serializer.Deserialize(fs) ?? new List<Sale>();
//                }
//                Sale? existingSale = sales.FirstOrDefault(s => s.saleId == id);
//                if (existingSale != null)
//                {
//                    sales.Remove(existingSale);
//                    using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write))
//                    {
//                        serializer.Serialize(fs, sales);
//                    }
//                }
//                else
//                {
//                    throw new InvalidOperationException($"Sale with ID {id} does not exist.");
//                }
//            }
//            else
//            {
//                throw new FileNotFoundException($"File {file_path} not found.");
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while deleting the sale.", ex);
//        }
//    }

//}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DalApi;
using DO;
using Tools;
using System.Reflection;
using System.Xml.Serialization;


namespace Dal;

internal class ImplementationSale : ISale
{
    static string file_path = "../xml/sales.xml";
    static XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));


    private const string SALE = "Sale";
    private const string SALE_ID = "saleId";
    private const string PRODUCT_ID = "idOfProduct";
    private const string QUANTITY_FOR_SALE = "amountRequiredToRecevieTheOffer";
    private const string PRICE_IN_SALE = "totalPriceOnSale";
    private const string IS_FOR_EVERYONE = "whoIsThePremotionFor";
    private const string START_DATE_FOR_SALE = "dateStartSale";
    private const string END_DATE_FOR_SALE = "dateFinishSale";

    public int Create(Sale item)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Entering the function to create a sale");

            if (!File.Exists(file_path))
            {
                new XElement("ArrayOfSale").Save(file_path);
            }

            XElement saleXml = XElement.Load(file_path);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            item = item with { saleId = Config.nextSaleId };
            saleXml.Add(new XElement(SALE,
                new XElement(SALE_ID, item.saleId),
                new XElement(PRODUCT_ID, item.idOfProduct),
                new XElement(QUANTITY_FOR_SALE, item.amountRequiredToRecevieTheOffer),
                new XElement(PRICE_IN_SALE, item.totalPriceOnSale),
                new XElement(IS_FOR_EVERYONE, item.whoIsThePremotionFor),
                new XElement(START_DATE_FOR_SALE, item.dateStartSale),
                new XElement(END_DATE_FOR_SALE, item.dateFinishSale)));
            saleXml.Save(file_path);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to create a sale");
            LogManager.space = LogManager.space.Substring(0, LogManager.space.Length - 1);
            return item.saleId;
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to create sale: {ex.Message}");
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Entering the function to delete a sale");

            XElement saleXml = XElement.Load(file_path);

            XElement sale = saleXml.Elements(SALE).FirstOrDefault(s => (int)s.Element(SALE_ID) == id);
            if (sale != null)
            {
                sale.Remove();
                saleXml.Save(file_path);
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to delete a sale");
            }
            else
            {
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed to delete sale: id does not exist");
                throw new DO.DalIdNotExistsException("id not exist");
            }

            LogManager.space = LogManager.space.Substring(0, LogManager.space.Length - 1);
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to delete sale: {ex.Message}");
            throw;
        }
    }

    public Sale? Read(int id)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Entering the function to read a sale");

            XElement saleXml = XElement.Load(file_path);

            XElement saleFound = saleXml.Elements(SALE).FirstOrDefault(s => (int)s.Element(SALE_ID) == id);
            if (saleFound != null)
            {
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read a sale");
                return new Sale(
                    (int)saleFound.Element(SALE_ID),
                    (int)saleFound.Element(PRODUCT_ID),
                    (int)saleFound.Element(QUANTITY_FOR_SALE),
                    (int)saleFound.Element(PRICE_IN_SALE),
                    (bool)saleFound.Element(IS_FOR_EVERYONE),
                    (DateTime)saleFound.Element(START_DATE_FOR_SALE),
                    (DateTime)saleFound.Element(END_DATE_FOR_SALE));
            }
            else
            {
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed to read sale: id does not exist");
                throw new DO.DalIdNotExistsException("id not exist");
            }
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to read sale: {ex.Message}");
            throw;
        }
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Entering the function to read a sale with filter");

            XElement saleXml = XElement.Load(file_path);

            List<Sale> sales = saleXml.Elements(SALE).Select(s => new Sale(
                (int)s.Element(SALE_ID),
                (int)s.Element(PRODUCT_ID),
                (int)s.Element(QUANTITY_FOR_SALE),
                (int)s.Element(PRICE_IN_SALE),
                (bool)s.Element(IS_FOR_EVERYONE),
                (DateTime)s.Element(START_DATE_FOR_SALE),
                (DateTime)s.Element(END_DATE_FOR_SALE))).ToList();

            Sale? foundSale = sales.FirstOrDefault(filter);
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read a sale with filter");
            return foundSale;
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to read sale with filter: {ex.Message}");
            throw;
        }
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Entering the function to read all sales");

            XElement saleXml = XElement.Load(file_path);

            List<Sale> sales = saleXml.Elements(SALE).Select(s => new Sale(
                (int)s.Element(SALE_ID),
                (int)s.Element(PRODUCT_ID),
                (int)s.Element(QUANTITY_FOR_SALE),
                (int)s.Element(PRICE_IN_SALE),
                (bool)s.Element(IS_FOR_EVERYONE),
                (DateTime)s.Element(START_DATE_FOR_SALE),
                (DateTime)s.Element(END_DATE_FOR_SALE))).ToList();

            if (filter != null)
            {
                var filteredSales = sales.Where(filter).ToList();
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read all sales with filter");
                return filteredSales;
            }

            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read all sales");
            return sales;
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to read all sales: {ex.Message}");
            throw;
        }
    }

    public void Update(Sale item)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Entering the function to update a sale");

            XElement saleXml = XElement.Load(file_path);

            XElement sale = saleXml.Elements(SALE).FirstOrDefault(s => (int)s.Element(SALE_ID) == item.saleId);
            if (sale != null)
            {
                sale.SetElementValue(PRODUCT_ID, item.idOfProduct);
                sale.SetElementValue(QUANTITY_FOR_SALE, item.amountRequiredToRecevieTheOffer);
                sale.SetElementValue(PRICE_IN_SALE, item.totalPriceOnSale);
                sale.SetElementValue(IS_FOR_EVERYONE, item.whoIsThePremotionFor);
                sale.SetElementValue(START_DATE_FOR_SALE, item.dateStartSale);
                sale.SetElementValue(END_DATE_FOR_SALE, item.dateFinishSale);
                saleXml.Save(file_path);

                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to update a sale");
            }
            else
            {
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed to update sale: id does not exist");
                throw new DO.DalIdNotExistsException("id not exist");
            }
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to update sale: {ex.Message}");
            throw;
        }
    }
}