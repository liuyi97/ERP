using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL.NewFolder1;
using BLL.NewFolder1;
using System.Data.SqlClient;
namespace WebApplication1.Stock
{
    public partial class SaleInStore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                CR();
                dropdownList();
                Store();
                House();
                total();
                Suppler();
                Product();
                productDetail();
            }
        }
        //随机生成
        public void CR()
        {
            string orderid = "CR";
            Random ra = new Random();
            string sui = Convert.ToString(ra.Next(00000000, 99999999));
            string ordernumber = string.Format("{0}{1}{2}", orderid, DateTime.Now.ToString("yyyyMMdd"), sui);
            this.TextBox1.Text = ordernumber;
        }
        //订单编号dropdownlist显示
        public void dropdownList()
        {
            this.DropDownList1.DataSource = SaleInManager.GetOrderSelect();
            this.DropDownList1.DataTextField = "BuyOrderID";
            this.DropDownList1.DataValueField = "BuyOrderID";
            this.DropDownList1.DataBind();
        }
        //通过订单编号显示总价
        public void total()
        {
            string sqlstr = string.Format(@"select TotalPrice from t_BuyOrder where BuyOrderID='{0}'", this.DropDownList1.SelectedValue);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            this.TextBox8.Text = dt.Rows[0]["TotalPrice"].ToString();
        }
        //通过订单编号显示库房
        public void Store()
        {
            string orderid = this.DropDownList1.SelectedValue;
            this.DropDownList2.DataSource = SaleInManager.GetStore(orderid);
            this.DropDownList2.DataTextField = "HouseName";
            this.DropDownList2.DataValueField = "HouseID";
            this.DropDownList2.DataBind();
        }
        //通过订单编号和库房显示库区
        public void House()
        {
            string order = this.DropDownList1.SelectedValue;
            int store = Convert.ToInt32(this.DropDownList2.SelectedValue);
            this.DropDownList3.DataSource = SaleInManager.GetHouse(order, store);
            this.DropDownList3.DataTextField = "SubareaName";
            this.DropDownList3.DataValueField = "ID";
            this.DropDownList3.DataBind();
        }
        //通过订单编号显示商品信息
        public void productDetail()
        {
            string order = this.DropDownList1.SelectedValue;
            DataTable dt = SaleInManager.GetProduct(order);
            this.TextBox3.Text = dt.Rows[0]["Price"].ToString();
            this.TextBox4.Text = dt.Rows[0]["Quantity"].ToString();
            this.TextBox5.Text = dt.Rows[0]["TaxRate"].ToString();
            this.TextBox6.Text = dt.Rows[0]["DiscountRate"].ToString();
            this.TextBox7.Text = dt.Rows[0]["Description"].ToString();
        }
        //商品信息展示
        public void Product()
        {
            string order = this.DropDownList1.SelectedValue;
            this.DropDownList4.DataSource = SaleInManager.GetProductname(order);
            this.DropDownList4.DataTextField = "ProductsName";
            this.DropDownList4.DataValueField = "ProductsID";
            this.DropDownList4.DataBind();
        }
        //供应商信息展示
        public void Suppler()
        {
            string order = this.DropDownList1.SelectedValue;
            this.DropDownList5.DataSource = SaleInManager.GetSupplier(order);
            this.DropDownList5.DataTextField = "SupplierName";
            this.DropDownList5.DataValueField = "SupplierID";
            this.DropDownList5.DataBind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Store();
            House();
            total();
            Suppler();
            Product();
        }
        protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            House();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaleInStoreDetail.aspx?id=" + this.TextBox1.Text);
        }
    }
}