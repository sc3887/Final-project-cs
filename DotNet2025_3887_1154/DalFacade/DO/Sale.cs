
namespace DO;

public record Sale
    (
     int saleId,
     int idOfProduct,
     int? amountRequiredToRecevieTheOffer,//כמות נדרשת לקבלת המבצע
     double? totalPriceOnSale, //מחיר כולל במבצע
     bool?  whoIsThePremotionFor,//האם המבצע ניועד לכלל הלקוחות או ללקוחות מועדון
     DateTime? dateStartSale,
     DateTime? dateFinishSale
    )
{
    public Sale() : this(0, 0, 0, 0, false,null,null)//בנאי ריק
    {

    }




}
