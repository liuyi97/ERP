using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MagMdl
{
  public   class t_BuyPay
    {
         public int PayID { get; set; }
        public string BuyReceiptID { get; set; }
        public string Ticket { get; set; }
        public string CreateDate { get; set; }
        public string UserName { get; set; }
        public int PayType { get; set; }
        public double RealPay { get; set; }
        public double AttachPay { get; set; }
        public string Description { get; set; }
        public string AuditingUser { get; set; }
        public string StateName { get; set; }
        public string PayTypeName { get; set; }
        public int State { get; set; }

    }
}
