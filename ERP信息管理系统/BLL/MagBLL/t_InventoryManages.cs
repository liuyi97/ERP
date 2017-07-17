using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.MagMdl;
using DAL.MagDAL;
namespace BLL.MagBLL
{
   public  class t_InventoryManages
    {
        public static int t_Inventorycount()
        {
            return t_InventoryService.t_Inventorycount();
        }
        public static List<t_Inventory> t_InventoryInfo(int index, int count)
        {
            return t_InventoryService.t_InventoryInfo(index, count);
        }
        public static bool t_Inventorysheng(string s)
        {
            return t_InventoryService.t_Inventorysheng(s);
        }
        public static List<t_Inventory> t_InventoryDataid(int index, int count, int dataid)
        {
            return t_InventoryService.t_InventoryDataid(index, count, dataid);
        }
        public static List<t_Inventory> t_InventoryGetid(int index, int count, string Getid)
        {
            return t_InventoryService.t_InventoryGetid(index, count, Getid);
        }
        public static List<t_Inventory> t_Inventorybegin(int index, int count, string begin, string end)
        {
            return t_InventoryService.t_Inventorybegin(index, count, begin, end);
        }
        public static int t_Inventorybegincount(int index, int count, string begin, string end)
        {
            return t_InventoryService.t_Inventorybegincount(index, count, begin, end);
        }
        public static int t_InventoryGetidcount(int index, int count, string Getid)
        {
            return t_InventoryService.t_InventoryGetidcount(index, count, Getid);
        }
        public static int t_InventoryDataidcount(int index, int count, int dataid)
        {
            return t_InventoryService.t_InventoryDataidcount(index, count, dataid);
        }
        public static bool t_InventoryDel(string s)
        {
            return t_InventoryService.t_InventoryDel(s);
        }
        }
}
