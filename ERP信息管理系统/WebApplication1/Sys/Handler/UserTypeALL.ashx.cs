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
    /// UserTypeALL 的摘要说明
    /// </summary>
    public class UserTypeALL : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = Convert.ToInt32(context.Request["rows"]);
            int rows = Convert.ToInt32(context.Request["page"]);
            context.Response.Write("{\"total\":" + UserTypeManager.UserTypezong() + ",\"rows\":" + JsonConvert.SerializeObject(UserTypeManager.UserTypeALL(index, rows)) + "}");
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