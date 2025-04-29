using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Tools;


namespace BlImplemementation;

internal class ImplementationOrder : BlApi.IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int quantity)
    {
        try
        {
            DO.Product product = _dal.Products.Read(productId);

            BO.ProductInOrder myProduct = order.listProducts?.FirstOrDefault(p => p.productInOrderId == productId);
            if (myProduct != null)
            {
                if (myProduct.quintityInOrder + quantity <= product.quantityInStock)
                {
                    myProduct.quintityInOrder += quantity;
                }
                else
                    throw new BO.BLnotEnoughInStock("אין מספיק במלאי");
            }
            else
            {
                if (product.quantityInStock - quantity >= 0)
                {
                    myProduct = product.ConvertToBOProductInOrder();
                    myProduct.quintityInOrder = quantity;
                    if (order.listProducts == null)
                        order.listProducts = new List<BO.ProductInOrder>();
                    order.listProducts.Add(myProduct);

                }
                else
                {
                    throw new BO.BLnotEnoughInStock("אין מספיק במלאי");
                }
            }
            SearchSaleForProduct(myProduct, order.isPreferredOrOccasionalClient);
            CalcTotalPriceForProduct(myProduct);
            CalcTotalPrice(order);
            return myProduct.listSales;

        }
        catch (DO.DalIdNotExistsException e)
        {
            throw new BO.BLIdNotExistsException("ההזמנה אינו קיימת", e);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void CalcTotalPrice(BO.Order order)
    {
        try
        {
            order.finalPrice = order.listProducts.Sum(p => p.finalPriceForProduct);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder)
    {
        try
        {
            int count = productInOrder.quintityInOrder ?? 0;
            List<BO.SaleInProduct> salesInProduct = new List<BO.SaleInProduct>();
            foreach (BO.SaleInProduct saleInProduct in productInOrder.listSales)
            {
                if (count == 0)
                    break;
                if (count >= saleInProduct.amountRequiredToRecevieTheOffer)
                {
                    int times = count / saleInProduct.amountRequiredToRecevieTheOffer ?? 0;
                    productInOrder.finalPriceForProduct += times * saleInProduct.totalPriceOnSale;
                    count = count % saleInProduct.amountRequiredToRecevieTheOffer ?? 0;
                    salesInProduct.Add(saleInProduct);
                }
                else
                    continue;
            }
            if (count > 0)
                productInOrder.finalPriceForProduct += count * productInOrder.productInOrderBasePrice ?? 0;
            productInOrder.listSales = salesInProduct;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void DoOrder(BO.Order order)
    {
        try
        {
            foreach (BO.ProductInOrder product in order.listProducts)
            {
                DO.Product p = _dal.Products.Read(product.productInOrderId);
                int count = p.quantityInStock ?? 0 - product.quintityInOrder ?? 0;

                _dal.Products.Update(p with { quantityInStock = count });
            }
        }
        catch (DO.DalIdNotExistsException e)
        {
            throw new BO.BLIdNotExistsException("ההזמנה אינו קיימת", e);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool isPreferredOrOccasionalClient)
    {
        try
        {
            productInOrder.listSales = _dal.Sale.ReadAll(s => s.idOfProduct == productInOrder.productInOrderId && (s.whoIsThePremotionFor == true || isPreferredOrOccasionalClient) && DateTime.Now >= s.dateStartSale && DateTime.Now <= s.dateFinishSale && s.amountRequiredToRecevieTheOffer <= productInOrder.quintityInOrder).Select(s => s.ConvertToBOSaleInProduct()).OrderBy(s => s.totalPriceOnSale / s.amountRequiredToRecevieTheOffer).ToList();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
