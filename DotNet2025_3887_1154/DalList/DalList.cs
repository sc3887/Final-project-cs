//using DalApi;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dal
//{
//    internal sealed class DalList : IDal
//    {
//        public IClient Client => new ImplementationClient();
//        public IProducts Products => new ImplementationProduct();
//        public ISale Sale => new ImplementationSale();
//        public static readonly DalList instance = new DalList();
//        public static DalList getInstance
//        {
//            get { return instance; }
//        }
//        private DalList()
//        {

//        }
//    }
//}

using DalApi;

namespace Dal;

internal sealed class DalList : IDal
{
    public static readonly DalList instance = new DalList();
    public static DalList Instance
    {
        get
        {
            return instance;
        }
    }
    private DalList()
    {

    }
    public IClient Client => new ImplementationClient();
    public IProducts Products => new ImplementationProduct();
    public ISale Sale => new ImplementationSale();

}

