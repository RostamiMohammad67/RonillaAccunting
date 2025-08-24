using RonilaAccountingSoftware.Models.ViewModel;
using RonilaAccountingSoftware.myClass;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class SuppliersServices
    {
        Models.RonilaDBEntities db = new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();
       
        //IRepository<Models.SupplierInfo> _mydb;
        //static IRepository<Models.SupplierInfo> _db;
        public SuppliersServices()
        {
            //var context = new RonilaDBEntities();
            //_db = new RepositoryService<Models.SupplierInfo>(context);
        }
      
        public bool addData(SupplierInfo data)
        {
            db.SupplierInfoes.Add(data);
            db.SaveChanges();
            
            return true;
        }
        public bool EditData(SupplierInfo data)
        {
            var info = db.SupplierInfoes.Where(x => x.id == data.id).ToList();
            if (info.Count > 0)
            {
                info[0].supplierName = data.supplierName;
                info[0].supplierPhoneNumber = data.supplierPhoneNumber;
                info[0].supplierAddress = data.supplierAddress;
                info[0].supplierDisc = data.supplierDisc;
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
            var info = db.SupplierInfoes.Where(x => x.id == id).ToList();
            if (info.Count > 0)
            {
                db.SupplierInfoes.RemoveRange(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Models.SupplierInfo> GetAllData()
        {
            return db.SupplierInfoes.ToList();
        }
        public List<SupplierDTO> GetspecialColumn()
        {
            var res= (from a in db.SupplierInfoes
                      select new SupplierDTO
                      {
                         id = a.id,
                          supplierName = a.supplierName
                      }).ToList();
            return res;
             
        }

        public List<Models.SupplierInfo> getDataById(int id)
        {
            return db.SupplierInfoes.Where(x => x.id == id).ToList();
        }
    }
}
