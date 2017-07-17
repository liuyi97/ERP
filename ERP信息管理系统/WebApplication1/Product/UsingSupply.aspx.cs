using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;
namespace WebApplication1.Product
{
    public partial class UsingSupply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DLSupply.DataSource = BLL.PIntoBLL.ProIntoManager.SelectSupply();
            this.DLSupply.DataBind();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            this.DLSupply.DataSource = BLL.PIntoBLL.ProIntoManager.MohuCheckSupply(this.txtCus.Text);
            this.DLSupply.DataBind();
        }
    }
}