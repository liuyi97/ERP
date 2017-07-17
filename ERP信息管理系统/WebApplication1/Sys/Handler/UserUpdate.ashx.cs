using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.SysBLL;
using Model.SysModel;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// UserUpdate 的摘要说明
    /// </summary>
    public class UserUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            User s = new User();
            s.UserName = context.Request["UserName"];
            s.Password = context.Request["ProductsName"];
            s.TypeID = Convert.ToInt32(context.Request["TypeID"]);
            s.SubClassID = Convert.ToInt32(context.Request["SubClassID"]);
            s.GroupID = Convert.ToInt32(context.Request["GroupID"]);
            s.RealName = context.Request["RealName"];
            s.Sex = context.Request["Sex"];
            s.Dept = context.Request["Dept"];
            s.Tel = context.Request["Tel"];
            s.Email = context.Request["Email"];
            s.QQ = context.Request["QQ"];
            s.WangWang = context.Request["WangWang"];
            s.CompanyName = context.Request["CompanyName"];
            s.CompanyInfo = context.Request["CompanyInfo"];
            s.Bankname = context.Request["Bankname"];
            s.BankAccount = context.Request["BankAccount"];
            s.LatelyLogin = context.Request["LatelyLogin"];
            s.Address = context.Request["Address"];
            s.State = context.Request["State"];
            s.Description = context.Request["Description"];
            if (context.Request["name"] != "")
            {
                context.Response.Write(UserManager.UserUpdate(s) > 0);
            }
            else {
                context.Response.Write(UserManager.UserInsert(s) > 0);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}