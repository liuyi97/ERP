using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL.PIntoBLL
{
   public class ProIntoManager
    {
       //入库类型
       public static List<HouseType> IntoHouseType()
       {
           return DAL.PIntoDAL.ProIntoService.IntoHouseType();
       }

       //库房引用的库房信息
       public static List<ProductMessage> House()
       {
           return DAL.PIntoDAL.ProIntoService.House();
       }

       //库房下的库区具体信息
       public static List<ProductMessage> HouseDetail(string id)
       {
           return DAL.PIntoDAL.ProIntoService.HouseDetail(id);
       }
       //供应商引用具体信息 
       public static List<ProAndSupply> SelectSupply()
       {
           return DAL.PIntoDAL.ProIntoService.SelectSupply();
       }
         //引用商品
       public static List<ProAndSupply> SelectProduct()
       {
           return DAL.PIntoDAL.ProIntoService.SelectProduct();
       }
       //模糊查询商品
       public static List<ProAndSupply> MohuCheckProduct(string proname)
       {
           return DAL.PIntoDAL.ProIntoService.MohuCheckProduct(proname);
       }
       //模糊查询供应商
       public static List<ProAndSupply> MohuCheckSupply(string supplyname)
       {
           return DAL.PIntoDAL.ProIntoService.MohuCheckSupply(supplyname);
       }

       //添加信息保存到数据库
       public static bool AddMessage(SaveIntoDetail save)
       {
           return DAL.PIntoDAL.ProIntoService.AddMessage(save);
       }

       //查询保存的信息
       public static List<SaveIntoDetail> CheckGridView(string AppendID)
       {
           return DAL.PIntoDAL.ProIntoService.CheckGridView(AppendID);
       }
       ////Gridview删除
       //public static int DeletProIntoMessage(int id)
       //{
       //    return DAL.PIntoDAL.ProIntoService.DeletProIntoMessage(id);
       //}

       //获取供应商ID
       public static int GetSupplierID(string SupplierName) {
           return DAL.PIntoDAL.ProIntoService.GetSupplierID(SupplierName);
       }

       //保存信息到数据库的订单明细
       public static bool SaveAllInto(SaveIntoMessage s)
       {
           return DAL.PIntoDAL.ProIntoService.SaveAllInto(s);
       }
        //查询 显示信息到入库明细单 
       public static SaveIntoMessage GetDetails(string AppendID)
       {
           return DAL.PIntoDAL.ProIntoService.GetDetails(AppendID);
       }

       //点击完成所有更新总价
       public static void updateCountTotal(string AppendID, double total) {
           DAL.PIntoDAL.ProIntoService.updateCountTotal(AppendID, total);
       }

       //删除该单主表
       public static bool DeleteMain(string ID)
       {
         return  DAL.PIntoDAL.ProIntoService.DeleteMain(ID);
       }

        //删除该单从表
       public static bool DeleteSon(string ID)
       {
           return DAL.PIntoDAL.ProIntoService.DeleteSon(ID);
       }
    }
}
