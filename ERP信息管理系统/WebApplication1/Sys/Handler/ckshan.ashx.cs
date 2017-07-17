using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.SysBLL;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// ckshan 的摘要说明
    /// </summary>
    public class ckshan : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["groupid"] != "" && context.Request["AuthorityID"] != "")
            {
                int a = Convert.ToInt32(context.Request["AuthorityID"]);
                int g = Convert.ToInt32(context.Request["groupid"]);
                context.Response.Write(GroupManager.ckshan(a, g)>0);
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