using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.SysDAL;
using Model.SysModel;
using System.Data;

namespace BLL.SysBLL
{
    public class SupplierManager
    {
        public static List<Supplier> SupplierALL(int index, int rows) {
            return SupplierService.SupplierALL(index,rows);
        }
        public static int Supplierszong() {
            return SupplierService.Supplierszong();
        }
        public static int SupplierDelete(int id) {
            return SupplierService.SupplierDelete(id);
        }
        public static int SupplierInsert(Supplier s) {
            return SupplierService.SupplierInsert(s);
        }
        public static int SupplierUpdate(Supplier s) {
            return SupplierService.SupplierUpdate(s);
        }
        public static List<Supplier> SupplierID(int id) {
            return SupplierService.SupplierID(id);
        }
    }
}
