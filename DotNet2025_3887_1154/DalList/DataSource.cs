
using DO;

namespace Dal;

static internal class DataSource
{
    static internal class Config
    {
        //ערך התחלתי למספר הרץ
        internal const int startingValueClient = 0;
        internal const int startingValueProduct = 0;
        internal const int startingValueSale = 0;
        //ערך התחלתי של השדה הקבוע הקודם
        private static int prevValueClient = startingValueClient;
        private static int prevValueProduct = startingValueProduct;
        private static int prevValueSale = startingValueSale;
        //מאפיין עם get שמחזיר את ערך השדה הסטטי ומקדם אותו אוטומטית
        static int getValueSale() { return prevValueSale++; }
        static int getValueCliente() { return prevValueClient++; }
        static int getValueProduct() { return prevValueProduct++; }

    }
    static internal List<Client>? Clients = new List<Client>();
    static internal List<Product>? Products = new List<Product>();
    static internal List<Sale>? Sales = new List<Sale>();

}






