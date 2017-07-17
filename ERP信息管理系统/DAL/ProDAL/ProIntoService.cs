using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL.PIntoDAL
{
    public class ProIntoService
    {
        /// <summary>
        /// 查询入库类型
        /// </summary>
        /// <returns></returns>
        public static List<HouseType> IntoHouseType()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from HouseType";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<HouseType> list = new List<HouseType>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                HouseType ht = new HouseType();
                ht.TypeID = int.Parse(item["TypeID"].ToString());
                ht.TypeName = item["TypeName"].ToString();
                list.Add(ht);
            }
            return list;
        }

        /// <summary>
        /// 入库库区引用 查询数据库的库房信息
        /// </summary>
        /// <returns></returns>
        public static List<ProductMessage> House()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_StoreHouse";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProductMessage> list = new List<ProductMessage>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProductMessage p = new ProductMessage();
                p.HouseID = int.Parse(item["HouseID"].ToString());
                p.HouseName = item["HouseName"].ToString();
                list.Add(p);
            }
            return list;
        }

        /// <summary>
        /// 库房下面的库区详情
        /// </summary>
        /// <returns></returns>
        public static List<ProductMessage> HouseDetail(string id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_StoreHouseDetail where HouseID=" + id;
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProductMessage> list = new List<ProductMessage>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProductMessage p = new ProductMessage();
                p.HouseID = int.Parse(item["ID"].ToString());
                p.SubareaName = item["SubareaName"].ToString();
                list.Add(p);
            }
            return list;
        }

        /// <summary>
        /// 引用商品
        /// </summary>
        /// <returns></returns>
        public static List<ProAndSupply> SelectProduct()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"select sum(BillNum) BillNum,t_Products.ProductsID,t_Products.ProductsName 
                                    from t_Products join t_Inventory on t_Products.ProductsID=t_Inventory.ProductsID 
                                    group by t_Products.ProductsID,t_Products.ProductsName");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProAndSupply> list = new List<ProAndSupply>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProAndSupply p = new ProAndSupply();
                p.ProductsID = int.Parse(item["ProductsID"].ToString());
                p.ProductsName = item["ProductsName"].ToString();
                p.BillNum = int.Parse(item["BillNum"].ToString());
                list.Add(p);
            }
            return list;
        }

        ////更新商品数量
        //public static bool UpdateSum(int sum, int proID)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("ConStr");
        //    string sql = string.Format(@"update ");
        //}

        /// <summary>
        /// 模糊查询商品
        /// </summary>
        /// <returns></returns>
        public static List<ProAndSupply> MohuCheckProduct(string proname)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_Products where ProductsName like '%" + proname + "%'";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProAndSupply> list = new List<ProAndSupply>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProAndSupply p = new ProAndSupply();
                p.ProductsID = int.Parse(item["ProductsID"].ToString());
                p.ProductsName = item["ProductsName"].ToString();
                list.Add(p);
            }
            return list;
        }

        /// <summary>
        /// 引用供应商
        /// </summary>
        /// <returns></returns>
        public static List<ProAndSupply> SelectSupply()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_Supplier";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProAndSupply> list = new List<ProAndSupply>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProAndSupply p = new ProAndSupply();
                p.SupplierID = int.Parse(item["SupplierID"].ToString());
                p.SupplierName = item["SupplierName"].ToString();
                p.Area = item["Area"].ToString();
                list.Add(p);
            }
            return list;
        }
        /// <summary>
        /// 模糊查询供应商
        /// </summary>
        /// <param name="supplyname"></param>
        /// <returns></returns>
        public static List<ProAndSupply> MohuCheckSupply(string supplyname)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_Supplier where SupplierName like '%" + supplyname + "%'";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProAndSupply> list = new List<ProAndSupply>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProAndSupply p = new ProAndSupply();
                p.SupplierID = int.Parse(item["SupplierID"].ToString());
                p.SupplierName = item["SupplierName"].ToString();
                p.Area = item["Area"].ToString();
                list.Add(p);
            }
            return list;
        }

        /// <summary>
        /// 添加编辑的信息到保存表里
        /// </summary>
        /// <param name="supplyname"></param>
        /// <returns></returns>
        public static bool AddMessage(SaveIntoDetail save)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"insert into t_AppendStockDetail values('{0}',{1},{2},{3},{4},'{5}')",
                save.AppendID, save.ProductsID, save.SupplierID, save.Quantity, save.Price, save.Description == "" ? " " : save.Description);
            return db.ExecuteNonQuery(CommandType.Text, sql) > 0;

        }
        /// <summary>
        /// 查询添加成功的表单查询
        /// </summary>
        /// <returns></returns>
        public static List<SaveIntoDetail> CheckGridView(string AppendID)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"select t_AppendStockDetail.DetailID,ps.ProductsID,ProductsName,SupplierName,Quantity,Price,Price*Quantity Total     
                                        from t_AppendStockDetail join (select p.ProductsID,p.ProductsName,p.SupplierID,t_Supplier.SupplierName from t_Supplier    
                                        join (select distinct p.ProductsID,p.ProductsName,s.SupplierID from t_AppendStockDetail s join t_Products p on s.ProductsID=p.ProductsID ) p    
                                        on t_Supplier.SupplierID=p.SupplierID) ps on t_AppendStockDetail.ProductsID=ps.ProductsID 
                                         and ps.SupplierID=t_AppendStockDetail.SupplierID 
                                        and t_AppendStockDetail.AppendID ='{0}'", AppendID);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<SaveIntoDetail> list = new List<SaveIntoDetail>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SaveIntoDetail s = new SaveIntoDetail();
                s.DetailID = int.Parse(item["DetailID"].ToString());
                s.ProductsID = int.Parse(item["ProductsID"].ToString());
                s.ProductsName = item["ProductsName"].ToString();
                s.SupplierName = item["SupplierName"].ToString();
                s.Quantity = int.Parse(item["Quantity"].ToString());
                s.Price = Convert.ToDouble(item["Price"].ToString());
                s.Total = Convert.ToDouble(item["Total"].ToString());
                list.Add(s);
            }
            return list;
        }
        ////Gridview删除
        //public static int DeletProIntoMessage(int id)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("ConStr");
        //    string sql = "delete  from t_AppendStockDetail  where DetailID=" + id;
        //    return db.ExecuteNonQuery(CommandType.Text, sql);
        //}

        /// <summary>
        /// 根据供应商name查询ID
        /// </summary>
        /// <param name="SupplierName"></param>
        /// <returns></returns>
        public static int GetSupplierID(string SupplierName)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select SupplierID from t_Supplier where SupplierName='{0}'", SupplierName);
            return int.Parse(db.ExecuteScalar(CommandType.Text, sql).ToString());
        }

        //点击生成入库订单  添加主要信息到数据库
        public static bool SaveAllInto(SaveIntoMessage s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"insert into t_AppendStock (AppendID,CreateDate,AppendType,StoreHouseID,HouseDetailID,TradeDate,TotalPrice,AlreadyPay,Description,AuditingUser,UserName) values 
                ('{0}','{1}',{2},{3},{4},'{5}',{6},{7},'{8}','{9}','{10}')",
       s.AppendID, s.CreateDate, s.AppendType, s.StoreHouseID, s.HouseDetailID, s.TradeDate, s.TotalPrice, s.AlreadyPay, s.Description, s.AuditingUser, s.UserName);
            return db.ExecuteNonQuery(CommandType.Text, sql) > 0;
        }

        //点击完成所有更新总价
        public static void updateCountTotal(string AppendID, double total)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"update t_AppendStock set TotalPrice={0} where AppendID='{1}'", total, AppendID);
            db.ExecuteNonQuery(CommandType.Text, sql);
        }

        //查询 显示信息到入库明细单 
        public static SaveIntoMessage GetDetails(string AppendID)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"select t_AppendStock.AppendID,t_AppendStock.CreateDate,t_AppendStock.UserName,
                    t_AppendStock.HouseDetailID,t_AppendStock.StoreHouseID,t_AppendStock.TradeDate,
                    t_AppendStock.TotalPrice,t_AppendStock.State,t_AppendStock.Description from  t_AppendStock where t_AppendStock.AppendID='{0}'", AppendID);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            SaveIntoMessage s = new SaveIntoMessage();
            s.AppendID = ds.Tables[0].Rows[0]["AppendID"].ToString();
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
            string sql = string.Format(@"delete  from t_AppendStock where AppendID='{0}'", ID);
            return db.ExecuteNonQuery(CommandType.Text, sql) > 0;
        }
        //删除该单从表
        public static bool DeleteSon(string ID)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"delete  from t_AppendStockDetail where AppendID='{0}'", ID);
            return db.ExecuteNonQuery(CommandType.Text, sql) > 0;
        }

    }
}
