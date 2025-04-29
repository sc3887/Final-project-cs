using DO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public static class Tools
{
    public static string ToStringProperty<T>(this T t)
    {
        string str = "";
        Type Ttype = t.GetType();
        PropertyInfo[] info = Ttype.GetProperties();
        foreach (PropertyInfo item in info)
        {
            if (typeof(IEnumerable).IsAssignableFrom(item.PropertyType) && item.PropertyType != typeof(string))
            {
                IEnumerable collection = item.GetValue(t) as IEnumerable;
                foreach (var x in collection)
                {
                    str += x.ToStringProperty();
                }
            }
            else
                str += string.Format("{0,-15}:{1,-15}\n", item.Name, item.GetValue(t, null));

        }
        return str;
    }

    public static BO.Client ConvertToBOClient(this DO.Client client)=> new() { clientId = client.clientId, clientAddress = client.clientAddress, clientName = client.clientName, clientPhone = client.clientPhone};
    public static DO.Client ConvertToDOClient(this BO.Client client) => new() { clientId = client.clientId, clientAddress = client.clientAddress, clientName = client.clientName, clientPhone = client.clientPhone };

    public static BO.Product ConvertToBOProduct(this DO.Product product) => new() { productId = product.productId, productName = product.productName, category = (BO.categoryies)product.category, quantityInStock = product.quantityInStock };
    public static DO.Product ConvertToDOProduct(this BO.Product product) => new() { productId = product.productId, productName = product.productName, category = (DO.categoryies)product.category, quantityInStock = product.quantityInStock };

    public static BO.Sale ConvertToBOSale(this DO.Sale sale) => new() { saleId = sale.saleId, idOfProduct = sale.idOfProduct, amountRequiredToRecevieTheOffer = sale.amountRequiredToRecevieTheOffer , totalPriceOnSale  = sale.totalPriceOnSale, whoIsThePremotionFor  = sale.whoIsThePremotionFor, dateStartSale = sale.dateStartSale, dateFinishSale = sale.dateFinishSale };

    public static DO.Sale ConvertToDOSale(this BO.Sale sale) => new() { saleId = sale.saleId, idOfProduct = sale.idOfProduct, amountRequiredToRecevieTheOffer = sale.amountRequiredToRecevieTheOffer, totalPriceOnSale = sale.totalPriceOnSale, whoIsThePremotionFor = sale.whoIsThePremotionFor, dateStartSale = sale.dateStartSale, dateFinishSale = sale.dateFinishSale };

    public static BO.SaleInProduct ConvertToBOSaleInProduct(this DO.Sale sale) => new() {seleId = sale.saleId, amountRequiredToRecevieTheOffer = sale.amountRequiredToRecevieTheOffer, totalPriceOnSale = sale.totalPriceOnSale ?? 0, whoIsThePremotionFor = sale.whoIsThePremotionFor  ?? false};

    public static BO.ProductInOrder ConvertToBOProductInOrder(this DO.Product product) => new() { productInOrderId  = product.productId , productInOrderName = product.productName, productInOrderBasePrice = product.productPrice, quintityInOrder = product.quantityInStock };

}
