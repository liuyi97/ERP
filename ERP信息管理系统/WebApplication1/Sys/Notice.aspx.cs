using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.SysBLL;


namespace WebApplication1.Sys
{
    public partial class Notice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "" && this.TextBox2.Text != "")
            {
                string title = this.TextBox1.Text;
                //string name=Session
                int type=Convert.ToInt32(this.DropDownList1.SelectedValue);
                string time = DateTime.Now.ToString();
                string Info = this.TextBox2.Text;
                string username=Session["username"].ToString();
                int rows = NoticeManager.NoticeInsert(type,title,username,time,Info);
                if (rows > 0)
                {
                    Response.Write("<script>alert('添加成功！');</script>");
                    this.TextBox1.Text = "";
                    this.TextBox2.Text = "";
                    this.DropDownList1.SelectedIndex = 1;
                }
                else
                {
                    Response.Write("<script>alert('添加失败！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('标题、内容不能为空！');</script>");
            }
        }
    }
}