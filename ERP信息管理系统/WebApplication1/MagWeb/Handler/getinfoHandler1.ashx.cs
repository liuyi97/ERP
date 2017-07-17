using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using Newtonsoft.Json;
using BLL.MagBLL;


namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// getinfoHandler1 的摘要说明
    /// </summary>
    public class getinfoHandler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = int.Parse(context.Request["page"]);
            int count = int.Parse(context.Request["rows"]);
            context.Response.Write("{\"total\":" + t_BuyReceiptManages.Getcount() +
                ",\"rows\":" + JsonConvert.SerializeObject(t_BuyReceiptManages.getinfobuyreceipt(index, count)) + "}");
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