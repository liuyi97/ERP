using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MagMdl
{
  public   class StockStatus
    {
        public string HouseName { get; set; }
        public string SubareaName { get; set; }
        public int productID { get; set; }
        public string ProductName { get; set; }
        public int uplimit { get; set; }
        public int downlimit { get; set; }
        public double Cost { get; set; }
        public int num { get; set; }
    }
}

