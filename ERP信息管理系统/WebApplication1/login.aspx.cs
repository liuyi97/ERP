using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;
using BLL.SysBLL;

namespace UI
{
    public partial class backdengllu : System.Web.UI.Page
    {

        t_User s = new t_User();
       
        protected void Page_Load(object sender, EventArgs e)
        {
       


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           Session["username"]= TextBox1.Text;
            Session["password"]= TextBox2.Text;
            Session.Timeout = 1;
            s.UserName = Session["username"].ToString() ;
            s.Password = Session["password"].ToString();
            int row = t_UserManages.getlogin(s);
            if (row > 0)
            {
                Session["typeid"] = t_UserManages.getLoginTypeid(s);
                int a = Convert.ToInt32( Session["typeid"]);

                //日志
                string time=DateTime.Now.ToString();
                string del="用户"+Session["username"].ToString()+":登录进入系统";
                NoticeManager.LogInsert(time,del);


                Response.Redirect("MagWeb/index.aspx");
            }
            else
            {
                Label1.Text = "账号或者密码不正确";
                Label1.Visible = true;

            }
        
       

     


        }
    }
}