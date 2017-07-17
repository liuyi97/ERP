using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.MagBLL;

namespace WebApplication1.MagWeb
{
    public partial class Main_Right_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["id"]);
            Repeater1.DataSource = t_NoticeManages.getid(id);
            Repeater1.DataBind();
        }
    }
}