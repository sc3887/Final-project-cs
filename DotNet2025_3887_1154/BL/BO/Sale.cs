using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Sale
{
 public int saleId { get; set; }
 public int idOfProduct { get; set; }
 public int? amountRequiredToRecevieTheOffer { get; set; }//כמות נדרשת לקבלת המבצע
 public double? totalPriceOnSale { get; set; } //מחיר כולל במבצע
 public bool? whoIsThePremotionFor { get; set; }//האם המבצע ניועד לכלל הלקוחות או ללקוחות מועדון
 public DateTime? dateStartSale { get; set; }
 public DateTime? dateFinishSale { get; set; }
 public override string ToString() => this.ToStringProperty();

}
