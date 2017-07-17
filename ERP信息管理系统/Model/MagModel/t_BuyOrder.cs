using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public  class t_BuyOrder
    {
        public string BuyOrderID { get; set; }
        public string BuyOrderDate { get; set; }
        public int StoreHouseID { get; set; }
        public int HouseDetailID { get; set; }
        public string Delegate { get; set; }
        public string UserName { get; set; }
        public  double TotalPrice { get; set; }
        public string SignDate { get; set; }
        public string TradeDate { get; set; }
        public string TradeAddress { get; set; }
        public string Identitys { get; set; }

        public string HouseName { get; set; }
        public string StateName { get; set; }
        public string SubareaName { get; set; }
       
        public string Description { get; set; }
        public int State { get; set; }

    }
}
