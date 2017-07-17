using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using BLL.MagBLL;

namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// t_BuyPayHandler1 的摘要说明
    /// </summary>
    public class t_BuyPayHandler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = int.Parse(context.Request["page"]);
            int count = int.Parse(context.Request["rows"]);
            context.Response.Write("{\"total\":" + t_BuyPayManages.Getcount() +
                ",\"rows\":" + JsonConvert.SerializeObject(t_BuyPayManages.GetEmp(index, count)) + "}");
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