using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
namespace UI
{
    public partial class index : System.Web.UI.Page
    { 
       
        protected void Page_Load(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(Session["typeid"]);
            repabinda(a);
            repabindc(a);
            repabindb(a);
            repabindd(a);
            Label1.Text = Session["username"].ToString();
            Label1.Visible = true;
        }
        public void repabinda(int a)
        {
            Repeater1.DataSource = t_AuthorityManages.getindexa(a);
            Repeater1.DataBind();
        }
        public void repabindb(int a)
        {
            Repeater2.DataSource = t_AuthorityManages.getindexb(a);
            Repeater2.DataBind();
        }
        public void repabindc(int a)
        {
            Repeater3.DataSource = t_AuthorityManages.getindexc(a);
            Repeater3.DataBind();
        }
        public void repabindd(int a)
        {
            Repeater4.DataSource = t_AuthorityManages.getindexd(a);
            Repeater4.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove(Session["username"].ToString());
        }
    }
}