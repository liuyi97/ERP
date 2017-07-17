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
    /// GroupUpdate 的摘要说明
    /// </summary>
    public class GroupUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["groupname"] != null)
            {
                Group s = new Group();
                s.GroupID = Convert.ToInt32(context.Request["groupid"]);
                s.GroupName = context.Request["groupname"];
                s.Description = context.Request["Description"];
                context.Response.Write(GroupManager.GroupUpdate(s) > 0);
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