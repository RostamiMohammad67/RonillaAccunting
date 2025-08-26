using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.ViewModel
{
    internal class StoreInputDtO
    {
        public int id { get; set; }
        public Nullable<int> storeInputDocNumber { get; set; }
        public string storeInputFactorNumber { get; set; }
        public Nullable<int> storeInputSupplierCode { get; set; }
        public string storeInputBuyDate { get; set; }
        public string storeInputDisc { get; set; }
        public string storeInputGoodsCode { get; set; }
        public Nullable<double> storeInputCount { get; set; }
        public Nullable<double> storeInputBuyPrice { get; set; }
        public Nullable<double> storeInputSellPrice { get; set; }
        public string storeInputShamsiProductionDate { get; set; }
        public string storeInputMiladiProductionDate { get; set; }
        public string storeInputShamsiExpireDate { get; set; }
        public string storeInputMiladiExpireDate { get; set; }
        public Nullable<int> storeInputAlarmDay { get; set; }
        public string storeInputAlarmDate { get; set; }
        public string userName { get; set; }
        public string timeStamp { get; set; }

        public string supplierName { get; set; }
        public string goodsCode { get; set; }
        public string goodsName { get; set; }
    }
   
}
