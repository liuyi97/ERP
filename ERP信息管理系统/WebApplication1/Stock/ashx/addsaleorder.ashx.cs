using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.NewFolder1;
using System.Data;
using BLL.NewFolder1;
using Newtonsoft.Json;

namespace WebApplication1.Stock.ashx
{
    /// <summary>
    /// addsaleorder 的摘要说明
    /// </summary>
    public class addsaleorder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            addorder ad = new addorder();
            ad.BuyOrderID = context.Request["BuyOrderID"].ToString();
            ad.BuyOrderDate = context.Request["BuyOrderDate"].ToString();
            ad.userName = context.Request["userName"].ToString();
            ad.StoreHouseID = Convert.ToInt32(context.Request["StoreHouseID"].ToString());
            ad.HouseDetailID = Convert.ToInt32(context.Request["HouseDetailID"].ToString());
            ad.SignDate = context.Request["SignDate"].ToString();
            ad.TradeDate = context.Request["TradeDate"].ToString();
            ad.TradeAddress = context.Request["TradeAddress"].ToString();
            ad.Description = context.Request["Description"].ToString();
            ad.TotalPrice = context.Request["TotalPrice"].ToString();
            ad.State = context.Request["State"].ToString();
            bool rows = addorderManages.AddSaleorder(ad);
            context.Response.Write(rows);
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