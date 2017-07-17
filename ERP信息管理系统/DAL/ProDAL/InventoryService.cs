using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Models.InventoryModule;
namespace DAL.InventoryDAL
{
   public  class InventoryService
    {
       //提交 保存信息到库存盘点表
       public static bool AddStock(StockInto st)
       {
           Database db = DatabaseFactory.CreateDatabase("Constr");
           string sql = string.Format(@"insert into t_Inventory(InventoryID,CreateDate,StoreHouseID,HouseDetailID,ProductsID,RealityNum,BillNum,AdjustNum,UserName,Description) values('{0}','{1}',{2},{3},{4},{5},{6},{7},'{8}','{9}')",
st.InventoryID,st.CreatDate,st.StoreHouseID,st.HouseDetailID,st.ProductsID,st.BillNum,st.RealityNum, st.AdjustNum,st.UserName, st.Description == "" ? " " : st.Description);
           return db.ExecuteNonQuery(CommandType.Text, sql) > 0;
       }
    }
}
