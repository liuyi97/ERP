using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public static class t_BuyOrderManages
    {
        public static List<t_BuyOrder> GetEmp(int index, int count)
        {
            return t_BuyOrderService.GetEmp(index, count);
        }
        public static int Getcount()
        {
            return t_BuyOrderService.Getcount();
        }
        public static List<t_BuyOrder> getIDdata(int index, int count, string orderid, string begin, string end, int dataid)
        {
            return t_BuyOrderService.getIDdata(index, count, orderid, begin, end, dataid);
        }
        public static List<t_BuyOrder> getIDdataa(int index, int count, string orderid, string begin, string end, int dataid)
        {
            return t_BuyOrderService.getIDdataa(index, count, orderid, begin, end, dataid);
        }
        public static int Getcounta()
        {
            return t_BuyOrderService.Getcounta();
        }

        public static bool getbuyid(string s)
        {
            return t_BuyOrderService.getbuyid(s);
        }

        public static bool getnotbuyid(string s)
        {
            return t_BuyOrderService.getnotbuyid(s);
        }
    }
}

