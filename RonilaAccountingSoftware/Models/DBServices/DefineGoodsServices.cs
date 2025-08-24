using RonilaAccountingSoftware.Models.ViewModel;
using RonilaAccountingSoftware.myClass;
using RonilaAccountingSoftware.myForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class DefineGoodsServices
    {
        Models.RonilaDBEntities db = new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        public DefineGoodsServices()
        {

        }
        public bool addData(Models.DefineGood data)
        {
            db.DefineGoods.Add(data);
            db.SaveChanges();
            return true;
        }
        public bool editData(DefineGood data)
        {
            var info = db.DefineGoods.Where(x => x.id == data.id).ToList();
            if (info.Count > 0)
            {
                info[0].goodsCode = data.goodsCode;
                info[0].goodsName = data.goodsName;
                info[0].goodsUnit = data.goodsUnit;
                info[0].goodsStore = data.goodsStore;
                info[0].goodsGroup = data.goodsGroup;
                info[0].goodsMax = data.goodsMax;
                info[0].goodsMin = data.goodsMin;
                info[0].goosOrderPoint = data.goosOrderPoint;
                info[0].goodsWeight = data.goodsWeight;
                info[0].goodsPic = data.goodsPic;
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
            var info = db.DefineGoods.Where(x => x.id == id).ToList();
            if (info.Count > 0)
            {
                db.DefineGoods.RemoveRange(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Models.DefineGood> GetAllData()
        {
            return db.DefineGoods.ToList();
        }
        public List<DefineSpecialGoodsColumnDTO> GetspecialColumn()
        {
            var res = (from a in db.DefineGoods
                       select new DefineSpecialGoodsColumnDTO
                       {
                           id = a.id,
                           goodsCode = a.goodsCode,
                           goodsName = a.goodsName

                       }).ToList();
            return res;

        }

        public List<Models.DefineGood> getDataById(int id)
        {
            return db.DefineGoods.Where(x => x.id == id).ToList();
        }
        public int getGoodsCountByCode(string goods_code)
        {
            return db.DefineGoods.Where(x => x.goodsCode == goods_code).Count();
        }
        public List<Models.DefineGood> getGoodsByCode(string goods_code)
        {
            return db.DefineGoods.Where(x => x.goodsCode == goods_code).ToList();
        }
        public List<Models.ViewModel.DefineGoodsDTO> GetGoodsStoreGroupUnitInfo()
        {

            var info = from x in db.DefineGoods
                       join y in db.DefineStores on x.goodsStore equals y.id
                       join z in db.UnitInfoes on x.goodsUnit equals z.id
                       join w in db.DefineGoodsGroups on x.goodsGroup equals w.id
                       select new Models.ViewModel.DefineGoodsDTO
                       {

                           goodsCode = x.goodsCode,
                           goodsName = x.goodsName,
                           goodsMax = x.goodsMax,
                           goodsMin = x.goodsMin,
                           goodsWeight = x.goodsWeight,
                           goodsDisc = x.goodsDisc,
                           goosOrderPoint = x.goosOrderPoint,
                           goodsPic = x.goodsPic,
                           goodsGroup = x.goodsGroup,
                           goodsStore = x.goodsStore,
                           goodsUnit = x.goodsUnit,
                           storeName = y.storeName,
                           unitName = z.unitName,

                           goodsGroupName = w.goodsGroupName,
                           timeStamp = x.userName,
                           userName = x.userName,
                           id = x.id,
                           isActive = x.isActive


                       };


            return info.ToList();
        }

    }
}
