using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.MagBLL;
using Newtonsoft.Json;

namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// t_BuyReturnHandler 的摘要说明
    /// </summary>
    public class t_BuyReturnHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string orderid = context.Request["getid"].Trim();
            string begin = context.Request["begin"];
            string end = context.Request["end"];
            int receorderid = Convert.ToInt32(context.Request["deataid"]);
            int index = int.Parse(context.Request["page"]);
            int count = int.Parse(context.Request["rows"]);
            if (orderid == "" || begin == "" || end == "")
            {
                context.Response.Write("{\"total\":" + t_BuyReturnManages.Getcount() +
                ",\"rows\":" + JsonConvert.SerializeObject(t_BuyReturnManages.getReturninfoorid(index, count, orderid, begin, end, receorderid)) + "}");
            }
            else if (orderid != "" && begin != "" && end != "")
            {
                context.Response.Write("{\"total\":" + t_BuyReturnManages.Getcount() +
            ",\"rows\":" + JsonConvert.SerializeObject(t_BuyReturnManages.getReturninfoandid(index, count, orderid, begin, end, receorderid)) + "}");
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