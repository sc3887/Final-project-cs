
namespace DO;


public record Product
    (
       int productId,
       string? productName,
       categoryies? category,
       double? productPrice,
       int? quantityInStock

    )
{
    public Product():this(0,"", categoryies.homeDesigh,0,0)//בנאי ריק
    {
       
    }
}