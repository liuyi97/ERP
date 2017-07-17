using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.MagDAL;
namespace BLL.MagBLL
{
    public  class t_BuyReturnManages
    {
        public static List<t_BuyReturn> getReturninfoorid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            return t_BuyReturnService.getReturninfoorid(index, count,orderid, begin, end, receorderid);
        }
        public static List<t_BuyReturn> getReturninfoandid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            return t_BuyReturnService.getReturninfoandid(index, count, orderid, begin, end, receorderid);
        }
        public static List<t_BuyReturn> getReturnInfo(int index, int count)
        {
            return t_BuyReturnService.getReturnInfo(index,count);
        }
        public static int Getcount()
        {
            return t_BuyReturnService.Getcount();
        }
        public static bool buyReturnsheng(string s)
        {
            return t_BuyReturnService.buyReturnsheng(s);
        }
        public static bool buyReturnDel(string s)
        {
            return t_BuyReturnService.buyReturnDel(s);
        }
    }
}
