using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Model.SysModel;
using System.Data;

namespace DAL.SysDAL
{
    public class SupplierService
    {
        public static List<Supplier> SupplierALL(int index, int rows)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_Supplier where SupplierID not in(select top {1} SupplierID from t_Supplier)", index, index * (rows - 1));
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Supplier> ll = new List<Supplier>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Supplier sh = new Supplier();
                sh.SupplierID = Convert.ToInt32(item["SupplierID"].ToString());
                sh.SupplierName = item["SupplierName"].ToString();
                sh.Area = item["Area"].ToString();
                sh.Postcode = item["Postcode"].ToString();
                sh.Address = item["Address"].ToString();
                sh.Linkman = item["Linkman"].ToString();
                sh.Tel = item["Tel"].ToString();
                sh.WebUrl = item["WebUrl"].ToString();
                sh.Email = item["Email"].ToString();
                sh.Bankname = item["Bankname"].ToString();
                sh.BankAccount = item["BankAccount"].ToString();
                sh.TaxNum = item["TaxNum"].ToString();
                sh.CreateDate = item["CreateDate"].ToString();
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static int Supplierszong()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_Supplier";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static int SupplierDelete(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "delete from t_Supplier where SupplierID=" + id;
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }

        public static int SupplierInsert(Supplier s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_Supplier values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')", s.SupplierName, s.Area, s.Postcode, s.Address, s.Linkman, s.Tel, s.WebUrl, s.Email, s.Bankname, s.BankAccount, s.TaxNum, s.CreateDate, s.Description, s.State);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }

        public static int SupplierUpdate(Supplier s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_Supplier set SupplierName='{0}',Area='{1}',Postcode='{2}',Address='{3}',Linkman='{4}',Tel='{5}',WebUrl='{6}',Email='{7}',Bankname='{8}',BankAccount='{9}',TaxNum='{10}',CreateDate='{11}',Description='{12}',State='{13}' where SupplierID='{14}'", s.SupplierName, s.Area, s.Postcode, s.Address, s.Linkman, s.Tel, s.WebUrl, s.Email, s.Bankname, s.BankAccount, s.TaxNum, s.CreateDate, s.Description, s.State, s.SupplierID);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }

        public static List<Supplier> SupplierID(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Supplier where SupplierID='{0}'", id);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Supplier> ll = new List<Supplier>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Supplier sh = new Supplier();
                sh.SupplierID = Convert.ToInt32(item["SupplierID"].ToString());
                sh.SupplierName = item["SupplierName"].ToString();
                sh.Area = item["Area"].ToString();
                sh.Postcode = item["Postcode"].ToString();
                sh.Address = item["Address"].ToString();
                sh.Linkman = item["Linkman"].ToString();
                sh.Tel = item["Tel"].ToString();
                sh.WebUrl = item["WebUrl"].ToString();
                sh.Email = item["Email"].ToString();
                sh.Bankname = item["Bankname"].ToString();
                sh.BankAccount = item["BankAccount"].ToString();
                sh.TaxNum = item["TaxNum"].ToString();
                sh.CreateDate = item["CreateDate"].ToString();
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
    }
}
