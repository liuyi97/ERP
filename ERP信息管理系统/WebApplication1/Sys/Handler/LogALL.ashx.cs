using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.SysBLL;
using Newtonsoft.Json;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// LogALL 的摘要说明
    /// </summary>
    public class LogALL : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = Convert.ToInt32(context.Request["rows"]);
            int rows = Convert.ToInt32(context.Request["page"]);
            context.Response.Write("{\"total\":" + NoticeManager.LogZong()+ ",\"rows\":" + JsonConvert.SerializeObject(NoticeManager.LogAll(index,rows)) + "}");
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