using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using BLL;
using Newtonsoft.Json;

namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// t_BuyOrderHandler1 的摘要说明
    /// </summary>
    public class t_BuyOrderHandler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = int.Parse(context.Request["page"]);
            int count = int.Parse(context.Request["rows"]);
            context.Response.Write("{\"total\":" + t_BuyOrderManages.Getcount() +
                ",\"rows\":" + JsonConvert.SerializeObject(t_BuyOrderManages.GetEmp(index, count)) + "}");
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