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
    /// Delete 的摘要说明
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string outid = context.Request["outid"].ToString();
            string ios = outid.Substring(0, outid.LastIndexOf(','));
            bool rows = AdminsalePManager.GetDelete(ios);
            bool row = AdminsalePManager.GetDelete1(ios);
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