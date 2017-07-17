using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Models;
using Models.ProductOut;

namespace BLL.POutBLL
{
   public class POutManager
    {
        //添加编辑的信息到保存表里
        public static bool AddMessage(SaveOutDetail save)
        {
            return DAL.POutDAL.POutService.AddMessage(save);
        }
        // 查询添加成功的表单查询
        public static List<SaveOutDetail> CheckGridView(string OutID)
        {
            return DAL.POutDAL.POutService.CheckGridView(OutID);
        }
        //点击生成入库订单  添加主要信息到数据库
        public static bool SaveAllOut(SaveOutMessage s)
        {
            return DAL.POutDAL.POutService.SaveAllOut(s);
        }
        //点击完成所有更新总价
        public static void updateCountTotal(string OutID, double total)
        {
             DAL.POutDAL.POutService.updateCountTotal(OutID,total);
        }
       //查询 显示信息到出库明细单 
        public static SaveOutMessage GetDetails(string OutID)
        {
            return DAL.POutDAL.POutService.GetDetails(OutID);
        }
       //查询库房库区 并以文字形式显示
        public static string GetHouseStore(int StoreID, int HouseID)
        {
            return DAL.POutDAL.POutService.GetHouseStore(StoreID, HouseID);
        }
        //删除该单主表
        public static bool DeleteMain(string ID)
        {
            return DAL.POutDAL.POutService.DeleteMain(ID);
        }
        //删除该单从表
        public static bool DeleteSon(string ID)
        {
            return DAL.POutDAL.POutService.DeleteMain(ID);
        }
    }
}
