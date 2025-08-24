using RonilaAccountingSoftware.myClass;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class StoreInputServices
    {
        Models.RonilaDBEntities db = new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();

        //IRepository<Models.SupplierInfo> _mydb;
        //static IRepository<Models.SupplierInfo> _db;
        public StoreInputServices()
        {

        }

        public bool addData(StoreInput data)
        {
            db.StoreInputs.Add(data);
            db.SaveChanges();

            return true;
        }
        public bool editData(StoreInput data)
        {
            var info = db.StoreInputs.Where(x => x.id == data.id).ToList();
            if (info.Count > 0)
            {

                info[0].storeInputDocNumber = data.storeInputDocNumber;
                info[0].storeInputFactorNumber = data.storeInputFactorNumber;
                info[0].storeInputSupplierCode = data.storeInputSupplierCode;
                info[0].storeInputBuyDate = data.storeInputBuyDate;
                info[0].storeInputDisc = data.storeInputDisc;
                info[0].storeInputGoodsCode = data.storeInputGoodsCode;
                info[0].storeInputCount = data.storeInputCount;
                info[0].storeInputBuyPrice = data.storeInputBuyPrice;
                info[0].storeInputSellPrice = data.storeInputSellPrice;
                info[0].storeInputShamsiProductionDate = data.storeInputShamsiProductionDate;
                info[0].storeInputMiladiProductionDate = data.storeInputMiladiProductionDate;
                info[0].storeInputShamsiExpireDate = data.storeInputShamsiExpireDate;
                info[0].storeInputMiladiExpireDate = data.storeInputMiladiExpireDate;
                info[0].storeInputAlarmDay = data.storeInputAlarmDay;
                info[0].storeInputAlarmDate = data.storeInputAlarmDate;
                info[0].userName = UtilityClass.Username;
                info[0].timeStamp = fun.TimeStamp();


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
            var info = db.StoreInputs.Where(x => x.id == id).ToList();
            if (info.Count > 0)
            {
                db.StoreInputs.RemoveRange(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Models.StoreInput> GetAllData()
        {
            return db.StoreInputs.ToList();
        }
        public List<Models.StoreInput> getDataById(int id)
        {
            return db.StoreInputs.Where(x => x.id == id).ToList();
        }
        public List<Models.StoreInput> getDataByDocNumber(int docNumber)
        {
            return db.StoreInputs.Where(x => x.storeInputDocNumber == docNumber).ToList();
        }
        public List<Models.StoreInput> getDataByGoodsCode(string GoodsCode)
        {
            return db.StoreInputs.Where(x => x.storeInputGoodsCode == GoodsCode).ToList();
        }
        public int GetMaxId()
        {
            int.TryParse(db.StoreInputs.Select(x=>(int?)x.id).Max().GetValueOrDefault().ToString(),out var maxValue);
            return maxValue;
        }
        public int GetMaxDocNumber()
        {
            int.TryParse(db.StoreInputs.Select(x => (int?)x.storeInputDocNumber).Max().GetValueOrDefault().ToString(), out var maxValue);
            return maxValue;
        }
        public int GetMaxIdBySeller(int SupplierID)
        {
            int.TryParse(db.StoreInputs.Where(x=>x.storeInputSupplierCode==SupplierID).Select(x => (int?)x.id).Max().GetValueOrDefault().ToString(), out var maxValue);
            return maxValue;
        }
    }
}
