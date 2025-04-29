using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Sale
    (
     int saleId,
     int idOfProduct,
     int? amountRequiredToRecevieTheOffer = null,//כמות נדרשת לקבלת המבצע
     double? totalPriceOnSale = null, //מחיר כולל במבצע
     bool? whoIsThePremotionFor = null,//האם המבצע ניועד לכלל הלקוחות או ללקוחות מועדון
     DateTime? dateStartSale = null,
     DateTime? dateFinishSale = null
    )
    {
        public Sale() : this(0, 0, 0, 0, false, null, null)//בנאי ריק
        {

        }
    }

}

