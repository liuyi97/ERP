using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models.MagMdl;
namespace DAL.MagDAL
{
      public class t_BuyPayService
    {
        public static List<t_BuyPay> GetEmp(int index, int count)
        {
            string sql = string.Format(@"select  top {0}  BuyReceiptID , p.PayTypeName, t.RealPay,t.AttachPay,t.CreateDate,t.UserName, 
          e.StateName from PayType p, t_BuyPay t,t_Ste e where p.PayTypeID=t.PayType 
          and t.State=e.StateID and BuyReceiptID not in(select top {1} BuyReceiptID from  t_BuyPay) 
             ", count, (index - 1) * count);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyPay> list = new List<t_BuyPay>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyPay e = new t_BuyPay();
                e.BuyReceiptID = item["BuyReceiptID"].ToString();
                e.CreateDate = item["CreateDate"].ToString();
                e.PayTypeName = item["PayTypeName"].ToString();
                e.RealPay = Convert.ToDouble( item["RealPay"]);
                e.AttachPay = Convert.ToDouble(item["AttachPay"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;
        }
        public static List<t_BuyPay> getPaybuyid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            string sql = string.Format(@"select  top {0}  BuyReceiptID , p.PayTypeName, t.RealPay,t.AttachPay,t.CreateDate,t.UserName, 
          e.StateName from PayType p, t_BuyPay t,t_Ste e where p.PayTypeID=t.PayType 
          and t.State=e.StateID and BuyReceiptID not in(select top {1} BuyReceiptID from 
                  t_BuyPay) and (BuyReceiptID ='{2}' and CreateDate between '{3}'and '{4}'  and   t.State='{5}' ) 
             ", count, (index - 1) * count, orderid, begin, end, receorderid);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyPay> list = new List<t_BuyPay>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyPay e = new t_BuyPay();
                e.BuyReceiptID = item["BuyReceiptID"].ToString();
                e.CreateDate = item["CreateDate"].ToString();
                e.PayTypeName = item["PayTypeName"].ToString();
                e.RealPay = Convert.ToDouble(item["RealPay"]);
                e.AttachPay = Convert.ToDouble(item["AttachPay"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;
        }
        public static List<t_BuyPay> getPaybuynotid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            string sql = string.Format(@"select  top {0}  BuyReceiptID , p.PayTypeName, t.RealPay,t.AttachPay,t.CreateDate,t.UserName, 
          e.StateName from PayType p, t_BuyPay t,t_Ste e where p.PayTypeID=t.PayType 
          and t.State=e.StateID and BuyReceiptID not in(select top {1} BuyReceiptID from 
                  t_BuyPay) and (BuyReceiptID ='{2}' or CreateDate between '{3}'and '{4}'  or t.State='{5}' ) 
             ", count, (index - 1) * count,orderid,begin,end,receorderid);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyPay> list = new List<t_BuyPay>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyPay e = new t_BuyPay();
                e.BuyReceiptID = item["BuyReceiptID"].ToString();
                e.CreateDate = item["CreateDate"].ToString();
                e.PayTypeName = item["PayTypeName"].ToString();
                e.RealPay = Convert.ToDouble(item["RealPay"]);
                e.AttachPay = Convert.ToDouble(item["AttachPay"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;

        }
        public static int Getcount()
        {
            string sql = string.Format(@"select  BuyReceiptID , p.PayTypeName, t.RealPay,t.AttachPay,t.CreateDate,t.UserName, 
            e.StateName from PayType p, t_BuyPay t,t_Ste e where p.PayTypeID=t.PayType 
            and t.State=e.StateID ");
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static int Getcountid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            string sql = string.Format(@"select  top {0}  BuyReceiptID , p.PayTypeName, t.RealPay,t.AttachPay,t.CreateDate,t.UserName, 
          e.StateName from PayType p, t_BuyPay t,t_Ste e where p.PayTypeID=t.PayType 
          and t.State=e.StateID and BuyReceiptID not in(select top {1} BuyReceiptID from 
                  t_BuyPay) and (BuyReceiptID ='{2}' and CreateDate between '{3}'and '{4}'  and t.State='{5}' ) 
             ", count, (index - 1) * count, orderid, begin, end, receorderid);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static int Getcountnotid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            string sql = string.Format(@"select  top {0}  BuyReceiptID , p.PayTypeName, t.RealPay,t.AttachPay,t.CreateDate,t.UserName, 
          e.StateName from PayType p, t_BuyPay t,t_Ste e where p.PayTypeID=t.PayType 
          and t.State=e.StateID and BuyReceiptID not in(select top {1} BuyReceiptID from 
                  t_BuyPay) and (BuyReceiptID ='{2}' or CreateDate between '{3}'and '{4}'  or  t.State='{5}' ) 
             ", count, (index - 1) * count, orderid, begin, end, receorderid);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static bool getbuypaysheng(string s)
        {
            string sql = string.Format(@"update t_BuyPay set  State = 2 where BuyReceiptID in ({0})", s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }
        public static bool Getbuypaydel(string del)
        {
            string sql = string.Format("delete from t_BuyPay where BuyReceiptID in ({0})", del);
                bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }


    }
}
