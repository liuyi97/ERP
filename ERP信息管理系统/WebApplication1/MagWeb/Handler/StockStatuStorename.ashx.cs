using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.MagBLL;
using Models;
using Newtonsoft.Json;

namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// StockStatuStorename 的摘要说明
    /// </summary>
    public class StockStatuStorename : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string subName = context.Request["Subname"];
            string StoreName = context.Request["storeName"];
            int index = int.Parse(context.Request["page"]);
            int count = int.Parse(context.Request["rows"]);
            context.Response.Write("{\"total\":" + StockStatusManages.StockStatuscounta(subName, StoreName, index, count) +
                ",\"rows\":" + JsonConvert.SerializeObject(StockStatusManages.StockStatusgetStoreName(subName, StoreName, index, count)) + "}");
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