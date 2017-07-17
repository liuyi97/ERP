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
    /// ProductsTypeUpdate 的摘要说明
    /// </summary>
    public class ProductsTypeUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["TypeName"] != null)
            {
                ProductsType s = new ProductsType();
                s.TypeID = Convert.ToInt32(context.Request["TypeID"]);
                s.TypeName = context.Request["TypeName"];
                s.State = context.Request["State"];
                s.Description = context.Request["Description"];
                context.Response.Write(ProductsTypeManager.ProductsTypeUpdate(s) > 0);
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