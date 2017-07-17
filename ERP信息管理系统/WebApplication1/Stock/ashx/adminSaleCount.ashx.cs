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
    /// adminSaleCount 的摘要说明
    /// </summary>
    public class adminSaleCount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int count = Convert.ToInt32(context.Request["rows"].ToString());
            int index = Convert.ToInt32(context.Request["page"].ToString());
            List<addorder> list = adminSaleManager.GetAll(count, index);
            context.Response.Write("{\"total\":\"" + adminSaleManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
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