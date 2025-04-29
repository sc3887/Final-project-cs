using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi
{
    public interface IOrder
    {
        List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int quintity);
        void CalcTotalPriceForProduct(BO.ProductInOrder product);
        void CalcTotalPrice(BO.Order order);
        void DoOrder(BO.Order order);
        public void SearchSaleForProduct(BO.ProductInOrder ProductInOrder, bool isPreferredOrOccasionalClient);

    }
}
