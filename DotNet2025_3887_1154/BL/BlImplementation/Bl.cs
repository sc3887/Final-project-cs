using BlApi;
using BlImplemementation;
//using BlImplemementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class Bl: IBl
    {
        public IClient Client => new ImplementionClient();
        public IProduct Product => new ImplemetationProduct();
        public IOrder Order => new ImplementationOrder();
        public ISale Sale => new ImplementationSale();

    }
}
