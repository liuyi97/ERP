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
    public partial class GroupWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "")
            {
                Group s = new Group();
                s.GroupName = this.TextBox1.Text;
                s.Description = this.TextBox2.Text;
                int rows = GroupManager.GroupInsert(s);
                if (rows > 0)
                {
                    Response.Write("<script>alert('添加成功！');</script>");
                    this.TextBox1.Text = "";
                    this.TextBox2.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('添加失败！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('群组名称不能为空！');</script>");
            }
        }
    }
}