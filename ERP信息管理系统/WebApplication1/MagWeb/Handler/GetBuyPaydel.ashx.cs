using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.MagBLL;

namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// GetBuyPaydel 的摘要说明
    /// </summary>
    public class GetBuyPaydel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string con = context.Request["getid"];
            string D = con.Substring(0, con.LastIndexOf(","));
            bool rows = t_BuyPayManages.Getbuypaydel(D);
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