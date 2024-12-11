using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalList : IDal
    {
        public IClient Client => new ImplementationClient();
        public IProducts Products => new ImplementationProduct();
        public ISale Sale => new ImplementationSale();
    }
}
