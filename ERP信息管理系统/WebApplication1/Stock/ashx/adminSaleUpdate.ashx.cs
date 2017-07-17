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
    /// adminSaleUpdate 的摘要说明
    /// </summary>
    public class adminSaleUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            addorder ad = new addorder();
            ad.SalesOutID = context.Request["saleid"].ToString();
            ad.State = context.Request["statename"].ToString();
            bool rows = adminSaleManager.GteUpdata(ad);
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