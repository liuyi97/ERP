using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models.InventoryModule;
namespace BLL.InventoryBLL
{
   public  class InventoryManager
    {
       public static bool AddStock(StockInto st)
       {
           return DAL.InventoryDAL.InventoryService.AddStock(st);
       }
    }
}
