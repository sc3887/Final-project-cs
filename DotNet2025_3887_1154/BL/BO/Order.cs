using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public bool isPreferredOrOccasionalClient { get; set; }//האם לקוח מועדף או מזדמן?
        public List<ProductInOrder> listProducts { get; set; }
        public double finalPrice { get; set; }
        public override string ToString() => this.ToStringProperty();
        public Order(bool isPreferredOrOccasionalClient)
        {
            this.isPreferredOrOccasionalClient = isPreferredOrOccasionalClient;
        }

   
    }
}
