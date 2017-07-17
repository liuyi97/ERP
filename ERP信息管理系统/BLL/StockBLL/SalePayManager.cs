using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.NewFolder1;
using System.Data;
using Model.NewFolder1;
namespace BLL.NewFolder1
{
    public class SalePayManager
    {
        public static DataTable GetBuyOrderID()
        {
            return SalePay.GetBuyOrederID();
        }
        //通过采购单号查询单据总额，已付金额
        public static DataTable GetTotal(string buyorderid)
        {
            return SalePay.GetTotal(buyorderid);
        }
        //支付类型
        public static DataTable GetLei()
        {
            return SalePay.GetLei();
        }
        //信息添加入库
        public static bool GetAdd(addorder ad)
        {
            return SalePay.GetAdd(ad);
        }
        public static DataTable Get()
        {
            return SalePay.Get();
        }
    }
}
