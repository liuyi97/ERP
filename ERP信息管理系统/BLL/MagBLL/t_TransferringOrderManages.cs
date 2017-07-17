using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.MagMdl;
using DAL.MagDAL;
namespace BLL.MagBLL
{
 public   class t_TransferringOrderManages
    {
        public static List<t_TransferringOrder> getinfo(int index, int count)
        {
            return t_TransferringOrderService.getinfo(index, count);
        }
        public static int getgetindex()
        {
            return t_TransferringOrderService.getgetindex();
        }
        public static bool updatedate(string s)
        {
            return t_TransferringOrderService.updatedate(s);
        }
        public static bool TransferringOrderDel(string s)
        {
            return t_TransferringOrderService._TransferringOrderDel(s);
        }
        }
}
