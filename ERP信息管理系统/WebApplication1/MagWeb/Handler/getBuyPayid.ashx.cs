using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.MagBLL;
using Newtonsoft.Json;

namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// getBuyPayid 的摘要说明
    /// </summary>
    public class getBuyPayid : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string orderid = context.Request["getid"];
            string begin = context.Request["begin"];
            string end = context.Request["end"];
            int dataid = Convert.ToInt32(context.Request["deataid"]);
            int index = int.Parse(context.Request["page"]);
            int count = int.Parse(context.Request["rows"]);
            if (orderid == "" || begin == "" || end == "")
            {
                context.Response.Write("{\"total\":" + t_BuyPayManages.Getcountnotid(index, count, orderid, begin, end, dataid) +
                ",\"rows\":" + JsonConvert.SerializeObject(t_BuyPayManages.getPaybuynotid(index, count, orderid, begin, end, dataid)) + "}");
            }
            else if (orderid != "" && begin != "" && end != "")
            {
                context.Response.Write("{\"total\":" + t_BuyPayManages.Getcountid(index, count, orderid, begin, end, dataid) +
            ",\"rows\":" + JsonConvert.SerializeObject(t_BuyPayManages.getPaybuyid(index, count, orderid, begin, end, dataid)) + "}");
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