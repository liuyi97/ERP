using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.SysBLL;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// ProductstiaojiaUpdate 的摘要说明
    /// </summary>
    public class ProductstiaojiaUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["typeid"] != "" && context.Request["Price"]!="") {
                context.Response.Write(ProductsManager.tiaojiaUpdate(Convert.ToInt32(context.Request["typeid"]), Convert.ToDouble(context.Request["Price"]))>0);
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