using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.MagMdl;
using DAL.MagDAL;
namespace BLL.MagBLL
{
    public   class t_ProductsStockManages
    {
        public static List<t_ProductsStock> productinfogetid(int id)
        {
            return t_ProductsStockService.productinfogetid(id);
        }
        public static int getcount(int id)
        {
            return t_ProductsStockService.getcount(id);
        }
        }
}
