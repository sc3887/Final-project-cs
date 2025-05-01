//using DalApi;
//using DO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Serialization;

//namespace Dal;

//internal class ImplementationProduct:IProducts
//{
//    static string file_path = "../xml/products";
//    XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

//    public int Create(Product product)
//    {
//        try
//        {
//            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
//            if (!File.Exists(file_path))
//            {
//                using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write))
//                {
//                    serializer.Serialize(fs, new List<Product>());
//                }
//            }
//            List<Product> products;
//            using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//            {
//                products = (List<Product>)serializer.Deserialize(fs);
//            }
//            if (products.Any(p => p.productId == product.productId))
//            {
//                throw new InvalidOperationException($"Product with ID {product.productId} already exists.");
//            }
//            products.Add(product);
//            using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write))
//            {
//                serializer.Serialize(fs, products);
//            }
//            return product.productId;
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while creating the product.", ex);
//        }
//    }
//    public Product? Read(int id)
//    {
//        try
//        {
//            if (File.Exists(file_path))
//            {
//                List<Product> products;
//                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//                {
//                    products = (List<Product>)serializer.Deserialize(fs) ?? new List<Product>();
//                }
//                return products.FirstOrDefault(p => p.productId == id);
//            }
//            else
//            {
//                throw new FileNotFoundException("The file does not exist.");
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while reading the product.", ex);
//        }
//    }
//    public Product? Read(Func<Product, bool>? filter = null)
//    {
//        try
//        {
//            if (File.Exists(file_path))
//            {
//                List<Product> products;
//                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//                {
//                    products = (List<Product>)serializer.Deserialize(fs) ?? new List<Product>();
//                }

//                if (filter != null)
//                {
//                    return products.FirstOrDefault(filter);
//                }

//                throw new ArgumentException("Filter cannot be null when searching for a specific product.");
//            }

//            throw new FileNotFoundException("The products file does not exist.");
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while reading the product with a filter.", ex);
//        }
//    }
//    public List<Product>? ReadAll(Func<Product, bool>? filter = null)
//    {
//        try
//        {
//            if (File.Exists(file_path))
//            {
//                List<Product> products;
//                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//                {
//                    products = (List<Product>)serializer.Deserialize(fs) ?? new List<Product>();
//                }
//                if (filter != null)
//                {
//                    return products.Where(filter).ToList();
//                }
//                return products;
//            }
//            throw new FileNotFoundException("The products file does not exist.");
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while reading all products.", ex);
//        }
//    }

//    public void Update(Product product)
//    {
//        try
//        {
//            if (File.Exists(file_path))
//            {
//                List<Product> products;
//                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//                {
//                    products = (List<Product>)serializer.Deserialize(fs) ?? new List<Product>();
//                }
//                Product? existingProduct = products.FirstOrDefault(p => p.productId == product.productId);
//                if (existingProduct != null)
//                {
//                    products.Remove(existingProduct);
//                    products.Add(product);
//                    using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write))
//                    {
//                        serializer.Serialize(fs, products);
//                    }
//                }
//                else
//                {
//                    throw new InvalidOperationException($"Product with ID {product.productId} does not exist.");
//                }
//            }
//            else
//            {
//                throw new FileNotFoundException("The file does not exist.");
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while updating the product.", ex);
//        }
//    }
//    public void Delete(int id)
//    {
//        try
//        {
//            if (File.Exists(file_path))
//            {
//                List<Product> products;
//                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
//                {
//                    products = (List<Product>)serializer.Deserialize(fs) ?? new List<Product>();
//                }
//                Product? productToDelete = products.FirstOrDefault(p => p.productId == id);
//                if (productToDelete != null)
//                {
//                    products.Remove(productToDelete);
//                    using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write))
//                    {
//                        serializer.Serialize(fs, products);
//                    }
//                }
//                else
//                {
//                    throw new InvalidOperationException($"Product with ID {id} does not exist.");
//                }
//            }
//            else
//            {
//                throw new FileNotFoundException("The file does not exist.");
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new ApplicationException("An error occurred while deleting the product.", ex);
//        }
//    }

//}

using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Tools;

namespace Dal;

internal class ImplementationProduct : IProducts
{
    static string file_path = "../xml/products.xml";
    static XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

    public int Create(Product product)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to create a product");

            List<Product> products = new List<Product>();
            if (File.Exists(file_path))
            {
                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.ReadWrite))
                {
                    products = (List<Product>)serializer.Deserialize(fs) ?? new List<Product>();
                }
            }

            if (products.Any(p => p.productId == product.productId))
            {
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed to create product: id already exists");
                throw new InvalidOperationException($"Product with ID {product.productId} already exists.");
            }

            products.Add(product);
            using (FileStream fs = new FileStream(file_path, FileMode.Create))
            {
                serializer.Serialize(fs, products);
            }

            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to create a product");
            return product.productId;
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to create product: {ex.Message}");
            throw;
        }
    }

    public Product? Read(int id)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to read a product");

            if (File.Exists(file_path))
            {
                List<Product> products;
                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                {
                    products = (List<Product>)serializer.Deserialize(fs) ?? new List<Product>();
                }

                Product? product = products.FirstOrDefault(p => p.productId == id);
                if (product == null)
                {
                    LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed to read product: id not exists");
                    throw new InvalidOperationException($"Product with ID {id} does not exist.");
                }

                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read a product");
                return product;
            }

            throw new FileNotFoundException("The products file does not exist.");
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to read product: {ex.Message}");
            throw;
        }
    }

    public Product? Read(Func<Product, bool>? filter = null)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to read a product with filter");

            if (File.Exists(file_path))
            {
                List<Product> products;
                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                {
                    products = (List<Product>)serializer.Deserialize(fs) ?? new List<Product>();
                }

                if (filter != null)
                {
                    return products.FirstOrDefault(filter);
                }

                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read a product with filter");
                return products.FirstOrDefault();
            }

            return null;
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to read product with filter: {ex.Message}");
            throw;
        }
    }

    public List<Product>? ReadAll(Func<Product, bool>? filter = null)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to read all products");

            if (File.Exists(file_path))
            {
                List<Product> products;
                using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                {
                    products = (List<Product>)serializer.Deserialize(fs) ?? new List<Product>();
                }

                if (filter != null)
                {
                    LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read all products with filter");
                    return products.Where(filter).ToList();
                }

                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to read all products");
                return products;
            }

            throw new FileNotFoundException("The products file does not exist.");
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to read all products: {ex.Message}");
            throw;
        }
    }

    public void Update(Product product)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to update a product");

            Delete(product.productId);
            Create(product);

            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to update a product");
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to update product: {ex.Message}");
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            LogManager.space += "\t";
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Enters the function to delete a product");

            List<Product> products;
            using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
            {
                products = (List<Product>)serializer.Deserialize(fs) ?? new List<Product>();
            }

            Product? productToDelete = products.FirstOrDefault(p => p.productId == id);
            if (productToDelete == null)
            {
                LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed to delete product: id not exists");
                throw new InvalidOperationException($"Product with ID {id} does not exist.");
            }

            products.Remove(productToDelete);
            using (FileStream fs = new FileStream(file_path, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, products);
            }

            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Successfully exited the function to delete a product");
        }
        catch (Exception ex)
        {
            LogManager.writingToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed to delete product: {ex.Message}");
            throw;
        }
    }
}
