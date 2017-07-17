using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models.ProductOut;
namespace WebApplication1.Product
{
    public partial class ProductOutHouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserName"] = "huhai123";
                //查询数据库的 入库类型 + 绑定
                this.DDLIntoType.DataSource = BLL.PIntoBLL.ProIntoManager.IntoHouseType();
                this.DDLIntoType.DataTextField = "TypeName";
                this.DDLIntoType.DataValueField = "TypeID";
                this.DDLIntoType.DataBind();
                //自动生成订单编号
                OT();
                //自动生成下单日期
                this.txtMakeDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }
        //随机生成订单编号
        public void OT()
        {
            string orderid = "OT";
            Random ra = new Random();
            string sui = Convert.ToString(ra.Next(00000000, 99999999));
            string ordernumber = string.Format("{0}{1}{2}", orderid, DateTime.Now.ToString("yyyyMMdd"), sui);
            this.txtOrderID.Text = ordernumber;
        }


        //生成入库订单
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //1.获取数据发送到DAL
            //2.p判断返回值，是否新增成功
            //3.把按钮隐藏
            this.btnCreate.Visible = false;
            //4.显示panel
            //this.Panel1.Visible = true;

            SaveOutMessage s = new SaveOutMessage();
            s.OutID = this.txtOrderID.Text;
            s.CreateDate = this.txtMakeDate.Text;
            s.OutType = int.Parse(this.DDLIntoType.SelectedValue);
            s.StoreHouseID = int.Parse(this.txtHouse.Text);
            s.HouseDetailID = int.Parse(this.txtArea.Text);
            s.UserName = Session["UserName"].ToString();//当前登录人的名字
            s.TradeDate = this.DateTime1.Value;//选择日期
            s.AlreadyPay = Convert.ToDouble(this.txtPay.Text);
            s.Description = this.txtDec.Text;
            bool b = BLL.POutBLL.POutManager.SaveAllOut(s);
            if (b)
            {
                //显示下面的表格
            }
        }
        //点击保存 保存信息
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveOutDetail save = new SaveOutDetail();
            save.OutID = this.txtOrderID.Text;
            save.ProductsID = int.Parse(this.ProID.Text);
            save.ProductsName = this.txtPro.Text;
            //save.SupplierID = BLL.PIntoBLL.ProIntoManager.GetSupplierID(this.txtSupply.Text);
            save.Quantity = int.Parse(this.txtCount.Text);
            save.Price = Convert.ToDouble(this.txtPrice.Text);
            save.Total = Convert.ToDouble(this.txtPrice.Text) * int.Parse(this.txtCount.Text);
            if (BLL.POutBLL.POutManager.AddMessage(save))
            {
                this.GridViewMessage.DataSource = BLL.POutBLL.POutManager.CheckGridView(save.OutID);
                this.GridViewMessage.DataBind();
            }
            else
            {
                Response.Write("<script>alert('添加信息失败')</script>");
            }
        }
        ////GridView删除功能
        //protected void GridViewMessage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    BLL.PIntoBLL.ProIntoManager.DeletProIntoMessage(Convert.ToInt32(e.Values["ID"]));
        //    this.GridViewMessage.DataSource = BLL.PIntoBLL.ProIntoManager.CheckGridView(this.txtOrderID.Text);
        //    this.GridViewMessage.DataBind();
        //}

        //点击完成所有 跳转到出库明细
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            //总价
            double total = 0;
            //循环添加总价
            foreach (GridViewRow item in this.GridViewMessage.Rows)
            {
                total += Convert.ToDouble(item.Cells[4].Text);
            }

            string OutID = this.txtOrderID.Text;
            BLL.POutBLL.POutManager.updateCountTotal(OutID, total);

            Response.Redirect("OutDetail.aspx?OutID=" + OutID);
        }

        //点击删除该单 实现删除功能
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.POutBLL.POutManager.DeleteMain(this.txtOrderID.Text);
            BLL.POutBLL.POutManager.DeleteSon(this.txtOrderID.Text);
            Response.Redirect("ProIntoHouse.aspx");
        }
    }
}
