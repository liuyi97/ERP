using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.MagDAL;
using Models.MagMdl;
namespace BLL.MagBLL
{
     public   class t_BuyPayManages
    {
        public static List<t_BuyPay> GetEmp(int index, int count)
        {
            return t_BuyPayService.GetEmp(index,count);
        }
        public static int Getcount()
        {
            return t_BuyPayService.Getcount();
        }
        public static List<t_BuyPay> getPaybuynotid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            return t_BuyPayService.getPaybuynotid(index,count, orderid, begin, end, receorderid);
        }
        public static List<t_BuyPay> getPaybuyid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            return t_BuyPayService.getPaybuyid(index, count, orderid, begin, end, receorderid);
        }
        public static int Getcountnotid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            return t_BuyPayService.Getcountnotid(index, count, orderid, begin, end, receorderid);
        }
        public static int Getcountid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            return t_BuyPayService.Getcountid(index, count, orderid, begin, end, receorderid);
        }
        public static bool getbuypaysheng(string s)
        {
            return t_BuyPayService.getbuypaysheng(s);
        }
        public static bool Getbuypaydel(string del)
        {
            return t_BuyPayService.Getbuypaydel(del);
        }
        }
}
