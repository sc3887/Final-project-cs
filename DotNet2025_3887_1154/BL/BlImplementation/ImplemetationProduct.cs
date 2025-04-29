using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Tools;
namespace BlImplementation
{
    internal class ImplemetationProduct: BlApi.IProduct
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        //CRUD - מימוש פונקציות ה
        public int Create(BO.Product item)
        {
            try
            {
                return _dal.Products.Create(item.ConvertToDOProduct());
            }
            catch (DO.DalIdIsExistsException e)
            {
                throw new BO.BLIdIsExistsException("המוצר כבר קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }

        }
        public BO.Product? Read(Func<BO.Product, bool> filter)
        {
            try
            {
                return _dal.Products.Read(doProduct => filter(doProduct.ConvertToBOProduct())).ConvertToBOProduct();
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("המוצר לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }

        public BO.Product? Read(int id)
        {
            try
            {
                return _dal.Products.Read(id).ConvertToBOProduct();
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("המוצר לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }

        public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
        {
            try
            {
                if (filter == null)
                    return _dal.Products.ReadAll().Select(x => x.ConvertToBOProduct()).ToList();
                return _dal.Products.ReadAll().Select(x => x.ConvertToBOProduct()).Where(filter).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }

        public void Update(BO.Product item)
        {
            try
            {
                _dal.Products.Update(item.ConvertToDOProduct());
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("המוצר לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }
        public void Delete(int id)
        {
            try
            {
                _dal.Products.Delete(id);
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("המוצר לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }
        public List<BO.SaleInProduct> SaleInProducts(int productId, bool IsPrefferdClient)
        {
            try
            {
                return _dal.Sale.ReadAll(s => s.idOfProduct == productId && (s.whoIsThePremotionFor ?? false || IsPrefferdClient) && DateTime.Now >= s.dateStartSale && DateTime.Now <= s.dateFinishSale).Select(s => s.ConvertToBOSaleInProduct()).ToList();
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("המוצר לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }

    }
}
