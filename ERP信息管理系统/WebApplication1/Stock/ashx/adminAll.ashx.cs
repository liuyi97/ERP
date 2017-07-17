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
    /// adminAll 的摘要说明
    /// </summary>
    public class adminAll : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int count = Convert.ToInt32(context.Request["rows"].ToString());
            int index = Convert.ToInt32(context.Request["page"].ToString());
            string outid = context.Request["outid"].ToString();
            int statename = Convert.ToInt32(context.Request["statename"].ToString());
            string create = context.Request["create"].ToString();
            string tradetime = context.Request["tradetime"].ToString();
            if (outid != "" && create == "" && tradetime == "" && statename == null)
            {
                List<addorder> list = AdminsalePManager.GetSe(count, index, outid);
                context.Response.Write("{\"total\":\"" + AdminsalePManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (outid == "" && create != "" && tradetime != "" && statename == null)
            {
                List<addorder> list = AdminsalePManager.GetSel(count, index, create, tradetime);
                context.Response.Write("{\"total\":\"" + AdminsalePManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (outid == "" && create == "" && tradetime == "" && statename != null)
            {
                List<addorder> list = AdminsalePManager.GetS(count, index, statename);
                context.Response.Write("{\"total\":\"" + AdminsalePManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (outid != "" && create != "" && tradetime != "" && statename == null)
            {
                List<addorder> list = AdminsalePManager.GetSele(count, index, outid, create, tradetime);
                context.Response.Write("{\"total\":\"" + AdminsalePManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (outid != "" && create == "" && tradetime == "" && statename != null)
            {
                List<addorder> list = AdminsalePManager.GetSelec(count, index, outid, statename);
                context.Response.Write("{\"total\":\"" + AdminsalePManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (outid == "" && create != "" && tradetime != "" && statename != null)
            {
                List<addorder> list = AdminsalePManager.GetSelectd(count, index, create, tradetime, statename);
                context.Response.Write("{\"total\":\"" + AdminsalePManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
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