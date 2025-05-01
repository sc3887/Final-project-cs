
using DalApi;
using DalTest;
using DO;
using Dal;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using Tools;
using System.Reflection;

public class Program
{
    private static IDal s_dal = DalApi.Factory.Get;

    //פונקציה לבחירת סוג הישות ליצירה
    public static void PrintsTheObjectsSelections() 
    {
        Console.WriteLine("please select:\n client press 1\n product press 2\n sale press 3\n exit press 0");
        String s = Console.ReadLine();
        int choise = int.Parse(s);
        createObject( choise); 
    }
    //פונקציה שקרואת לפונקציה שמציגה את האפשרויות לבחירת אוביקט ובודקת את הבחירה ושולחת את הבקשה
    public static void createObject(int choise)
    {

        if (choise != 0)
        {
            switch (choise)
            {
                case 1:
                    //client
                    Icrud<Client> clientReference = s_dal.Client;
                    selectFromCRUD("client" , clientReference);
                    break;
                case 2:
                    //product
                    Icrud<Product> productReference = s_dal.Products;
                    selectFromCRUD("product" , productReference);
                    break;
                case 3:
                    //sale
                    Icrud<Sale> saleReference = s_dal.Sale;
                    selectFromCRUD("sale", saleReference);
                    break;
                default:  
                    Console.WriteLine("error choise, please select again");
                    break;
            }
            PrintsTheObjectsSelections();
            
        }
        Console.WriteLine("the program finish!!!!");


    }
    public static void selectFromCRUD<T>(String obj, Icrud<T> icrud)
    {
        Console.WriteLine("please selecet:\n create press 1 \n read press 2\n readAll press 3\n update press 4 \n delete press 5");
        String s = Console.ReadLine();
        int choise = int.Parse(s);
        switch (choise) 
        {
            case 1:
                //Create
                switch (obj)
                {
                    case "client":
                        Console.WriteLine("please enter: clientId, clientName, clientAddress, clientPhone");
                        string clientId = Console.ReadLine();
                        string clientName = Console.ReadLine();
                        string clientAddress = Console.ReadLine();
                        string clientPhone = Console.ReadLine();
                        s_dal.Client.Create(new Client(int.Parse(clientId), clientName, clientAddress, clientPhone));
                        PrintsTheObjectsSelections();
                        break;
                    case "product":
                        Console.WriteLine("please enter: productId, productName");
                        string productId = Console.ReadLine();
                        string productName = Console.ReadLine();
                        s_dal.Products.Create(new Product(int.Parse(productId), productName, categoryies.bathroom,20,20));
                        PrintsTheObjectsSelections();
                        break;
                    case "sale":
                        s_dal.Sale.Create(new Sale(5, 54, 5, 5, true, DateTime.MinValue, DateTime.MinValue));
                        PrintsTheObjectsSelections();
                        break;
                  
                }
                break;
            case 2:
                //Read
                Console.WriteLine("insert id");
                int _id = int.Parse(Console.ReadLine());
                icrud.Read(_id);
                PrintsTheObjectsSelections();
                break;  
            case 3:
                //ReadAll
                icrud.ReadAll();
                PrintsTheObjectsSelections();
                break;
            case 4:
                //Update
                switch (obj)
                {
                    case "client":
                        s_dal.Client.Update(new Client(1, "aaa", "bbb", "99999"));
                        PrintsTheObjectsSelections();
                        break;
                    case "product":
                        s_dal.Products.Update(new Product(1, "GFD", categoryies.bathroom, 20, 20));
                        PrintsTheObjectsSelections();
                        break;
                    case "sale":
                        s_dal.Sale.Update(new Sale(5, 54, 5, 5, true, DateTime.MinValue, DateTime.MinValue));
                        PrintsTheObjectsSelections();
                        break;
                }
                break;  
            case 5:
                //Delete
                Console.WriteLine("insert id");
                int id = int.Parse(Console.ReadLine());
                icrud.Delete(id);
                PrintsTheObjectsSelections();
                break;
            default:
                {
                    string projecName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
                    string funcName = MethodBase.GetCurrentMethod().Name;
                    string massege = "there is'not this option in CRUD";
                    LogManager.writingToLog(projecName, funcName, $"{massege}");
                    throw new DalOptionNotExistsException("there is'not this option in CRUD");
                }              
        }
    }

    public static void Main(string[] args)
    {

        //Initialization.Initialize();
        try
        {
            PrintsTheObjectsSelections();          
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
