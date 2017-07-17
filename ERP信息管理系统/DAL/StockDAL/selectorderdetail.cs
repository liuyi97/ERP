using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using System.Data;
namespace DAL.NewFolder1
{
    public class selectorderdetail
    {
        //通过buyorderid查询数据
        public static DataTable GetSelect(string id)
        {
            string sqlstr = string.Format(@"select BuyOrderID, BuyOrderDate, StoreHouseID, HouseDetailID, UserName, State, SignDate,
TradeDate, TradeAddress, Description from t_BuyOrder where BuyOrderID = '{0}'", id);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //通过库房id 查询库房名
        public static DataTable GetStore(int id)
        {
            string sqlstr = string.Format("select HouseName from t_StoreHouse where HouseID='{0}'", id);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //通过库房id 查询库房名
        public static DataTable GetHouse(int id)
        {
            string sqlstr = string.Format("select SubareaName from t_StoreHouseDetail where ID={0}", id);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
    }
}
