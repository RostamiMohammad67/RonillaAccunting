using RonilaAccountingSoftware.myClass;
using RonilaAccountingSoftware.myForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class DefineGoodsGroupServices
    {
        Models.RonilaDBEntities db = new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        public DefineGoodsGroupServices()
        {

        }
        public bool addData(DefineGoodsGroup data)
        {
            db.DefineGoodsGroups.Add(data);
            db.SaveChanges();
            return true;
        }
        public bool editData(DefineGoodsGroup data)
        {
            var info = db.DefineGoodsGroups.Where(x => x.id == data.id).ToList();
            if (info.Count > 0)
            {
                info[0].goodsGroupName = data.goodsGroupName;
                info[0].storeId = data.storeId;
                info[0].goodsGroupDisc = data.goodsGroupDisc;
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
            var info = db.DefineGoodsGroups.Where(x => x.id == id).ToList();
            if (info.Count > 0)
            {
                db.DefineGoodsGroups.RemoveRange(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Models.DefineGoodsGroup> GetAllData()
        {
            return db.DefineGoodsGroups.ToList();
        }
        public List<Models.ViewModel.DefineGoodsGroupDTO> GetAllDataWithStoreInfo()
        {

            var info = from x in db.DefineGoodsGroups
                       join y in db.DefineStores on x.storeId equals y.id
                       select new Models.ViewModel.DefineGoodsGroupDTO
                       {
                           id = x.id,
                           storeId = x.storeId,
                           goodsGroupDisc = x.goodsGroupDisc,
                           goodsGroupName = x.goodsGroupName,
                           timeStamp = x.userName,
                           userName = x.userName,
                           storeName = y.storeName,
                       };


            return info.ToList();
        }
        public List<Models.DefineGoodsGroup> getDataById(int id)
        {
            return db.DefineGoodsGroups.Where(x => x.id == id).ToList();
        }
        public int GetMaxGoodsGroup()
        {
            return db.DefineGoodsGroups.Max(x=>x.id) + 1;
        }
    }
}
