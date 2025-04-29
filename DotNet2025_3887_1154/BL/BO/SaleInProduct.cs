using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SaleInProduct
    {
        public int seleId { get; set; }
        public int? amountRequiredToRecevieTheOffer { get; set; }
        public double totalPriceOnSale { get; set; }
        public bool whoIsThePremotionFor { get; set; } //האם המבמע מיועד לכל הלקוחות?
        public override string ToString() => this.ToStringProperty();

    }
}
