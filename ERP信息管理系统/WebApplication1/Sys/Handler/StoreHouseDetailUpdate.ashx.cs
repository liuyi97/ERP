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
    /// StoreHouseDetailUpdate 的摘要说明
    /// </summary>
    public class StoreHouseDetailUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["SubareaName"] != null)
            {
                StoreHouseDetail s = new StoreHouseDetail();
                s.ID = Convert.ToInt32(context.Request["id"]);
                s.HouseID = Convert.ToInt32(context.Request["houseid"]);
                s.Description = context.Request["Description"];
                s.SubareaName = context.Request["SubareaName"];
                s.State = context.Request["State"];
                context.Response.Write(StoreHouseDetailManager.StoreHouseDetailUpdate(s) > 0);
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