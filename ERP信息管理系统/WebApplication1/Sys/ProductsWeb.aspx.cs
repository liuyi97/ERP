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
    public partial class ProductsWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.DropDownList2.DataSource = ProductsManager.ProductsBrandDrop();
                this.DropDownList2.DataValueField = "BrandID";
                this.DropDownList2.DataTextField = "BrandName";
                this.DropDownList2.DataBind();
                this.DropDownList1.DataSource = ProductsManager.ProductsTypeDrop();
                this.DropDownList1.DataValueField = "TypeID";
                this.DropDownList1.DataTextField = "TypeName";
                this.DropDownList1.DataBind();
            }
        }
    }
}