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
    /// UserleiDrop 的摘要说明
    /// </summary>
    public class UserleiDrop : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(JsonConvert.SerializeObject(UserManager.leiDrop()));
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