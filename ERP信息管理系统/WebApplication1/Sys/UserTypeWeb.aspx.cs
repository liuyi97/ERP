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
    public partial class UserTypeWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DropDownList1.DataSource = UserTypeManager.UserTypeDrop();
                this.DropDownList1.DataTextField = "TypeName";
                this.DropDownList1.DataValueField = "UserTypeID";
                this.DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != null)
            {
                UserType s = new UserType();
                s.SubClassName = this.TextBox1.Text;
                s.UserTypeID = Convert.ToInt32(this.DropDownList1.SelectedValue);
                //s.State = this.DropDownList2.Text;
                if (this.DropDownList2.Text == "正常")
                {
                    s.State = "Y";
                }
                else
                {
                    s.State = "N";
                }
                int rows =  UserTypeManager.UserTypeInsert(s);
                if (rows > 0)
                {
                    Response.Write("<script>alert('添加成功！');</script>");
                    this.DropDownList1.SelectedIndex = 1;
                    this.TextBox1.Text = "";
                    this.DropDownList2.Text = "正常";
                }
                else
                {
                    Response.Write("<script>alert('添加失败！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('类型名称不能为空！');</script>");
            }
        }
    }
}