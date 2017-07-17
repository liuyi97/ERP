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
    /// ProductsALL 的摘要说明
    /// </summary>
    public class ProductsALL : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = Convert.ToInt32(context.Request["rows"]);
            int rows = Convert.ToInt32(context.Request["page"]);
            context.Response.Write("{\"total\":" + ProductsManager.Productszong() + ",\"rows\":" + JsonConvert.SerializeObject(ProductsManager.ProductsALL(index, rows)) + "}");
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