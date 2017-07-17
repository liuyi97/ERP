using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using DAL.NewFolder1;
namespace BLL.NewFolder1
{
  public  class addorderManages
    {
        //添加采购订单
        public static bool AddSaleorder(addorder ad)
        {
            return addorderService.AddSaleorder(ad);
        }
        //添加商品信息
        public static bool AddProduct(addorder ad)
        {
            return addorderService.AddProduct(ad);
        }
    }
}
