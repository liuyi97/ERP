using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.SysModel;
using BLL.SysBLL;
using Newtonsoft.Json;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// ProductsBrandUpdate 的摘要说明
    /// </summary>
    public class ProductsBrandUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["BrandName"] != null)
            {
                ProductsBrand s = new ProductsBrand();
                s.BrandID = Convert.ToInt32(context.Request["BrandID"]);
                s.BrandName = context.Request["BrandName"];
                s.State = context.Request["State"];
                s.Description = context.Request["Description"];
                context.Response.Write(ProductsBrandManager.ProductsBrandUpdate(s) > 0);
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