using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.SysModel;
using BLL.SysBLL;
using System.Data;
using Newtonsoft.Json;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// Productserji 的摘要说明
    /// </summary>
    public class Productserji : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(JsonConvert.SerializeObject(ProductsManager.ProductserjiList(Convert.ToInt32(context.Request["id"]))));
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