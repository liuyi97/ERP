using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.SysModel;
using BLL.SysBLL;
using Newtonsoft.Json;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// Productschaxun 的摘要说明
    /// </summary>
    public class Productschaxun : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = Convert.ToInt32(context.Request["rows"]);
            int rows = Convert.ToInt32(context.Request["page"]);
            if (context.Request["xuanze"] == "1") {
                string c1 = context.Request["c1"];
                string c2 = context.Request["c2"];
                string t = context.Request["t"];
                context.Response.Write("{\"total\":" + ProductsManager.Productszong1(c1,c2,t) + ",\"rows\":" + JsonConvert.SerializeObject(ProductsManager.ProductsALL1(index, rows,c1,c2,t)) + "}");
            }
            else if (context.Request["xuanze"] == "2")
            {
                string c1 = context.Request["c1"];
                string c2 = context.Request["c2"];
                context.Response.Write("{\"total\":" + ProductsManager.Productszong2(c1, c2) + ",\"rows\":" + JsonConvert.SerializeObject(ProductsManager.ProductsALL2(index, rows, c1, c2)) + "}");
            }
            else if (context.Request["xuanze"] == "3")
            {
                string c1 = context.Request["c1"];
                string t = context.Request["t"];
                context.Response.Write("{\"total\":" + ProductsManager.Productszong3(c1, t) + ",\"rows\":" + JsonConvert.SerializeObject(ProductsManager.ProductsALL3(index, rows, c1, t)) + "}");
            }
            else if (context.Request["xuanze"] == "4")
            {
                string c1 = context.Request["c1"];
                context.Response.Write("{\"total\":" + ProductsManager.Productszong4(c1) + ",\"rows\":" + JsonConvert.SerializeObject(ProductsManager.ProductsALL4(index, rows, c1)) + "}");
            }
            else if (context.Request["xuanze"] == "5")
            {
                string c2 = context.Request["c2"];
                string t = context.Request["t"];
                context.Response.Write("{\"total\":" + ProductsManager.Productszong5( c2, t) + ",\"rows\":" + JsonConvert.SerializeObject(ProductsManager.ProductsALL5(index, rows, c2, t)) + "}");
            }
            else if (context.Request["xuanze"] == "6")
            {
                string c2 = context.Request["c2"];
                context.Response.Write("{\"total\":" + ProductsManager.Productszong6(c2) + ",\"rows\":" + JsonConvert.SerializeObject(ProductsManager.ProductsALL6(index, rows, c2)) + "}");
            }
            else if (context.Request["xuanze"] == "7")
            {
                string t = context.Request["t"];
                context.Response.Write("{\"total\":" + ProductsManager.Productszong7( t) + ",\"rows\":" + JsonConvert.SerializeObject(ProductsManager.ProductsALL7(index, rows, t)) + "}");
            }
            else if (context.Request["xuanze"] == "8")
            {
                context.Response.Write("{\"total\":" + ProductsManager.Productszong() + ",\"rows\":" + JsonConvert.SerializeObject(ProductsManager.ProductsALL(index, rows)) + "}");
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