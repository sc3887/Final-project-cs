
namespace Dal;
using DO;
using DalApi;
using System.Collections.Generic;
using System.Reflection;
using Tools;



internal class ImplementationProduct : IProducts
{
    public int Create(Product item)
    {
        Product Product = DataSource.Products.FirstOrDefault(c => c.productId == item.productId);
        if (Product != null)
            throw new DalIdIsExistsException("מוצר כבר קיים ואי אפשר להוסיפו");
        string projecName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        string massege = "נוצר בהצלחה!";
        LogManager.writingToLog(projecName, funcName, $"{item.productName} {massege}");
        DataSource.Products.Add(item);
        return item.productId;
    }
    public Product? Read(Func<Product, bool> filter)
    {
        return DataSource.Products.Where(f => filter(f)).FirstOrDefault();
    }

    public Product? Read(int id)
    {
        Product Product = DataSource.Products.FirstOrDefault(c => c.productId == id);
        if (Product != null)
        {
            string projecName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            string funcName = MethodBase.GetCurrentMethod().Name;
            string massege = "in func read";
            LogManager.writingToLog(projecName, funcName, $"{Product.productName} {massege}");
            Console.WriteLine(Product.ToString());
            Console.WriteLine(Product.productName);
            return Product;
        }
        throw new DalIdNotExistsException("!מזהה לא קיים");

    }
   
    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        if(filter == null)
        {
            return DataSource.Products;
        }
        return DataSource.Products.Where(f => filter(f)).ToList();
        
    }

    public void Update(Product item)
    {
        Delete(item.productId);
        DataSource.Products.Add(item);

    }
    public void Delete(int id)
    {
        Product productFind = Read(id);
        if (productFind != null)
        {
            DataSource.Products.Remove(productFind);
        }
        throw new DalIdNotExistsException("!מזהה לא קיים");
    }
}
