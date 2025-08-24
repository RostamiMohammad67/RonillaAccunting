using RonilaAccountingSoftware.myClass;
using RonilaAccountingSoftware.myForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class DefineStoreServices
    {
        Models.RonilaDBEntities db = new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        public DefineStoreServices()
        {

        }
        public bool addData(DefineStore data)
        {
            db.DefineStores.Add(data);
            db.SaveChanges();
            return true;
        }
        public bool editData(DefineStore data)
        {
            var info = db.DefineStores.Where(x => x.id == data.id).ToList();
            if (info.Count > 0)
            {
                info[0].storeName = data.storeName;
                info[0].storeDisc = data.storeDisc;
                info[0].userName = UtilityClass.Username;
                info[0].timeStamp = fun.today();

                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteData(int id)
        {
            var info = db.DefineStores.Where(x => x.id == id).ToList();
            if (info.Count > 0)
            {
                db.DefineStores.RemoveRange(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Models.DefineStore> GetAllData()
        {
            return db.DefineStores.ToList();
        }
        public List<Models.DefineStore> getDataById(int id)
        {
            return db.DefineStores.Where(x => x.id == id).ToList();
        }
        public int GetMaxStore()
        {
            return db.DefineStores.Max(x => x.id);
        }
    }
}
