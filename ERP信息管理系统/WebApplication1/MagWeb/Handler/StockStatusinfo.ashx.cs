﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.MagBLL;
using Models;
using Newtonsoft.Json;

namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// StockStatusinfo 的摘要说明
    /// </summary>
    public class StockStatusinfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = int.Parse(context.Request["page"]);
            int count = int.Parse(context.Request["rows"]);
            context.Response.Write("{\"total\":" + StockStatusManages.StockStatuscount() +
                ",\"rows\":" + JsonConvert.SerializeObject(StockStatusManages.StockStatusinfo(index, count)) + "}");
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