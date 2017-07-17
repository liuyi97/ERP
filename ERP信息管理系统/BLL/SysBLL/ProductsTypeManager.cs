using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.SysDAL;
using Model.SysModel;

namespace BLL.SysBLL
{
    public class ProductsTypeManager
    {
        public static int ProductsTypeInsert(ProductsType s)
        {
            return ProductsTypeService.ProductsTypeInsert(s);
        }
        public static List<ProductsType> ProductsTypeALL(int index, int rows)
        {
            return ProductsTypeService.ProductsTypeALL(index,rows);
        }
        public static int ProductsTypezong()
        {
            return ProductsTypeService.ProductsTypezong();
        }

        public static int ProductsTypeDelete(int id)
        {
            return ProductsTypeService.ProductsTypeDelete(id);
        }
        public static int ProductsTypeUpdate(ProductsType s)
        {
            return ProductsTypeService.ProductsTypeUpdate(s);
        }
        public static List<ProductsType> ProductsTypeID(int id)
        {
            return ProductsTypeService.ProductsTypeID(id);
        }
    }
}
