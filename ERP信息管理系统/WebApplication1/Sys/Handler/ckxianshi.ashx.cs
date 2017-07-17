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
    /// ckxianshi 的摘要说明
    /// </summary>
    public class ckxianshi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["groupid"] != "") {
                context.Response.Write(JsonConvert.SerializeObject(GroupManager.ckxuan(Convert.ToInt32(context.Request["groupid"]))));
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