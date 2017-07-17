using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.TransferDAL;
using Models.Transfers;
namespace BLL.TransferBLL
{
   public class TransferManager
    {
       //提交 保存信息到库存盘点表
       public static bool AddStock(TransInto t)
       {
           return DAL.TransferDAL.TransferService.AddStock(t);
       }
    }
}
