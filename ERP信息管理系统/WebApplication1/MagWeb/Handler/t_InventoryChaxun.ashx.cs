using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.MagBLL;
using Newtonsoft.Json;

namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// t_InventoryChaxun 的摘要说明
    /// </summary>
    public class t_InventoryChaxun : IHttpHandler
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
            if (begin == "" && end == "" && orderid != "" && (receorderid == 1 || receorderid == 2 || receorderid == 0))
            {
                context.Response.Write("{\"total\":" + t_InventoryManages.t_InventoryGetidcount(index, count, orderid) +
                ",\"rows\":" + JsonConvert.SerializeObject(t_InventoryManages.t_InventoryGetid(index, count, orderid)) + "}");
            }
            else if (begin == "" && end == "" && orderid == "" && receorderid == 1 || receorderid == 2 || receorderid == 0)
            {
                context.Response.Write("{\"total\":" + t_InventoryManages.t_InventoryDataidcount(index, count, receorderid) +
            ",\"rows\":" + JsonConvert.SerializeObject(t_InventoryManages.t_InventoryDataid(index, count, receorderid)) + "}");
            }
            else if (begin != "" && end != "" && (receorderid == 1 || receorderid == 2 || receorderid == 0))
            {
                context.Response.Write("{\"total\":" + t_InventoryManages.t_Inventorybegincount(index, count, begin, end) +
          ",\"rows\":" + JsonConvert.SerializeObject(t_InventoryManages.t_Inventorybegin(index, count, begin, end)) + "}");
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