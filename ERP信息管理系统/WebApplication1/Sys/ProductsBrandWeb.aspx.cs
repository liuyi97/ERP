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
    public partial class ProductsBrandWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != null)
            {
                ProductsBrand s = new ProductsBrand();
                s.BrandName = this.TextBox1.Text;
                s.Description = this.TextBox2.Text;
                //s.State = this.DropDownList2.Text;
                if (this.DropDownList1.Text == "正常")
                {
                    s.State = "Y";
                }
                else
                {
                    s.State = "N";
                }
                int rows = ProductsBrandManager.ProductsBrandInsert(s);
                if (rows > 0)
                {
                    Response.Write("<script>alert('添加成功！');</script>");
                    this.TextBox1.Text = "";
                    this.TextBox2.Text = "";
                    this.DropDownList1.Text = "正常";
                }
                else
                {
                    Response.Write("<script>alert('添加失败！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('品牌名称不能为空！');</script>");
            }
        }
    }
}