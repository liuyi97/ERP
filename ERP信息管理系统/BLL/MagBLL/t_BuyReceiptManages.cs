using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.MagMdl;
using DAL;
namespace BLL.MagBLL
{
   public  class t_BuyReceiptManages
    {

        public static List<t_BuyReceipt> GetBuyReceipt(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            return t_BuyReceiptService.GetBuyReceipt(index, count, orderid, begin, end, receorderid);
        }
        public static int Getcount()
        {
            return t_BuyReceiptService.Getcount();
        }
        public static List<t_BuyReceipt> getinfobuyreceipt(int index, int count)
        {
            return t_BuyReceiptService.getinfobuyreceipt(index, count);
        }

        public static bool Buyreceiptid(string s)
        {
            return t_BuyReceiptService.Buyreceiptid(s);
        }
        public static bool Buynotreceiptid(string s)
        {
            return t_BuyReceiptService.Buynotreceiptid(s);
        }
        public static List<t_BuyReceipt> GetBuyAReceipt(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            return t_BuyReceiptService.GetBuyAReceipt(index, count, orderid, begin, end, receorderid);
        }
        }
}
