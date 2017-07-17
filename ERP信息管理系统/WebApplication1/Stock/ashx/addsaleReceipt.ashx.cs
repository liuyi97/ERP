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
    /// addsaleReceipt 的摘要说明
    /// </summary>
    public class addsaleReceipt : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            addorder ad = new addorder();
            ad.ReceiptOrderID = context.Request["ReceiptOrderID"].ToString();
            ad.ReceiptOrderDate = context.Request["ReceiptOrderDate"].ToString();
            ad.BuyOrderID = context.Request["BuyOrderID"].ToString();
            ad.StoreHouseID = Convert.ToInt32(context.Request["StoreHouseID"].ToString());
            ad.HouseDetailID = Convert.ToInt32(context.Request["HouseDetailID"].ToString());
            ad.TradeDate = context.Request["TradeDate"].ToString();
            ad.userName = context.Request["UserName"].ToString();
            ad.Description = context.Request["Description"].ToString();
            ad.TotalPrice = context.Request["TotalPrice"].ToString();
            ad.State = context.Request["State"].ToString();
            bool rows = SaleInManager.GetSale(ad);
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