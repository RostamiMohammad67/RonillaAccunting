using RonilaAccountingSoftware.Models.ViewModel;
using RonilaAccountingSoftware.myClass;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI.ImageEditor.Dialogs;

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
        public List<Models.ViewModel.StoreInputDtO> GetStoreFullData()
        {
            return (from s in db.StoreInputs
                    join g in db.DefineGoods on s.storeInputGoodsCode equals g.goodsCode
                    join Sup in db.SupplierInfoes on s.storeInputSupplierCode equals Sup.id
                    select new StoreInputDtO
                    {
                        id = s.id,
                        storeInputDocNumber = s.storeInputDocNumber,
                        storeInputFactorNumber = s.storeInputFactorNumber,
                        storeInputSupplierCode = s.storeInputSupplierCode,
                        storeInputBuyDate = s.storeInputBuyDate,
                        storeInputDisc = s.storeInputDisc,
                        storeInputGoodsCode = s.storeInputGoodsCode,
                        storeInputCount = s.storeInputCount,
                        storeInputBuyPrice = s.storeInputBuyPrice,
                        storeInputSellPrice = s.storeInputSellPrice,
                        storeInputShamsiProductionDate = s.storeInputShamsiProductionDate,
                        storeInputMiladiProductionDate = s.storeInputMiladiProductionDate,
                        storeInputShamsiExpireDate = s.storeInputShamsiExpireDate,
                        storeInputMiladiExpireDate = s.storeInputMiladiExpireDate,
                        storeInputAlarmDay = s.storeInputAlarmDay,
                        storeInputAlarmDate = s.storeInputAlarmDate,
                        userName = s.userName,
                        timeStamp = s.timeStamp,
                        supplierName = Sup.supplierName,
                        goodsCode = g.goodsCode,
                        goodsName = g.goodsName

                    }).ToList();
        }
        public List<StoreInputDtO> getDataById(int id)
        {
            return (from s in db.StoreInputs
                    join g in db.DefineGoods on s.storeInputGoodsCode equals g.goodsCode
                    join Sup in db.SupplierInfoes on s.storeInputSupplierCode equals Sup.id
                    where s.id == id
                    select new StoreInputDtO
                    {
                        id = s.id,
                        storeInputDocNumber = s.storeInputDocNumber,
                        storeInputFactorNumber = s.storeInputFactorNumber,
                        storeInputSupplierCode = s.storeInputSupplierCode,
                        storeInputBuyDate = s.storeInputBuyDate,
                        storeInputDisc = s.storeInputDisc,
                        storeInputGoodsCode = s.storeInputGoodsCode,
                        storeInputCount = s.storeInputCount,
                        storeInputBuyPrice = s.storeInputBuyPrice,
                        storeInputSellPrice = s.storeInputSellPrice,
                        storeInputShamsiProductionDate = s.storeInputShamsiProductionDate,
                        storeInputMiladiProductionDate = s.storeInputMiladiProductionDate,
                        storeInputShamsiExpireDate = s.storeInputShamsiExpireDate,
                        storeInputMiladiExpireDate = s.storeInputMiladiExpireDate,
                        storeInputAlarmDay = s.storeInputAlarmDay,
                        storeInputAlarmDate = s.storeInputAlarmDate,
                        userName = s.userName,
                        timeStamp = s.timeStamp,
                        supplierName = Sup.supplierName,
                        goodsCode = g.goodsCode,
                        goodsName = g.goodsName

                    }).ToList();
        
        }
        public List<StoreInputDtO> getDataByDocNumber(int storeInputDocNumber)
        {
            return (from s in db.StoreInputs
                    join g in db.DefineGoods on s.storeInputGoodsCode equals g.goodsCode
                    join Sup in db.SupplierInfoes on s.storeInputSupplierCode equals Sup.id
                    where s.storeInputDocNumber == storeInputDocNumber
                    select new StoreInputDtO
                    {
                        id = s.id,
                        storeInputDocNumber = s.storeInputDocNumber,
                        storeInputFactorNumber = s.storeInputFactorNumber,
                        storeInputSupplierCode = s.storeInputSupplierCode,
                        storeInputBuyDate = s.storeInputBuyDate,
                        storeInputDisc = s.storeInputDisc,
                        storeInputGoodsCode = s.storeInputGoodsCode,
                        storeInputCount = s.storeInputCount,
                        storeInputBuyPrice = s.storeInputBuyPrice,
                        storeInputSellPrice = s.storeInputSellPrice,
                        storeInputShamsiProductionDate = s.storeInputShamsiProductionDate,
                        storeInputMiladiProductionDate = s.storeInputMiladiProductionDate,
                        storeInputShamsiExpireDate = s.storeInputShamsiExpireDate,
                        storeInputMiladiExpireDate = s.storeInputMiladiExpireDate,
                        storeInputAlarmDay = s.storeInputAlarmDay,
                        storeInputAlarmDate = s.storeInputAlarmDate,
                        userName = s.userName,
                        timeStamp = s.timeStamp,
                        supplierName = Sup.supplierName,
                        goodsCode = g.goodsCode,
                        goodsName = g.goodsName

                    }).ToList();
           // return db.StoreInputs.Where(x => x.storeInputDocNumber == docNumber).ToList();
        }
        public List<StoreInputDtO> getDataBySupplierFactorNumber(int SupplierCode, string factorNumber)
        {
            return (from s in db.StoreInputs
                    join g in db.DefineGoods on s.storeInputGoodsCode equals g.goodsCode
                    join Sup in db.SupplierInfoes on s.storeInputSupplierCode equals Sup.id
                    where s.storeInputSupplierCode == SupplierCode && s.storeInputFactorNumber== factorNumber
                    select new StoreInputDtO
                    {
                        id = s.id,
                        storeInputDocNumber = s.storeInputDocNumber,
                        storeInputFactorNumber = s.storeInputFactorNumber,
                        storeInputSupplierCode = s.storeInputSupplierCode,
                        storeInputBuyDate = s.storeInputBuyDate,
                        storeInputDisc = s.storeInputDisc,
                        storeInputGoodsCode = s.storeInputGoodsCode,
                        storeInputCount = s.storeInputCount,
                        storeInputBuyPrice = s.storeInputBuyPrice,
                        storeInputSellPrice = s.storeInputSellPrice,
                        storeInputShamsiProductionDate = s.storeInputShamsiProductionDate,
                        storeInputMiladiProductionDate = s.storeInputMiladiProductionDate,
                        storeInputShamsiExpireDate = s.storeInputShamsiExpireDate,
                        storeInputMiladiExpireDate = s.storeInputMiladiExpireDate,
                        storeInputAlarmDay = s.storeInputAlarmDay,
                        storeInputAlarmDate = s.storeInputAlarmDate,
                        userName = s.userName,
                        timeStamp = s.timeStamp,
                        supplierName = Sup.supplierName,
                        goodsCode = g.goodsCode,
                        goodsName = g.goodsName

                    }).ToList();
            //return db.StoreInputs.Where(x => x.storeInputSupplierCode == SupplierCode && x.storeInputFactorNumber == factorNumber).ToList();
        }
        public List<StoreInputDtO> getDataByGoodsCode(string GoodsCode)
        {
            return (from s in db.StoreInputs
                    join g in db.DefineGoods on s.storeInputGoodsCode equals g.goodsCode
                    join Sup in db.SupplierInfoes on s.storeInputSupplierCode equals Sup.id
                    where s.storeInputGoodsCode == GoodsCode 
                    select new StoreInputDtO
                    {
                        id = s.id,
                        storeInputDocNumber = s.storeInputDocNumber,
                        storeInputFactorNumber = s.storeInputFactorNumber,
                        storeInputSupplierCode = s.storeInputSupplierCode,
                        storeInputBuyDate = s.storeInputBuyDate,
                        storeInputDisc = s.storeInputDisc,
                        storeInputGoodsCode = s.storeInputGoodsCode,
                        storeInputCount = s.storeInputCount,
                        storeInputBuyPrice = s.storeInputBuyPrice,
                        storeInputSellPrice = s.storeInputSellPrice,
                        storeInputShamsiProductionDate = s.storeInputShamsiProductionDate,
                        storeInputMiladiProductionDate = s.storeInputMiladiProductionDate,
                        storeInputShamsiExpireDate = s.storeInputShamsiExpireDate,
                        storeInputMiladiExpireDate = s.storeInputMiladiExpireDate,
                        storeInputAlarmDay = s.storeInputAlarmDay,
                        storeInputAlarmDate = s.storeInputAlarmDate,
                        userName = s.userName,
                        timeStamp = s.timeStamp,
                        supplierName = Sup.supplierName,
                        goodsCode = g.goodsCode,
                        goodsName = g.goodsName

                    }).ToList();
            //return db.StoreInputs.Where(x => x.storeInputGoodsCode == GoodsCode).ToList();
        }
        public List<StoreInputDtO> getDataByDate(string start_date,string endDate)
        {
            return (from s in db.StoreInputs
                    join g in db.DefineGoods on s.storeInputGoodsCode equals g.goodsCode
                    join Sup in db.SupplierInfoes on s.storeInputSupplierCode equals Sup.id
                    where (s.storeInputBuyDate.CompareTo(start_date)>=0 && s.storeInputBuyDate.CompareTo(endDate) <= 0)
                    select new StoreInputDtO
                    {
                        id = s.id,
                        storeInputDocNumber = s.storeInputDocNumber,
                        storeInputFactorNumber = s.storeInputFactorNumber,
                        storeInputSupplierCode = s.storeInputSupplierCode,
                        storeInputBuyDate = s.storeInputBuyDate,
                        storeInputDisc = s.storeInputDisc,
                        storeInputGoodsCode = s.storeInputGoodsCode,
                        storeInputCount = s.storeInputCount,
                        storeInputBuyPrice = s.storeInputBuyPrice,
                        storeInputSellPrice = s.storeInputSellPrice,
                        storeInputShamsiProductionDate = s.storeInputShamsiProductionDate,
                        storeInputMiladiProductionDate = s.storeInputMiladiProductionDate,
                        storeInputShamsiExpireDate = s.storeInputShamsiExpireDate,
                        storeInputMiladiExpireDate = s.storeInputMiladiExpireDate,
                        storeInputAlarmDay = s.storeInputAlarmDay,
                        storeInputAlarmDate = s.storeInputAlarmDate,
                        userName = s.userName,
                        timeStamp = s.timeStamp,
                        supplierName = Sup.supplierName,
                        goodsCode = g.goodsCode,
                        goodsName = g.goodsName

                    }).ToList();
            //return db.StoreInputs.Where(x => x.storeInputGoodsCode == GoodsCode).ToList();
        }
        public int GetMaxId()
        {
            int.TryParse(db.StoreInputs.Select(x => (int?)x.id).Max().GetValueOrDefault().ToString(), out var maxValue);
            return maxValue;
        }
        public int GetMaxDocNumber()
        {
            int.TryParse(db.StoreInputs.Select(x => (int?)x.storeInputDocNumber).Max().GetValueOrDefault().ToString(), out var maxValue);
            return maxValue;
        }
        public int GetMaxIdBySupplier(int SupplierID)
        {
            int.TryParse(db.StoreInputs.Where(x => x.storeInputSupplierCode == SupplierID).Select(x => (int?)x.id).Max().GetValueOrDefault().ToString(), out var maxValue);
            return maxValue;
        }
    }
}
