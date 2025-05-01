using DalApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalXml : IDal
    {
        public static readonly DalXml instance = new DalXml();
        public static DalXml Instance
        {
            get
            {
                return instance;
            }
        }
        private DalXml()
        {

        }
        public IClient Client => new ImplementationClient();
        public IProducts Products => new ImplementationProduct();
        public ISale Sale => new ImplementationSale();

    }
}    