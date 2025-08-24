using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.ViewModel
{
    internal class CustomerDTO
    {
        public int id { get; set; }
        public string customerName { get; set; }
        public string customerPhoneNumber { get; set; }
        public string customer_mobile { get; set; }
        public string customerAddress { get; set; }
        public string customerDisc { get; set; }
        public string customerBirthDate { get; set; }
        public string customerNationalCode { get; set; }
        public string userName { get; set; }
        public string timeStamp { get; set; }
        public Nullable<int> ReagentCode { get; set; }
        public string ReagentName { get; set; }
       
        
    }
}
