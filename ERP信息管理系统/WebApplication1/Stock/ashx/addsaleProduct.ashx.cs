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
    /// addsaleProduct 的摘要说明
    /// </summary>
    public class addsaleProduct : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            addorder ad = new addorder();
            ad.ProductsID = Convert.ToInt32(context.Request["ProductsID"].ToString());
            ad.Price = context.Request["Price"].ToString();
            ad.Quantity = Convert.ToInt32(context.Request["Quantity"].ToString());
            ad.TaxRate = context.Request["TaxRate"].ToString();
            ad.DiscountRate = context.Request["DiscountRate"].ToString();
            ad.SupplierID = context.Request["SupplierID"].ToString();
            ad.Description = context.Request["Description"].ToString();
            ad.ReceiptOrderID = context.Request["ReceiptOrderID"].ToString();
            bool rows = SaleInManager.insertProduct(ad);
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