using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class StoreInfoServices
    {
        Models.RonilaDBEntities db = new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        public StoreInfoServices()
        {

        }
        public bool add(StoreInfo data)
        {
            db.StoreInfoes.Add(data);
            db.SaveChanges();
            return true;
        }
        public bool edit(StoreInfo data)
        {
            var info = db.StoreInfoes.Where(x => x.id == data.id).ToList();
            if (info.Count > 0)
            {
                info[0].storeName = data.storeName;
                info[0].storePhone = data.storePhone;
                info[0].storeMob = data.storeMob;
                info[0].storeAddress = data.storeAddress;
                info[0].storeSlogan = data.storeSlogan;
                info[0].logo=data.logo;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool editAll(StoreInfo data)
        {
            var info = db.StoreInfoes.ToList();
            if (info.Count > 0)
            {
                for (int i = 0; i < info.Count; i++)
                {
                    info[i].storeName = data.storeName;
                    info[i].storePhone = data.storePhone;
                    info[i].storeMob = data.storeMob;
                    info[i].storeAddress = data.storeAddress;
                    info[i].storeSlogan = data.storeSlogan;
                    info[i].logo = data.logo;
                }
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool delete(int id)
        {
            var info = db.StoreInfoes.Where(x => x.id == id).ToList();
            if (info.Count > 0)
            {
                db.StoreInfoes.RemoveRange(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Models.StoreInfo> GetAllData()
        {

            return db.StoreInfoes.ToList();
        }

        public List<Models.StoreInfo> getDataById(int id)
        {
            return db.StoreInfoes.Where(x => x.id == id).ToList();
        }
    }
}
