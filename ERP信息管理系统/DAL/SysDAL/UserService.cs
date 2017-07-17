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
    public class UserService
    {
        public static List<User> dingleiDrop()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_UserTypeSubClass");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<User> ll = new List<User>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                User sh = new User();
                sh.SubClassID = Convert.ToInt32(item["SubClassID"].ToString());
                sh.SubClassName = item["SubClassName"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        public static List<User> leiDrop()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_UserType");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<User> ll = new List<User>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                User sh = new User();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.TypeName = item["TypeName"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static List<User> quanDrop()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Group");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<User> ll = new List<User>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                User sh = new User();
                sh.GroupID = Convert.ToInt32(item["GroupID"].ToString());
                sh.GroupName = item["GroupName"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static List<User> UserALL(int index, int rows)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_User,t_UserType,t_UserTypeSubClass,t_Group where t_User.TypeID=t_UserType.TypeID and t_User.SubClassID=t_UserTypeSubClass.SubClassID and t_User.GroupID=t_Group.GroupID and UserName not in(select top {1} UserName from t_User,t_UserType,t_UserTypeSubClass,t_Group where t_User.TypeID=t_UserType.TypeID and t_User.SubClassID=t_UserTypeSubClass.SubClassID and t_User.GroupID=t_Group.GroupID)", index, index * (rows - 1));
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<User> ll = new List<User>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                User sh = new User();
                sh.UserName = item["UserName"].ToString();
                sh.Password = item["Password"].ToString();
                sh.SubClassID = Convert.ToInt32(item["SubClassID"].ToString());
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.SubClassName = item["SubClassName"].ToString();
                sh.TypeName = item["TypeName"].ToString();
                sh.Character = item["Character"].ToString();
                sh.RealName = item["RealName"].ToString();
                sh.Sex = item["Sex"].ToString();
                sh.GroupID = Convert.ToInt32(item["GroupID"].ToString());
                sh.GroupName = item["GroupName"].ToString();
                sh.Address = item["Address"].ToString();
                sh.CompanyName = item["CompanyName"].ToString();
                sh.CompanyInfo = item["CompanyInfo"].ToString();
                sh.Dept = item["Dept"].ToString();
                sh.Tel = item["Tel"].ToString();
                sh.Email = item["Email"].ToString();
                sh.QQ = item["QQ"].ToString();
                sh.WangWang = item["WangWang"].ToString();
                sh.Bankname = item["Bankname"].ToString();
                sh.BankAccount = item["BankAccount"].ToString();
                sh.LatelyLogin = item["LatelyLogin"].ToString();
                sh.Description = item["Description"].ToString();
                sh.State = item["State"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        public static int Userzong()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_User,t_UserType,t_UserTypeSubClass,t_Group where t_User.TypeID=t_UserType.TypeID and t_User.SubClassID=t_UserTypeSubClass.SubClassID and t_User.GroupID=t_Group.GroupID";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }
        public static int UserInsert(User s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_User values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')", s.UserName, s.Password, s.TypeID, s.SubClassID, s.Character, s.RealName, s.Sex, s.GroupID, s.Address, s.CompanyName, s.CompanyInfo, s.Dept, s.Tel, s.Email, s.QQ, s.WangWang, s.Bankname, s.BankAccount, s.LatelyLogin, s.Description, s.State);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static int UserDelete(string name)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql =string.Format("delete from t_User where UserName='{0}'", name);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static int UserUpdate(User s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_User set Password='{0}',TypeID='{1}',SubClassID='{2}',Character='{3}',RealName='{4}',Sex='{5}',GroupID='{6}',Address='{7}',CompanyName='{8}',CompanyInfo='{9}',Dept='{10}',Tel='{11}',Email='{12}',QQ='{13}',WangWang='{14}',Bankname='{15}',BankAccount='{16}',LatelyLogin='{17}',Description='{18}',State='{19}'  where UserName='{20}'", s.Password, s.TypeID, s.SubClassID, s.Character, s.RealName, s.Sex, s.GroupID, s.Address, s.CompanyName, s.CompanyInfo, s.Dept, s.Tel, s.Email, s.QQ, s.WangWang, s.Bankname, s.BankAccount, s.LatelyLogin, s.Description, s.State, s.UserName);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static List<User> UserID(string name)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_User,t_UserType,t_UserTypeSubClass,t_Group where t_User.TypeID=t_UserType.TypeID and t_User.SubClassID=t_UserTypeSubClass.SubClassID and t_User.GroupID=t_Group.GroupID and UserName='{0}' ",name);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<User> ll = new List<User>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                User sh = new User();
                sh.UserName = item["UserName"].ToString();
                sh.Password = item["Password"].ToString();
                sh.SubClassID = Convert.ToInt32(item["SubClassID"].ToString());
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.SubClassName = item["SubClassName"].ToString();
                sh.TypeName = item["TypeName"].ToString();
                sh.Character = item["Character"].ToString();
                sh.RealName = item["RealName"].ToString();
                sh.Sex = item["Sex"].ToString();
                sh.GroupID = Convert.ToInt32(item["GroupID"].ToString());
                sh.GroupName = item["GroupName"].ToString();
                sh.Address = item["Address"].ToString();
                sh.CompanyName = item["CompanyName"].ToString();
                sh.CompanyInfo = item["CompanyInfo"].ToString();
                sh.Dept = item["Dept"].ToString();
                sh.Tel = item["Tel"].ToString();
                sh.Email = item["Email"].ToString();
                sh.QQ = item["QQ"].ToString();
                sh.WangWang = item["WangWang"].ToString();
                sh.Bankname = item["Bankname"].ToString();
                sh.BankAccount = item["BankAccount"].ToString();
                sh.LatelyLogin = item["LatelyLogin"].ToString();
                sh.Description = item["Description"].ToString();
                sh.State = item["State"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
    }
}
