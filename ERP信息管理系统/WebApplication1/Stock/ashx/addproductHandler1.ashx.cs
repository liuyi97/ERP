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
    /// addproductHandler1 的摘要说明
    /// </summary>
    public class addproductHandler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            addorder add = new addorder();
            add.ProductsID = Convert.ToInt32(context.Request["ProductsID"].ToString());
            add.Price = context.Request["Price"].ToString();
            add.Quantity = Convert.ToInt32(context.Request["Quantity"].ToString());
            add.TaxRate = context.Request["TaxRate"].ToString();
            add.DiscountRate = context.Request["DiscountRate"].ToString();
            add.SupplierID = context.Request["SupplierID"].ToString();
            add.Description = context.Request["Description"].ToString();
            add.BuyOrderID = context.Request["BuyOrderID"].ToString();
            bool rows = addorderManages.AddProduct(add);
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