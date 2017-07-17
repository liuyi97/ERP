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
    /// UserID 的摘要说明
    /// </summary>
    public class UserID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["name"] != null)
            {
                context.Response.Write(JsonConvert.SerializeObject(UserManager.UserID(context.Request["name"])));
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