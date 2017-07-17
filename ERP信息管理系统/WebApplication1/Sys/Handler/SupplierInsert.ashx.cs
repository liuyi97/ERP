using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.SysModel;
using BLL.SysBLL;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// SupplierInsert 的摘要说明
    /// </summary>
    public class SupplierInsert : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Supplier s = new Supplier();
            s.SupplierName = context.Request["SupplierName"];
            s.Area = context.Request["Area"];
            s.Postcode = context.Request["Postcode"];
            s.Address = context.Request["Address"];
            s.Linkman = context.Request["Linkman"];
            s.Tel = context.Request["Tel"];
            s.WebUrl = context.Request["WebUrl"];
            s.Email = context.Request["Email"];
            s.Bankname = context.Request["Bankname"];
            s.BankAccount = context.Request["BankAccount"];
            s.TaxNum = context.Request["TaxNum"];
            s.CreateDate = context.Request["CreateDate"];
            s.State = context.Request["State"];
            s.Description = context.Request["Description"];
            int rows;
            if (context.Request["id"] != "")
            { //修改
                s.SupplierID =Convert.ToInt32(context.Request["id"]);
                rows = SupplierManager.SupplierUpdate(s);
            }
            else { //添加
                rows = SupplierManager.SupplierInsert(s);
            }
            context.Response.Write(rows>0);
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