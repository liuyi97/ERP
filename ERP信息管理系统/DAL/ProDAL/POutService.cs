using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models.ProductOut;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace DAL.POutDAL
{
   public class POutService
    {
        /// <summary>
        /// 添加编辑的信息到保存表里
        /// </summary>
        /// <param name="supplyname"></param>
        /// <returns></returns>
        public static bool AddMessage(SaveOutDetail save)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"insert into t_OutStockDetail values('{0}',{1},{2},'{3}','{4}')",
                save.OutID, save.ProductsID, save.Quantity, save.Price, save.Description == "" ? " " : save.Description);
            return db.ExecuteNonQuery(CommandType.Text, sql) > 0;

        }

        /// <summary>
        /// 查询添加成功的表单查询
        /// </summary>
        /// <returns></returns>
        public static List<SaveOutDetail> CheckGridView(string OutID)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"select t_OutStockDetail.DetailID,ps.ProductsID,ProductsName,Quantity,Price,Price*Quantity Total     
                              from t_OutStockDetail join (select p.ProductsID,p.ProductsName from     
                              (select distinct p.ProductsID,p.ProductsName from t_OutStockDetail s 
	                            join t_Products p on s.ProductsID=p.ProductsID ) p    
                              ) ps on t_OutStockDetail.ProductsID=ps.ProductsID  
                                        and t_OutStockDetail.OutID ='{0}'", OutID);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<SaveOutDetail> list = new List<SaveOutDetail>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SaveOutDetail s = new SaveOutDetail();
                s.DetailID = int.Parse(item["DetailID"].ToString());
                s.ProductsID = int.Parse(item["ProductsID"].ToString());
                s.ProductsName = item["ProductsName"].ToString();
                //s.SupplierName = item["SupplierName"].ToString();
                s.Quantity = int.Parse(item["Quantity"].ToString());
                s.Price = Convert.ToDouble(item["Price"].ToString());
                s.Total = Convert.ToDouble(item["Total"].ToString());
                list.Add(s);
            }
            return list;
        }

        //点击生成入库订单  添加主要信息到数据库
        public static bool SaveAllOut(SaveOutMessage s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"insert into t_OutStock (OutID,CreateDate,OutType,StoreHouseID,HouseDetailID,TradeDate,TotalPrice,AlreadyPay,Description,AuditingUser,UserName) values 
                ('{0}','{1}',{2},{3},{4},'{5}',{6},{7},'{8}','{9}','{10}')",
       s.OutID, s.CreateDate, s.OutType, s.StoreHouseID, s.HouseDetailID, s.TradeDate, s.TotalPrice, s.AlreadyPay, s.Description, s.AuditingUser, s.UserName);
            return db.ExecuteNonQuery(CommandType.Text, sql) > 0;
        }

        //点击完成所有更新总价
        public static void updateCountTotal(string OutID, double total)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"update t_OutStock set TotalPrice={0} where OutID='{1}'", total, OutID);
            db.ExecuteNonQuery(CommandType.Text, sql);
        }
        //查询 显示信息到出库明细单 
        public static SaveOutMessage GetDetails(string OutID)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"select t_OutStock.OutID,t_OutStock.CreateDate,t_OutStock.UserName,
                    t_OutStock.HouseDetailID,t_OutStock.StoreHouseID,t_OutStock.TradeDate,
                    t_OutStock.TotalPrice,t_OutStock.State,t_OutStock.Description from  t_OutStock where t_OutStock.OutID='{0}'", OutID);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            SaveOutMessage s = new SaveOutMessage();
            s.OutID = ds.Tables[0].Rows[0]["OutID"].ToString();
            s.CreateDate = ds.Tables[0].Rows[0]["CreateDate"].ToString();
            s.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
            s.HouseDetailID = int.Parse(ds.Tables[0].Rows[0]["HouseDetailID"].ToString());
            s.StoreHouseID = int.Parse(ds.Tables[0].Rows[0]["StoreHouseID"].ToString());
            s.HouseStore = GetHouseStore(s.HouseDetailID, s.StoreHouseID);
            s.TotalPrice = Convert.ToDouble(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
            s.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
            s.TradeDate = ds.Tables[0].Rows[0]["TradeDate"].ToString();
            return s;
        }

        //查询库房库区 并以文字形式显示
        public static string GetHouseStore(int StoreID, int HouseID)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"select t_StoreHouse.HouseName+'--'+t_StoreHouseDetail.SubareaName from 
                        t_StoreHouse join t_StoreHouseDetail on t_StoreHouse.HouseID=t_StoreHouseDetail.HouseID 
                        where t_StoreHouse.HouseID={0} and t_StoreHouseDetail.ID={1}", HouseID, StoreID);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        //删除该单主表
        public static bool DeleteMain(string ID)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"delete  from t_OutStock where OutID='{0}'", ID);
            return db.ExecuteNonQuery(CommandType.Text, sql) > 0;
        }
        //删除该单从表
        public static bool DeleteSon(string ID)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"delete  from t_OutStockDetail where OutID='{0}'", ID);
            return db.ExecuteNonQuery(CommandType.Text, sql) > 0;
        }
    }
}
