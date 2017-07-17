using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.Transfers;
using BLL.TransferBLL;
namespace WebApplication1.Product
{
    public partial class TransStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB();
            this.txtCreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public void DB()
        {
            string orderid = "DB";
            Random ra = new Random();
            string sui = Convert.ToString(ra.Next(00000000, 99999999));
            string ordernumber = string.Format("{0}{1}{2}", orderid, DateTime.Now.ToString("yyyyMMdd"), sui);
            this.txtOrderID.Text = ordernumber;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            TransInto s = new TransInto();
            s.ID = this.txtOrderID.Text;
            s.Date = this.txtCreateDate.Text;
            s.UserName = this.txtPeople.Text;
            s.OutHouseID = int.Parse(this.txtOut.Text);
            s.InHouseID = int.Parse(this.txtInto.Text);
            s.TradeDate = this.DateTime3.Value;//选择日期
            s.Ticket = this.txtID.Text;//票号
            s.ProductsID = int.Parse(this.ProID.Text);
            s.Quantity = int.Parse(this.txtBill.Text);
            s.Description = this.txtDesc.Text;
            s.Price = Convert.ToDouble(this.txtPrice.Text);

            bool b = BLL.TransferBLL.TransferManager.AddStock(s);
            if (b)
            {
                Response.Write("<script>alert('提交成功')</script>");
            }
        }
    }
}