using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.NewFolder1;
using BLL.NewFolder1;
using System.Data;

namespace WebApplication1.Stock
{
    public partial class SaleOrderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                xianshi();
            }
        }
        public void xianshi()
        {
            string id = Request["id"];
            DataTable dt = selectorder.GetSelect(id);
            this.TextBox1.Text = dt.Rows[0]["BuyOrderID"].ToString();
            this.TextBox2.Text = dt.Rows[0]["BuyOrderDate"].ToString();
            this.TextBox3.Text = "蓝默默";
            DataTable store = selectorder.GetStoreDetail(Convert.ToInt32(dt.Rows[0]["StoreHouseID"].ToString()));
            this.TextBox4.Text = store.Rows[0]["HouseName"].ToString();
            DataTable house = selectorder.GetHouseDetail(Convert.ToInt32(dt.Rows[0]["HouseDetailID"].ToString()));
            this.TextBox5.Text = house.Rows[0]["SubareaName"].ToString();
            this.TextBox6.Text = dt.Rows[0]["UserName"].ToString();
            this.TextBox7.Text = "未审核";
            this.TextBox8.Text = dt.Rows[0]["SignDate"].ToString();
            this.TextBox9.Text = dt.Rows[0]["TradeDate"].ToString();
            this.TextBox10.Text = dt.Rows[0]["TradeAddress"].ToString();
            this.TextBox11.Text = dt.Rows[0]["Description"].ToString();
        }
    }
}