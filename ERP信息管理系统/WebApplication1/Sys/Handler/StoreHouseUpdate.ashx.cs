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
    /// StoreHouseUpdate 的摘要说明
    /// </summary>
    public class StoreHouseUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["housename"] != null) {
                StoreHouse s = new StoreHouse();
                s.HouseID = Convert.ToInt32(context.Request["houseid"]);
                s.HouseName = context.Request["housename"];
                s.Description = context.Request["Description"];
                context.Response.Write(StoreHouseManager.StoreHouseUpdate(s)>0);
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