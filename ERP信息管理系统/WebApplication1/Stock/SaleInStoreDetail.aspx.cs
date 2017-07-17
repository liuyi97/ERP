using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.NewFolder1;
using System.Data;
using Model.NewFolder1;
namespace WebApplication1.Stock
{
    public partial class SaleInStoreDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                All();
                Store();
                House();
            }
        }
        //接收id
        public void All()
        {
            string id = Request["id"].ToString();
            DataTable dt = SaleInManager.GetSaleDetail(id);
            this.TextBox1.Text = dt.Rows[0]["ReceiptOrderID"].ToString();
            this.TextBox8.Text = dt.Rows[0]["ReceiptOrderDate"].ToString();
            this.TextBox2.Text = dt.Rows[0]["UserName"].ToString();
            this.TextBox5.Text = dt.Rows[0]["TotalPrice"].ToString();
            this.TextBox6.Text = dt.Rows[0]["StateName"].ToString();
            this.TextBox9.Text = dt.Rows[0]["TradeDate"].ToString();
            this.TextBox7.Text = dt.Rows[0]["Description"].ToString();
        }
        //通过入库单号查询显示库房
        public void Store()
        {
            string id = Request["id"].ToString();
            DataTable dt = SaleInManager.GetSaleStore(id);
            this.DropDownList1.DataSource = dt;
            this.DropDownList1.DataTextField = "HouseName";
            this.DropDownList1.DataValueField = "HouseID";
            this.DropDownList1.DataBind();
        }
        //通过订单编号和库房，显示库区
        public void House()
        {
            string id = Request["id"].ToString();
            int store = Convert.ToInt32(this.DropDownList1.SelectedValue);
            DataTable dt = SaleInManager.GetSaleHouse(id, store);
            this.DropDownList2.DataSource = dt;
            this.DropDownList2.DataTextField = "SubareaName";
            this.DropDownList2.DataValueField = "ID";
            this.DropDownList2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            House();
        }
    }
}