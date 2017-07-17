using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.MagBLL;
namespace WebApplication1.MagWeb.Handler
{
    /// <summary>
    /// t_TransferringOrdersheng 的摘要说明
    /// </summary>
    public class t_TransferringOrdersheng : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string con = context.Request["getid"];

            string D = con.Substring(0, con.LastIndexOf(","));


            bool rows = t_TransferringOrderManages.updatedate(D);
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