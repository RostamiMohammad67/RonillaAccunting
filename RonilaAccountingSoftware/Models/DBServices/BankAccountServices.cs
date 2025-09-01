using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class BankAccountServices
    {
        Models.RonilaDBEntities db = new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        public BankAccountServices()
        {

        }
        public bool add(DefineBankAccount data)
        {
            db.DefineBankAccounts.Add(data);
            db.SaveChanges();
            return true;
        }
        public bool edit(DefineBankAccount data)
        {
            var info = db.DefineBankAccounts.Where(x => x.id == data.id).ToList();
            if (info.Count > 0)
            {
                info[0].bankName = data.bankName;
                info[0].bankCartNumber =data.bankCartNumber;
                info[0].bankAccountNumber =data.bankAccountNumber;
                info[0].bankShabaNumber =data.bankShabaNumber;
                info[0].bandDisc =data.bandDisc;
                info[0].userName =UtilityClass.Username;
               

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
            var info = db.DefineBankAccounts.Where(x => x.id == id).ToList();
            if (info.Count > 0)
            {
                db.DefineBankAccounts.RemoveRange(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Models.DefineBankAccount> GetAllData()
        {

            return db.DefineBankAccounts.ToList();
        }
        
        public List<Models.DefineBankAccount> getDataById(int id)
        {
            return db.DefineBankAccounts.Where(x => x.id == id).ToList();
        }
    }
}
