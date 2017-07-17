using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using System.Data;
namespace DAL.NewFolder1
{
  public  class SalePay
    {
        public static DataTable GetBuyOrederID()
        {
            string sqlstr = string.Format(@"select buy.ReceiptOrderID,ste.StateName from
t_BuyReceipt buy join t_Ste ste on  buy.State=ste.StateID and ste.StateName='已审核'");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //通过采购单号查询单据总额，已付金额
        public static DataTable GetTotal(string buyorderid)
        {
            string sqlstr = string.Format(@"select TotalPrice,AlreadyPay from t_BuyReceipt where ReceiptOrderID='{0}'",buyorderid);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //支付类型
        public static DataTable GetLei()
        {
            string sqlstr = string.Format(@"select AccountsID,AccountsName from t_Accounts ");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //信息添加入库
        public static bool GetAdd(addorder ad)
        {
            string sqlstr = string.Format(@"insert into t_BuyPay(BuyReceiptID,CreateDate,Ticket,RealPay,AttachPay,PayType,Description,UserName,State)
values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", ad.BuyReceiptID,ad.CreateDate,ad.Ticket,ad.RealPay,ad.AttachPay,ad.PayType,ad.Description, ad.userName,ad.State);
            bool rows = DBHelper.ExecuteNon(sqlstr);
            return rows;
        }
        //
        public static DataTable Get()
        {
            string sqlstr=string.Format(@" select BuyReceiptID from t_BuyPay");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
    }
}
