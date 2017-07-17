using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.MagBLL;
using Newtonsoft.Json;

namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// t_ProductsStockGetID 的摘要说明
    /// </summary>
    public class t_ProductsStockGetID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = int.Parse(context.Request["page"]);
            int count = int.Parse(context.Request["rows"]);
            int con = Convert.ToInt32(context.Request["id"]);

            context.Response.Write("{\"total\":" + t_ProductsStockManages.getcount(con) +
                ",\"rows\":" + JsonConvert.SerializeObject(t_ProductsStockManages.productinfogetid(con)) + "}");
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