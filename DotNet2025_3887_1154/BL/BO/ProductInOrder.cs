using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int productInOrderId { get; set; } //מזהה מוצר
        public string? productInOrderName { get; set;} //שם מוצר
        public double? productInOrderBasePrice { get; set;} //מחיר בסיס למוצר
        public int? quintityInOrder { get; set; } //כמות בהזמנה
        public List<SaleInProduct>? listSales { get; set;} // רשימת מבצעים למוצר זה
        public double finalPriceForProduct { get; set;} //מחיר סופי למוצר
        public override string ToString() => this.ToStringProperty();


    }
}
