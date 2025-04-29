using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Tools;

namespace BlImplementation
{
    internal class ImplementationSale : BlApi.ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        //CRUD - מימוש פונקציות ה
        public int Create(BO.Sale item)
        {
            try
            {
                return _dal.Sale.Create(item.ConvertToDOSale());
            }
            catch (DO.DalIdIsExistsException e)
            {
                throw new BO.BLIdIsExistsException("המבצע כבר קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }
        public BO.Sale? Read(Func<BO.Sale, bool> filter)
        {
            try
            {
                return _dal.Sale.Read(doSale => filter(doSale.ConvertToBOSale())).ConvertToBOSale();
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("המבצע לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }

        public BO.Sale? Read(int id)
        {
            try
            {
                return _dal.Sale.Read(id).ConvertToBOSale();
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("המבצע לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }
        public List<BO.Sale> ReadAll(Func<BO.Sale, bool>? filter = null)
        {
            try
            {
                if (filter == null)
                    return _dal.Sale.ReadAll().Select(x => x.ConvertToBOSale()).ToList();
                return _dal.Sale.ReadAll(doSale => filter(doSale.ConvertToBOSale())).Select(x => x.ConvertToBOSale()).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }
        public void Update(BO.Sale item)
        {
            try
            {
                _dal.Sale.Update(item.ConvertToDOSale());
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("המבצע לא קיים", e);
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
                _dal.Sale.Delete(id);
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("המבצע לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }

    }
}   

