using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.NewFolder1;
using BLL.NewFolder1;
using DAL.NewFolder1;
using System.Data;
namespace WebApplication1.Stock
{
    public partial class SaleOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rand();
                storehouse();
                housedetail();
                productname();
                supplier();
            }

        }
        //订单编号随机数
        public void rand()
        {
            string orderid = "BY";
            Random ra = new Random();
            string sui = Convert.ToString(ra.Next(00000000, 99999999));
            string ordernumber = string.Format("{0}{1}{2}", orderid, DateTime.Now.ToString("yyyyMMdd"), sui);
            this.TextBox1.Text = ordernumber;
        }
        //库房
        public void storehouse()
        {
            this.DropDownList1.DataSource = HouseManager.GetStore();
            this.DropDownList1.DataTextField = "HouseName";
            this.DropDownList1.DataValueField = "HouseID";
            this.DropDownList1.DataBind();
        }
        //库区
        public void housedetail()
        {
            this.DropDownList2.DataSource = HouseManager.GetHouse(Convert.ToInt32(this.DropDownList1.SelectedValue));
            this.DropDownList2.DataTextField = "SubareaName";
            this.DropDownList2.DataValueField = "ID";
            this.DropDownList2.DataBind();
        }


        //商品名
        public void productname()
        {
            string sqlstr = string.Format(@"select * from t_Products");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            this.DropDownList3.DataSource = dt;
            this.DropDownList3.DataTextField = "ProductsName";
            this.DropDownList3.DataValueField = "ProductsID";
            this.DropDownList3.DataBind();
        }
        //供应商
        public void supplier()
        {
            string sqlstr = string.Format(@"select * from t_Supplier");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            this.DropDownList4.DataSource = dt;
            this.DropDownList4.DataTextField = "SupplierName";
            this.DropDownList4.DataValueField = "SupplierID";
            this.DropDownList4.DataBind();

        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaleOrderDetail.aspx?id=" + this.TextBox1.Text);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            housedetail();
        }
    }
}