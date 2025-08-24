using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.ViewModel
{
    internal class DefineGoodsDTO
    {
        public int id { get; set; }
        public string goodsCode { get; set; }
        public string goodsName { get; set; }
        public Nullable<int> goodsGroup { get; set; }
        public Nullable<int> goodsStore { get; set; }
        public Nullable<int> goodsUnit { get; set; }
        public string goodsDisc { get; set; }
        public Nullable<double> goodsMin { get; set; }
        public Nullable<double> goodsMax { get; set; }
        public Nullable<double> goosOrderPoint { get; set; }
        public Nullable<double> goodsWeight { get; set; }
        public byte[] goodsPic { get; set; }
        public string userName { get; set; }
        public string timeStamp { get; set; }
        public Nullable<bool> isActive { get; set; }

        
        public string storeName { get; set; }
        public string goodsGroupName { get; set; }
        public string unitName { get; set; }
    }
    internal class DefineSpecialGoodsColumnDTO
    {
        public int id { get; set; }
        public string goodsCode { get; set; }
        public string goodsName { get; set; }
       
    }
}
