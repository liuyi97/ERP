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
    /// adminSaleDelete 的摘要说明
    /// </summary>
    public class adminSaleDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string saleid = context.Request["saleid"].ToString();
            string ios = saleid.Substring(0, saleid.LastIndexOf(','));
            bool rows = adminSaleManager.GetDelete(ios);
            bool row = adminSaleManager.GetDelete1(ios);
            context.Response.Write(rows);
            context.Response.Write(row);
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