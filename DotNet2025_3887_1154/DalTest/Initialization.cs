using DO;
using DalApi;
using Dal;

namespace DalTest;

public static class Initialization
{
    //private static IDal? s_dal = new DalList();
    private static IDal? s_dal;
    public static void Initialize()
    {
        //s_dal = dal;
        s_dal = DalApi.Factory.Get;
        createClient();
        createProduct();
        createSale();
    }
    private static void createClient()
    {
        s_dal.Client.Create(new Client(1, "hadasa", "meromey sade 9", "0504104901"));
        s_dal.Client.Create(new Client(2, "sari", "netivot sade 25", "0504158914"));
        s_dal.Client.Create(new Client(3, "aaa", " modiienililt", "0548423310"));

    }
    private static void createProduct()
    {
        s_dal.Products.Create(new Product(1, "pot", categoryies.kitchen, 90.8, 3));
        s_dal.Products.Create(new Product(2, "shelf", categoryies.bedroom, 100, 10));
    }
    private static void createSale()
    {
        s_dal.Sale.Create(new Sale(1, 1, 20, 3, false, DateTime.Now, DateTime.Now));
        s_dal.Sale.Create(new Sale(2, 2, 10, 6, true, DateTime.Now, DateTime.Now));
    }

}



