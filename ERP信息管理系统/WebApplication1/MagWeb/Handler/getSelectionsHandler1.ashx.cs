using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// getSelectionsHandler1 的摘要说明
    /// </summary>
    public class getSelectionsHandler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string con = context.Request["getid"];

            string D = con.Substring(0, con.LastIndexOf(","));


            bool rows = t_BuyOrderManages.getbuyid(D);
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