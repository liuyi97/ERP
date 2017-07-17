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
    /// UserTypeUpdate 的摘要说明
    /// </summary>
    public class UserTypeUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["SubClassName"] != null)
            {
                UserType s = new UserType();
                s.SubClassID = Convert.ToInt32(context.Request["id"]);
                s.UserTypeID = Convert.ToInt32(context.Request["UserTypeID"]);
                s.SubClassName = context.Request["SubClassName"];
                s.State = context.Request["State"];
                context.Response.Write(UserTypeManager.UserTypeUpdate(s) > 0);
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