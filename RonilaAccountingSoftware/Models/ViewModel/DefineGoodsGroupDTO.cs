using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.ViewModel
{
    internal class DefineGoodsGroupDTO
    {
        public int id { get; set; }
        public Nullable<int> storeId { get; set; }
        public string goodsGroupName { get; set; }
        public string goodsGroupDisc { get; set; }
        public string userName { get; set; }
        public string timeStamp { get; set; }

        public string storeName { get; set; }
    }
   
}
