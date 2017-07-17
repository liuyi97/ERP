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
    /// StoreHouseALL 的摘要说明
    /// </summary>
    public class StoreHouseALL : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = Convert.ToInt32(context.Request["rows"]);
            int rows = Convert.ToInt32(context.Request["page"]);
            context.Response.Write("{\"total\":" + StoreHouseManager.StoreHousezong() + ",\"rows\":" + JsonConvert.SerializeObject(StoreHouseManager.StoreHouseALL(index, rows)) + "}");
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