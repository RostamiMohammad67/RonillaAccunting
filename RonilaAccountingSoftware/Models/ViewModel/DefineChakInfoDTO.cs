using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.ViewModel
{
    internal class DefineChakInfoDTO
    {
        public int id { get; set; }
       
        public string chakNumSayadi { get; set; }
        public string chakSerial { get; set; }
        public Nullable<double> chakPrice { get; set; }
        public string chakDateSodor { get; set; }
        public string chakPasDay { get; set; }
        public Nullable<int> chakaccountNumberCode { get; set; }
        public string chakBranch { get; set; }
        public string chakInFace { get; set; }
        public Nullable<int> chakAlarmDay { get; set; }
        public string chakAlarmDate { get; set; }
        public string chakDisc { get; set; }
        public string userName { get; set; }
        public string timeStamp { get; set; }
        
        public string storeInputFactorNumber { get; set; }
        public Nullable<int> storeInputSupplierCode { get; set; }
        public string bankName { get; set; }
        public string bankAccountNumber { get; set; }
    }
   
}
