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
    public partial class ProductsFiledWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = Request["id"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.FileUpload1.HasFiles) {
                string filename = this.FileUpload1.FileName;
                string name = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
                if (name != "jpg" && name != "jpeg" && name != "png" && name != "gif")
                {
                    Response.Write("<script>alert('图片的格式不正确！');</script>");
                }
                else {
                    this.FileUpload1.SaveAs(Server.MapPath("../images/") + filename);
                    this.Image1.ImageUrl = "../images/" + filename;
                    Products p = new Products();
                    p.ProductsID =Convert.ToInt32(Request["id"].ToString());
                    p.PhotoUrl = filename;
                    int rows = ProductsManager.ProductsTuPianUpdate(p);
                    if (rows > 0)
                    {
                        Response.Write("<script>alert('添加成功！');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败！');</script>");
                    }
                }
            }
        }
    }
}