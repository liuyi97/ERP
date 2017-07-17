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
    /// adminSale 的摘要说明
    /// </summary>
    public class adminSale : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int count = Convert.ToInt32(context.Request["rows"].ToString());
            int index = Convert.ToInt32(context.Request["page"].ToString());
            string saleid = context.Request["saleid"].ToString();
            int statename = Convert.ToInt32(context.Request["statename"].ToString());
            string create = context.Request["create"].ToString();
            string tradetime = context.Request["tradetime"].ToString();
            if (saleid != "" && create == "" && tradetime == "" && statename == null)
            {
                List<addorder> list = adminSaleManager.GetSe(count,index,saleid);
                context.Response.Write("{\"total\":\"" + adminSaleManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (saleid == "" && create != "" && tradetime != "" && statename == null)
            {
                List<addorder> list = adminSaleManager.GetSel(count, index, create, tradetime);
                context.Response.Write("{\"total\":\"" + adminSaleManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (saleid == "" && create == "" && tradetime == "" && statename != null)
            {
                List<addorder> list = adminSaleManager.GetS(count, index, statename);
                context.Response.Write("{\"total\":\"" + adminSaleManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (saleid != "" && create != "" && tradetime != "" && statename == null)
            {
                List<addorder> list = adminSaleManager.GetSele(count, index, saleid, create, tradetime);
                context.Response.Write("{\"total\":\"" + adminSaleManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (saleid != "" && create == "" && tradetime == "" && statename != null)
            {
                List<addorder> list = adminSaleManager.GetSelec(count, index, saleid, statename);
                context.Response.Write("{\"total\":\"" + adminSaleManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else if (saleid == "" && create != "" && tradetime != "" && statename != null)
            {
                List<addorder> list = adminSaleManager.GetSelectd(count, index, create, tradetime, statename);
                context.Response.Write("{\"total\":\"" + adminSaleManager.GetHang() + "\",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
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