
namespace Dal;
using DO;
using DalApi;
using System.Reflection;
using Tools;

internal class ImplementationSale : ISale
{
    public int Create(Sale item)
    {
        Sale Sale = DataSource.Sales.FirstOrDefault(c => c.saleId == item.saleId);
        if (Sale != null)
            throw new DalIdIsExistsException("מבצע כבר קיים ואי אפשר להוסיפו");
        string projecName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        string massege = "התווסף בהצלחה!";
        LogManager.writingToLog(projecName, funcName, $"{item.saleId} {massege}");
        DataSource.Sales.Add(item);
        return item.saleId;
    }
    public Sale? Read(Func<Sale, bool> filter)
    {
        return DataSource.Sales.Where(f => filter(f)).FirstOrDefault();
    }

    public Sale? Read(int id)
    {
        Sale Sale = DataSource.Sales.FirstOrDefault(c => c.saleId == id);
        if (Sale != null)
        {
            string projecName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            string funcName = MethodBase.GetCurrentMethod().Name;
            string massege = "in func read";
            LogManager.writingToLog(projecName, funcName, $"{Sale.saleId} {massege}");
            Console.WriteLine(Sale.ToString());
            Console.WriteLine(Sale.saleId);
            return Sale;
        }
        throw new DalIdNotExistsException("!מזהה לא קיים");
    }

    
    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        if(filter == null)
        {
            return DataSource.Sales;
        }
        return DataSource.Sales.Where(f => filter(f)).ToList();
            
    }

    public void Update(Sale item)
    {
        Delete(item.saleId);
        DataSource.Sales.Add(item);

    }
    public void Delete(int id)
    {
        Sale saleFind = Read(id);
        if (saleFind != null)
        {
            DataSource.Sales.Remove(saleFind);
        }
        else
            throw new DalIdNotExistsException("!מזהה לא קיים");
    }
}
