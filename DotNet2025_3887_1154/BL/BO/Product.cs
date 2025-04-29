using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
       public int productId { get; init; }
       public string? productName { get; set; }
       public categoryies? category { get; set; }
       public double? productPrice { get; set; }
       public int? quantityInStock { get; set; }
       public override string ToString() => this.ToStringProperty();

    }
}
