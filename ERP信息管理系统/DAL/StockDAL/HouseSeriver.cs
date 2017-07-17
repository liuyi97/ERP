using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using System.Data;
namespace DAL.NewFolder1
{
    //库房库区级联
   public class HouseSeriver
    {
        //库房
        public static List<StoreHouse> GetStore()
        {
            string sqlstr = string.Format("select * from t_StoreHouse");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            List<StoreHouse> list = new List<StoreHouse>();
            foreach (DataRow item in dt.Rows)
            {
                StoreHouse st = new StoreHouse();
              st.HouseName = item["HouseName"].ToString();
               st.HouseID= Convert.ToInt32(item["HouseID"].ToString());
                list.Add(st);
            }
            return list;
        }
        //库区级联
        public static List<HouseDetail> GetHouse(int index)
        {
            string sqlstr = string.Format("select * from t_StoreHouseDetail where HouseID={0}", index);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            List<HouseDetail> list = new List<HouseDetail>();
            foreach (DataRow item in dt.Rows)
            {
                HouseDetail ho = new HouseDetail();
               ho.ID = Convert.ToInt32(item["ID"].ToString());
               ho.SubareaName= item["SubareaName"].ToString();
                list.Add(ho);
            }
            return list;
        }
    }
}
