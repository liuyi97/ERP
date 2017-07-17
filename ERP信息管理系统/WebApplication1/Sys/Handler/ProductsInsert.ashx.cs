using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.SysModel;
using BLL.SysBLL;

namespace WebApplication1.Sys.Handler
{
    /// <summary>
    /// ProductsInsert 的摘要说明
    /// </summary>
    public class ProductsInsert : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["ProductsName"] != "" && context.Request["TypeID"] != "" && context.Request["BrandID"] != "" && context.Request["Cost"] != "")
            {
                Products s = new Products();
                s.ProductsName=context.Request["ProductsName"];
                s.TypeID=Convert.ToInt32(context.Request["TypeID"]);
                s.BrandID=Convert.ToInt32(context.Request["BrandID"]);
                s.Color=context.Request["Color"];
                s.ProductsUints=context.Request["ProductsUints"];
                s.Cost=Convert.ToInt32(context.Request["Cost"]);
                s.Weight=context.Request["Weight"];
                if (context.Request["Price"] == "")
                {
                    s.Price = 0;
                }
                else { 
                  s.Price=Convert.ToDouble(context.Request["Price"]);
                }
                
                s.Spec=context.Request["Spec"];
                s.Material=context.Request["Material"];
                if (context.Request["UpperLimit"] == "")
                {
                    s.UpperLimit = 0;
                }
                else {
                    s.UpperLimit = Convert.ToInt32(context.Request["UpperLimit"]);
                }
                if (context.Request["LowerLimit"] == "")
                {
                    s.LowerLimit = 0;
                }
                else
                {
                    s.LowerLimit = Convert.ToInt32(context.Request["LowerLimit"]);
                }
                //s.LowerLimit=Convert.ToInt32(context.Request["LowerLimit"]);
                s.BeginEnterDate = context.Request["BeginEnterDate"];
                s.FinalEnterDate = context.Request["FinalEnterDate"];
                s.LoadingDate = context.Request["LoadingDate"];
                s.LatelyOFSDate = context.Request["LatelyOFSDate"];
                s.UnshelveDate = context.Request["UnshelveDate"];
                s.Description = context.Request["Description"];
                context.Response.Write(ProductsManager.ProductsInsert(s)>0);
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