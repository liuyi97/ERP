using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Models;
namespace WebApplication1.Product
{
    public partial class UsingProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DLProduct.DataSource = BLL.PIntoBLL.ProIntoManager.SelectProduct();
            this.DLProduct.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.DLProduct.DataSource = BLL.PIntoBLL.ProIntoManager.MohuCheckProduct(this.txtPro.Text);
            this.DLProduct.DataBind();
        }
    }
}