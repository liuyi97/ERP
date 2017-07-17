using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.SysModel;
using BLL.SysBLL;
using Newtonsoft.Json;
using System.Data;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// quanALL 的摘要说明
    /// </summary>
    public class quanALL : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //int index = Convert.ToInt32(context.Request["rows"]);
            //int rows = Convert.ToInt32(context.Request["page"]);
            //context.Response.Write("{\"total\":" + GroupManager.xuanzong() + ",\"rows\":" + JsonConvert.SerializeObject(GroupManager.xuan(index, rows)) + "}");
            context.Response.Write(JsonConvert.SerializeObject(GroupManager.xuan()));
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