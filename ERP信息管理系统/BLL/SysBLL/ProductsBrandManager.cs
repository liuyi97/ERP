using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.SysDAL;
using Model.SysModel;

namespace BLL.SysBLL
{
    public class ProductsBrandManager
    {
        public static int ProductsBrandInsert(ProductsBrand s)
        {
            return ProductsBrandService.ProductsBrandInsert(s);
        }
        public static List<ProductsBrand> ProductsBrandALL(int index, int rows)
        {
            return ProductsBrandService.ProductsBrandALL(index, rows);
        }
        public static int ProductsBrandzong()
        {
            return ProductsBrandService.ProductsBrandzong();
        }

        public static int ProductsBrandDelete(int id)
        {
            return ProductsBrandService.ProductsBrandDelete(id);
        }
        public static int ProductsBrandUpdate(ProductsBrand s)
        {
            return ProductsBrandService.ProductsBrandUpdate(s);
        }
        public static List<ProductsBrand> ProductsBrandID(int id)
        {
            return ProductsBrandService.ProductsBrandID(id);
        }
    }
}
