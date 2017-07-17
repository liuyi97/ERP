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
    /// ProductsTypeDrop 的摘要说明
    /// </summary>
    public class ProductsTypeDrop : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(JsonConvert.SerializeObject(ProductsManager.ProductsTypeDrop()));
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