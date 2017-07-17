using System;
using System.Collections.Generic;
using System.Linq;
using Model.SysModel;
using BLL.SysBLL;
using Newtonsoft.Json;
using System.Web;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// StoreHouseDelete 的摘要说明
    /// </summary>
    public class StoreHouseDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["id"] != null) {
                context.Response.Write(StoreHouseManager.StoreHouseDelete(Convert.ToInt32(context.Request["id"])) > 0);
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