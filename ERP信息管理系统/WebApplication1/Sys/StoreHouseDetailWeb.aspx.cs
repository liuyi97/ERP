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
    public partial class StoreHouseDetailWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.DropDownList1.DataSource = StoreHouseDetailManager.StoreHouseDetailDrop();
                this.DropDownList1.DataTextField = "HouseName";
                this.DropDownList1.DataValueField = "HouseID";
                this.DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != null)
            {
                StoreHouseDetail s = new StoreHouseDetail();
                s.SubareaName = this.TextBox1.Text;
                s.HouseID =Convert.ToInt32(this.DropDownList1.SelectedValue);
                s.Description = this.TextBox2.Text;
                //s.State = this.DropDownList2.Text;
                if (this.DropDownList2.Text == "正常")
                {
                    s.State = "Y";
                }
                else {
                    s.State = "N";
                }
                int rows = StoreHouseDetailManager.StoreHouseDetailInsert(s);
                if (rows > 0)
                {
                    Response.Write("<script>alert('添加成功！');</script>");
                    this.DropDownList1.SelectedIndex = 1;
                    this.TextBox1.Text = "";
                    this.TextBox2.Text = "";
                    this.DropDownList2.Text = "正常";
                }
                else
                {
                    Response.Write("<script>alert('添加失败！');</script>");
                }
            }
            else {
                Response.Write("<script>alert('库区名称不能为空！');</script>");
            }
        }
    }
}