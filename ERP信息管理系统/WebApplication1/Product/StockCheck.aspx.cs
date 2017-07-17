using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models.InventoryModule;

namespace WebApplication1.Product
{
    public partial class StockCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            InventoryID();
            this.txtCreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        //随机生成订单编号
        public void InventoryID()
        {
            //string orderid = "BY";
            Random ra = new Random();
            string sui = Convert.ToString(ra.Next(00000000, 99999999));
            string ordernumber = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMdd"), sui);
            this.txtID.Text = ordernumber;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            StockInto s = new StockInto();
            s.InventoryID = this.txtID.Text;
            s.CreatDate = this.txtCreateDate.Text;
            s.StoreHouseID = int.Parse(this.txtHouse.Text);
            s.HouseDetailID = int.Parse(this.txtArea.Text);
            s.ProductsID = int.Parse(this.ProID.Text);
            s.BillNum = int.Parse(this.txtBill.Text);
            s.RealityNum = int.Parse(this.txtReal.Text);
            s.AdjustNum = int.Parse(this.txtAdjust.Text);
            s.UserName = this.txtPeople.Text;
            s.TradeDate = this.DateTime2.Value;//选择日期
            s.Description = this.txtDesc.Text;
            bool b = BLL.InventoryBLL.InventoryManager.AddStock(s);
            if (b)
            {
                Response.Write("<script>alert('提交成功')</script>");
            }
        }
    }


}