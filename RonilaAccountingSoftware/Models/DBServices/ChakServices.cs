using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class ChakServices
    {
        Models.RonilaDBEntities db = new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        public ChakServices()
        {

        }
        public bool add(DefineChakInfo data)
        {
            db.DefineChakInfoes.Add(data);
            db.SaveChanges();
            return true;
        }
        public bool edit(DefineChakInfo data)
        {
            var info = db.DefineChakInfoes.Where(x => x.id == data.id).ToList();
            if (info.Count > 0)
            {
                info[0].chakStoreInputDocNumber = data.chakStoreInputDocNumber;
                info[0].chakNumSayadi =data.chakNumSayadi;
                info[0].chakSerial =data.chakSerial;
                info[0].chakPrice =data.chakPrice;
                info[0].chakDateSodor = data.chakDateSodor;
                info[0].chakPasDay = data.chakPasDay;
                info[0].chakaccountNumberCode = data.chakaccountNumberCode;
                info[0].chakBranch = data.chakBranch;
                info[0].chakInFace = data.chakInFace;
                info[0].chakAlarmDay = data.chakAlarmDay;
                info[0].chakAlarmDate = data.chakAlarmDate;
                info[0].userName = UtilityClass.Username;
                info[0].timeStamp =fun.today();
               

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
            var info = db.DefineChakInfoes.Where(x => x.id == id).ToList();
            if (info.Count > 0)
            {
                db.DefineChakInfoes.RemoveRange(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<ViewModel.DefineChakInfoDTO> GetAllData()
        {
            var info = (from a in db.DefineChakInfoes
                        join b in db.StoreInputs on a.chakStoreInputDocNumber equals b.storeInputDocNumber
                        join c in db.DefineBankAccounts on a.chakaccountNumberCode equals c.id
                        select new ViewModel.DefineChakInfoDTO
                        {
                            id = a.id,
                            chakStoreInputDocNumber = a.chakStoreInputDocNumber,
                            chakNumSayadi = a.chakNumSayadi,
                            chakSerial = a.chakSerial,
                            chakPrice = a.chakPrice,
                            chakDateSodor = a.chakDateSodor,
                            chakPasDay = a.chakPasDay,
                            chakaccountNumberCode = a.chakaccountNumberCode,
                            chakBranch = a.chakBranch,
                            chakInFace = a.chakInFace,
                            chakAlarmDay = a.chakAlarmDay,
                            chakAlarmDate = a.chakAlarmDate,
                            chakDisc = a.chakDisc,
                            userName = a.userName,
                            timeStamp = a.timeStamp,
                            storeInputFactorNumber = b.storeInputFactorNumber,
                            storeInputSupplierCode=b.storeInputSupplierCode,
                            bankName = c.bankName,
                            bankAccountNumber = c.bankAccountNumber
                        }).ToList();
            return info;
        }
        public List<ViewModel.DefineChakInfoDTO> getDataById(int id)
        {
            var info = (from a in db.DefineChakInfoes
                        join b in db.StoreInputs on a.chakStoreInputDocNumber equals b.storeInputDocNumber
                        join c in db.DefineBankAccounts on a.chakaccountNumberCode equals c.id
                        where a.id==id
                        select new ViewModel.DefineChakInfoDTO
                        {
                            id = a.id,
                            chakStoreInputDocNumber = a.chakStoreInputDocNumber,
                            chakNumSayadi = a.chakNumSayadi,
                            chakSerial = a.chakSerial,
                            chakPrice = a.chakPrice,
                            chakDateSodor = a.chakDateSodor,
                            chakPasDay = a.chakPasDay,
                            chakaccountNumberCode = a.chakaccountNumberCode,
                            chakBranch = a.chakBranch,
                            chakInFace = a.chakInFace,
                            chakAlarmDay = a.chakAlarmDay,
                            chakAlarmDate = a.chakAlarmDate,
                            chakDisc = a.chakDisc,
                            userName = a.userName,
                            timeStamp = a.timeStamp,
                            storeInputFactorNumber = b.storeInputFactorNumber,
                            storeInputSupplierCode = b.storeInputSupplierCode,
                            bankName = c.bankName,
                            bankAccountNumber = c.bankAccountNumber
                        }).ToList();
            return info;
        }
        public List<ViewModel.DefineChakInfoDTO> getDataByDocNumber(int docNumber)
        {
            var info = (from a in db.DefineChakInfoes
                        join b in db.StoreInputs on a.chakStoreInputDocNumber equals b.storeInputDocNumber
                        join c in db.DefineBankAccounts on a.chakaccountNumberCode equals c.id
                        where a.chakStoreInputDocNumber == docNumber
                        select new ViewModel.DefineChakInfoDTO
                        {
                            id = a.id,
                            chakStoreInputDocNumber = a.chakStoreInputDocNumber,
                            chakNumSayadi = a.chakNumSayadi,
                            chakSerial = a.chakSerial,
                            chakPrice = a.chakPrice,
                            chakDateSodor = a.chakDateSodor,
                            chakPasDay = a.chakPasDay,
                            chakaccountNumberCode = a.chakaccountNumberCode,
                            chakBranch = a.chakBranch,
                            chakInFace = a.chakInFace,
                            chakAlarmDay = a.chakAlarmDay,
                            chakAlarmDate = a.chakAlarmDate,
                            chakDisc = a.chakDisc,
                            userName = a.userName,
                            timeStamp = a.timeStamp,
                            storeInputFactorNumber = b.storeInputFactorNumber,
                            storeInputSupplierCode = b.storeInputSupplierCode,
                            bankName = c.bankName,
                            bankAccountNumber=c.bankAccountNumber
                        }).ToList();
            return info;
        }
        public List<ViewModel.DefineChakInfoDTO> getDataBySupplierAndFactorNumber(int supplierCode,string factorNumber)
        {
            var info = (from a in db.DefineChakInfoes
                        join b in db.StoreInputs on a.chakStoreInputDocNumber equals b.storeInputDocNumber
                        join c in db.DefineBankAccounts on a.chakaccountNumberCode equals c.id
                        where b.storeInputSupplierCode == supplierCode && b.storeInputFactorNumber == factorNumber
                        select new ViewModel.DefineChakInfoDTO
                        {
                            id = a.id,
                            chakStoreInputDocNumber = a.chakStoreInputDocNumber,
                            chakNumSayadi = a.chakNumSayadi,
                            chakSerial = a.chakSerial,
                            chakPrice = a.chakPrice,
                            chakDateSodor = a.chakDateSodor,
                            chakPasDay = a.chakPasDay,
                            chakaccountNumberCode = a.chakaccountNumberCode,
                            chakBranch = a.chakBranch,
                            chakInFace = a.chakInFace,
                            chakAlarmDay = a.chakAlarmDay,
                            chakAlarmDate = a.chakAlarmDate,
                            chakDisc = a.chakDisc,
                            userName = a.userName,
                            timeStamp = a.timeStamp,
                            storeInputFactorNumber = b.storeInputFactorNumber,
                            storeInputSupplierCode = b.storeInputSupplierCode,
                            bankName = c.bankName,
                            bankAccountNumber = c.bankAccountNumber
                        }).ToList();
            return info;
        }
    }
}
