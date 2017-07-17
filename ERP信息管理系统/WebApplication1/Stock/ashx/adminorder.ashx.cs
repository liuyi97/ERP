using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model.NewFolder1;
using BLL.NewFolder1;
using Newtonsoft.Json;

namespace WebApplication1.Stock.ashx
{
    /// <summary>
    /// adminorder 的摘要说明
    /// </summary>
    public class adminorder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //采购订单管理
            string BuyOrderID = context.Request["BuyOrderID"].ToString();
            string BuyOrderDate = context.Request["BuyOrderDate"].ToString();
            string TradeDate = context.Request["TradeDate"].ToString();
            string statename = context.Request["statename"].ToString();
            int count = Convert.ToInt32(context.Request["rows"].ToString());
            int index = Convert.ToInt32(context.Request["page"].ToString());
            if (BuyOrderID != null && BuyOrderDate != null && TradeDate != null)
            {
                List<addorder> list = adminorderManager.GetAdmin(BuyOrderID, BuyOrderDate, TradeDate, statename, count, index);
                context.Response.Write("{\"total\":\"" + adminorderManager.GetCount().ToString() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (BuyOrderID != null || BuyOrderDate != null || TradeDate != null)
            {
                List<addorder> list = adminorderManager.GetAdminAll(BuyOrderID, BuyOrderDate, TradeDate, statename, count, index);
                context.Response.Write("{\"total\":\"" + adminorderManager.GetCount().ToString() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
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