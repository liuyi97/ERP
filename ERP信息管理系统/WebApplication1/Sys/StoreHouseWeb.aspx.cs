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
    public partial class StoreHouseWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "")
            {
                StoreHouse s = new StoreHouse();
                s.HouseName = this.TextBox1.Text;
                s.Description = this.TextBox2.Text;
                int rows = StoreHouseManager.StoreHouseInsert(s);
                if (rows > 0)
                {
                    Response.Write("<script>alert('添加成功！');</script>");
                    this.TextBox1.Text = "";
                    this.TextBox2.Text = "";
                }
                else {
                    Response.Write("<script>alert('添加失败！');</script>");
                }
            }
            else {
                Response.Write("<script>alert('库房名称不能为空！');</script>");
            }
        }
    }
}