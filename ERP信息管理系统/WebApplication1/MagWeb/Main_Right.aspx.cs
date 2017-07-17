using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.MagBLL;

namespace WebApplication1.MagWeb
{
    public partial class Main_Right : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                repabind();
                repbbind();
                repcbind();
            }
        }
        public void repabind()
        {
            Repeater1.DataSource = t_NoticeManages.geta();
            Repeater1.DataBind();
        }
        public void repbbind()
        {
            Repeater2.DataSource = t_NoticeManages.getb();
            Repeater2.DataBind();
        }
        public void repcbind()
        {
            Repeater3.DataSource = t_NoticeManages.getc();
            Repeater3.DataBind();
        }
    }
}