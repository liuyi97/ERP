﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.SysBLL;
using Newtonsoft.Json;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// GroupDelete 的摘要说明
    /// </summary>
    public class GroupDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["id"] != null)
            {
                context.Response.Write( GroupManager.GroupDelete(Convert.ToInt32(context.Request["id"])) > 0);
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