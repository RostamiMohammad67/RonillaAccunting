using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class CustomersServices
    {
        Models.RonilaDBEntities db = new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        public CustomersServices()
        {

        }
        public bool addCustomer(CustomerInfo data)
        {
            db.CustomerInfoes.Add(data);
            db.SaveChanges();
            return true;
        }
        public bool EditCustomer(CustomerInfo data)
        {
            var info = db.CustomerInfoes.Where(x => x.id == data.id).ToList();
            if (info.Count > 0)
            {
                info[0].customerName = data.customerName;
                info[0].customerPhoneNumber = data.customerPhoneNumber;
                info[0].customer_mobile = data.customer_mobile;
                info[0].customerNationalCode = data.customerNationalCode;
                info[0].customerBirthDate = data.customerBirthDate;
                info[0].customerAddress = data.customerAddress;
                info[0].customerDisc = data.customerDisc;
                //-------------------------------------------------
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
        public bool deleteCustomer(int id)
        {
            var info = db.CustomerInfoes.Where(x => x.id == id).ToList();
            if (info.Count > 0)
            {
                db.CustomerInfoes.RemoveRange(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Models.CustomerInfo> GetAllCustomer()
        {
            return db.CustomerInfoes.ToList();
        }
        /// <summary>
        /// دریافت اطلاعات مشتری به همراه اطلاعات معرف
        /// </summary>
        /// <returns></returns>
        public List<Models.ViewModel.CustomerDTO> GetAllCustomerWithReagentInfo()
        {
            var query = from c in db.CustomerInfoes
                        join r in db.CustomerInfoes
                        on c.ReagentCode equals r.id into reagents
                        from r in reagents.DefaultIfEmpty()
                        where r == null || c.id != r.id
                        select new Models.ViewModel.CustomerDTO
                        {
                            id = c.id,
                            customerName = c.customerName,
                            customerPhoneNumber = c.customerPhoneNumber,
                            customerAddress = c.customerAddress,
                            customerBirthDate = c.customerBirthDate,
                            customerDisc = c.customerDisc,
                            customerNationalCode = c.customerNationalCode,
                            customer_mobile = c.customerPhoneNumber,
                            ReagentCode = c.ReagentCode,
                            timeStamp = c.timeStamp,
                            userName = c.userName,
                            ReagentName = r.customerName,

                        };
            return query.ToList();
        }
        public List<Models.CustomerInfo> getCustomerById(int id)
        {
            return db.CustomerInfoes.Where(x => x.id == id).ToList();
        }
    }
}
