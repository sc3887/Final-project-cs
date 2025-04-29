//using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Tools;
using static BO.Tools;

namespace BlImplementation

{
    internal class ImplementionClient : BlApi.IClient
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        //CRUD - מימוש פונקציות ה
        public int Create(BO.Client item)
        {
            try
            {
                return _dal.Client.Create(item.ConvertToDOClient());
            }
            catch (DO.DalIdIsExistsException e )
            {
                throw new BO.BLIdIsExistsException("הלקוח כבר קיים", e);
            }
            catch(Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        
        }
        public BO.Client? Read(Func<BO.Client, bool> filter)
        {
            try
            {
                return _dal.Client.Read(doClient => filter(doClient.ConvertToBOClient())).ConvertToBOClient();
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("הלקוח לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }

        public BO.Client? Read(int id)
        {
            try
            {
                return _dal.Client.Read(id).ConvertToBOClient();
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("הלקוח לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }
        public List<BO.Client?> ReadAll(Func<BO.Client, bool>? filter = null)
        {
            try
            {
                if (filter != null)
                    return _dal.Client.ReadAll(doClient => filter(doClient.ConvertToBOClient())).Select(x => x.ConvertToBOClient()).ToList();
                return _dal.Client.ReadAll().Select(x => x.ConvertToBOClient()).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }

        }

        public void Update(BO.Client item)
        {
            try
            {
                _dal.Client.Update(item.ConvertToDOClient());
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("הלקוח לא קיים", e);
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
                _dal.Client.Delete(id);
            }
            catch (DO.DalIdNotExistsException e)
            {
                throw new BO.BLIdNotExistsException("הלקוח לא קיים", e);
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }
        public bool isExist(BO.Client item)
        {
            try
            {
                DO.Client c = _dal.Client.ReadAll().FirstOrDefault(c => c.clientId == item.clientId);
                if (c == null)
                    return false;
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("שגיאה במערכת", e);
            }
        }   
    }
}
