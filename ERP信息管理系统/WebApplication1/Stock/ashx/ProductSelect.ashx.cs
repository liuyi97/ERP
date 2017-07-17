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
    /// ProductSelect 的摘要说明
    /// </summary>
    public class ProductSelect : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int count = Convert.ToInt32(context.Request["rows"].ToString());
            int index = Convert.ToInt32(context.Request["page"].ToString());
            List<addorder> list = ProductDetailSelect.GetProductSel(count, index);
            context.Response.Write("{\"total\":\"" + ProductDetailSelect.GetProductSum().ToString() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
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