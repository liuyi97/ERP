using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Transfers;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace DAL.TransferDAL
{
   public class TransferService
    {
        //提交 保存信息到库存盘点表
        public static bool AddStock(TransInto t)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format(@"insert into t_TransferringOrder(ID,Date,OutHouseID,InHouseID,ProductsID,Quantity,Price,UserName,TradeDate,Ticket,Description) 
   values('{0}','{1}',{2},{3},{4},{5},'{6}','{7}','{8}','{9}','{10}')",
  t.ID,t.Date,t.OutHouseID,t.InHouseID,t.ProductsID,t.Quantity,t.Price,t.UserName,t.TradeDate,t.Ticket,t.Description == "" ? " " : t.Description);
            return db.ExecuteNonQuery(CommandType.Text, sql) > 0;
        }

    }
}
