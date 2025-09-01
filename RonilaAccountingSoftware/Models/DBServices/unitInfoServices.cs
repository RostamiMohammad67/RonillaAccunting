using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class unitInfoServices
    {
        Models.RonilaDBEntities db = new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        public unitInfoServices()
        {

        }
        public bool addUnit(UnitInfo data)
        {
            db.UnitInfoes.Add(data);
            db.SaveChanges();
            return true;
        }
        public bool editUnit(UnitInfo data)
        {
            var info = db.UnitInfoes.Where(x => x.id == data.id).ToList();
            if (info.Count > 0)
            {
                info[0].unitName = data.unitName;
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
        public bool deleteUnit(int id)
        {
            var info = db.UnitInfoes.Where(x => x.id == id).ToList();
            if (info.Count > 0)
            {
                db.UnitInfoes.RemoveRange(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Models.UnitInfo> GetAllData()
        {
            return db.UnitInfoes.ToList();
        }
        public List<Models.UnitInfo> getDataById(int id)
        {
            return db.UnitInfoes.Where(x => x.id == id).ToList();
        }
    }
}
