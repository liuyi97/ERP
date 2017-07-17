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
    /// salereturn 的摘要说明
    /// </summary>
    public class salereturn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            addorder ad = new addorder();
            ad.BuyReturnID = context.Request["BuyReturnID"].ToString();
            ad.BuyReturnDate = context.Request["BuyReturnDate"].ToString();
            ad.StoreHouseID = Convert.ToInt32(context.Request["StoreHouseID"].ToString());
            ad.HouseDetailID = Convert.ToInt32(context.Request["HouseDetailID"].ToString());
            ad.ReceiptOrderID = context.Request["ReceiptOrderID"].ToString();
            ad.userName = context.Request["userName"].ToString();
            ad.TradeDate = context.Request["TradeDate"].ToString();
            ad.TotalPrice = context.Request["TotalPrice"].ToString();
            ad.AlreadyPay = context.Request["AlreadyPay"].ToString();
            ad.Description = context.Request["Description"].ToString();
            ad.State = context.Request["State"].ToString();
            bool rows = salereturnManager.GetALL(ad);
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