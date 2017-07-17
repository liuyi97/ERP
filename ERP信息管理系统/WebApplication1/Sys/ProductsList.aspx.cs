using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.SysModel;
using BLL.SysBLL;

namespace WebApplication1.Sys
{
    public partial class ProductsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                int id = Convert.ToInt32(Request["id"]);
                this.Repeater1.DataSource = ProductsManager.ProductsID(id);
                this.Repeater1.DataBind();
            }
        }
    }
}