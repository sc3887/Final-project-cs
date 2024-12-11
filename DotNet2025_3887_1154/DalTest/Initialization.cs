using DO;
using DalApi;
using Dal;

namespace DalTest;

public static class Initialization
{
    private static IDal? s_dal = new DalList();
    //private static IClient? c_dalClient;
    //private static IProducts? p_dalProduct;
    //private static ISale? s_dalSale;
    public static void Initialize(IDal dal)
    {
        //c_dalClient = c;    
        //p_dalProduct = P;   
        //s_dalSale = s;  
        s_dal = dal;
        createClient();
        createProduct();
        createSale();
    }
    private static void createClient()
    {
        s_dal.Client.Create(new Client(1, "hadasa", "meromey sade 9", "0504104901"));
        s_dal.Client.Create(new Client(2, "sari", "netivot sade 25", "0504158914"));
        s_dal.Client.Create(new Client(3, "aaa", " modiienililt", "0548423310"));

        //Client c1 = new Client(1,"hadasa","meromey sade 9","0504104901");
        //c_dalClient.Create(c1);
        //Client c2 = new Client(2, "sari", "netivot sade 25", "0504158914");
        //c_dalClient.Create(c2);
        //Client c3 = new Client(3, "aaa", " modiienililt", "0548423310");
        //c_dalClient.Create(c3);

    }
    private static void createProduct()
    {
        s_dal.Products.Create(new Product(1, "pot", categoryies.kitchen, 90.8, 3));
        s_dal.Products.Create(new Product(2, "shelf", categoryies.bedroom, 100, 10));
        //Product p1 = new Product(1,"pot" ,categoryies.kitchen,90.8,3);
        //Product p2 = new Product(2, "shelf", categoryies.bedroom, 100, 10);
        //p_dalProduct.Create(p1);
        //p_dalProduct.Create(p2);
    }
    private static void createSale()
    {
        s_dal.Sale.Create(new Sale(1, 1, 20, 3, false, DateTime.Now, DateTime.Now));
        s_dal.Sale.Create(new Sale(2, 2, 10, 6, true, DateTime.Now, DateTime.Now));
        //Sale s1 = new Sale(1,1,20,3,false,DateTime.Now,DateTime.Now);
        //Sale s2 = new Sale(2, 2, 10, 6, true, DateTime.Now, DateTime.Now);
        //s_dalSale.Create(s1);
        //s_dalSale.Create(s2);
    }

}



