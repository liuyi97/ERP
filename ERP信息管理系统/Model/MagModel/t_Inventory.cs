using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MagMdl
{
    public class t_Inventory
    {
        public string InventoryID { get; set; }
        public string CreateDate { get; set; }
        public int RealityNum { get; set; }
        public int BillNum { get; set; }
        public int AdjustNum { get; set; }
        public string StateName { get; set; }
        public string zugename { get; set; }
        public string productName { get; set; }
    }
}
