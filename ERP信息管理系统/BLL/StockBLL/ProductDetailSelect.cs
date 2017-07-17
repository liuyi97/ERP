using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using System.Data;
using DAL.NewFolder1;
namespace BLL.NewFolder1
{
  public  class ProductDetailSelect

    {
        public static List<addorder> GetProductSel(int count,int index)
        {
            return ProductDetail.GetProductSel(count,index);
        }
        //总数
        public static int GetProductSum()
        {
            return ProductDetail.GetProductSum();
        }
    }
}
