using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.NewFolder1;
using System.Data;
using BLL.NewFolder1;
namespace WebApplication1.Stock
{
    public partial class SaleReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rand();
                buyorderid();
                Store();
                House();
                Time();
                GetP();
                GetS();
                GetTotal();
                Product();
            }
        }
        //订单编号随机数
        public void rand()
        {
            string orderid = "RB";
            Random ra = new Random();
            string sui = Convert.ToString(ra.Next(00000000, 99999999));
            string ordernumber = string.Format("{0}{1}{2}", orderid, DateTime.Now.ToString("yyyyMMdd"), sui);
            this.TextBox1.Text = ordernumber;
        }
        public void buyorderid()
        {
            this.DropDownList1.DataSource = salereturnManager.GetOrderid();
            this.DropDownList1.DataTextField = "ReceiptOrderID";
            this.DropDownList1.DataValueField = "ReceiptOrderID";
            this.DropDownList1.DataBind();
        }
        public void Time()
        {
            string order = this.DropDownList1.SelectedValue;
            DataTable dt = salereturnManager.GetTrandTime(order);
            this.TextBox2.Text = dt.Rows[0]["ReceiptOrderDate"].ToString();
            this.TextBox2.ReadOnly = true;
        }
        //库房
        public void Store()
        {
            string order = this.DropDownList1.SelectedValue;
            this.DropDownList2.DataSource = salereturnManager.GetHouse(order);
            this.DropDownList2.DataTextField = "HouseName";
            this.DropDownList2.DataValueField = "StoreHouseID";
            this.DropDownList2.DataBind();
        }
        //库区
        public void House()
        {
            string order = this.DropDownList1.SelectedValue;
            int id = Convert.ToInt32(this.DropDownList2.SelectedValue);
            this.DropDownList3.DataSource = salereturnManager.GetStore(order, id);
            this.DropDownList3.DataTextField = "SubareaName";
            this.DropDownList3.DataValueField = "HouseID";
            this.DropDownList3.DataBind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Time();
            Store();
            House();
            GetTotal();
            Product();
            GetP();
            GetS();
        }
        //获取总价，首付价
        public void GetTotal()
        {
            string order = this.DropDownList1.SelectedValue;
            DataTable dt = salereturnManager.TotalPrice(order);
            this.TextBox4.Text = dt.Rows[0]["TotalPrice"].ToString();
            this.TextBox5.Text = dt.Rows[0]["AlreadyPay"].ToString();
        }
        //通过orderid 获取商品名
        public void GetP()
        {
            string orderid = this.DropDownList1.SelectedValue;
            this.DropDownList4.DataSource = salereturnManager.GetP(orderid);
            this.DropDownList4.DataTextField = "ProductsName";
            this.DropDownList4.DataValueField = "ProductsID";
            this.DropDownList4.DataBind();
        }
        //通过orderid 获取供应商名
        public void GetS()
        {
            string orderid = this.DropDownList1.SelectedValue;
            this.DropDownList5.DataSource = salereturnManager.GetS(orderid);
            this.DropDownList5.DataTextField = "SupplierName";
            this.DropDownList5.DataValueField = "SupplierID";
            this.DropDownList5.DataBind();
        }
        //通过orderid 获取商品信息
        public void Product()
        {
            string orderid = this.DropDownList1.SelectedValue;
            DataTable dt = salereturnManager.GetProduct(orderid);
            this.TextBox6.Text = dt.Rows[0]["Price"].ToString();
            this.TextBox7.Text = dt.Rows[0]["Quantity"].ToString();
            this.TextBox8.Text = dt.Rows[0]["Description"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            addorder ad = new addorder();
            ad.BuyReturnID = this.TextBox1.Text;
            ad.ProductsID = Convert.ToInt32(this.DropDownList4.SelectedValue);
            ad.SupplierID = this.DropDownList5.SelectedValue;
            ad.Quantity = Convert.ToInt32(this.TextBox7.Text);
            ad.Price = this.TextBox6.Text;
            ad.Description = this.TextBox8.Text;
            bool rows = salereturnManager.GetA(ad);
            if (rows == true)
            {
                Response.Write("<script>alert('添加成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");
            }
        }
    }
}
    

