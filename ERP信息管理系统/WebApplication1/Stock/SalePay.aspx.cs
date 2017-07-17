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
    public partial class SalePay : System.Web.UI.Page
    {
          protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                buyorderid();
                this.TextBox1.Text = DateTime.Now.ToString();
                GetTotal();
                leixing();
                this.TextBox3.ReadOnly = true;//不可编辑
                this.TextBox4.ReadOnly = true;
            }
        }
        //订单金额
        public void GetTotal()
        {
            string buyorderid = this.DropDownList2.SelectedValue;
            DataTable dt = SalePayManager.GetTotal(buyorderid);
            this.TextBox3.Text = dt.Rows[0]["TotalPrice"].ToString();
            this.TextBox4.Text = dt.Rows[0]["AlreadyPay"].ToString();
        }
        //支付类型
        public void leixing()
        {
            this.DropDownList1.DataSource = SalePayManager.GetLei();
            this.DropDownList1.DataValueField = "AccountsID";
            this.DropDownList1.DataTextField = "AccountsName";
            this.DropDownList1.DataBind();
        }
        public void buyorderid()
        {
            DataTable dt = SalePayManager.GetBuyOrderID();
            this.DropDownList2.DataSource = dt;
            this.DropDownList2.DataTextField = "ReceiptOrderID";
            this.DropDownList2.DataValueField = "ReceiptOrderID";
            this.DropDownList2.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            addorder ad = new addorder();
            ad.BuyReceiptID = this.DropDownList2.SelectedValue;
            ad.CreateDate = this.TextBox1.Text;
            ad.Ticket = this.TextBox2.Text;
            ad.RealPay = this.TextBox5.Text;
            ad.AttachPay = this.TextBox6.Text;
            ad.PayType = this.DropDownList1.SelectedItem.Text;
            ad.Description = this.TextBox7.Text;
            ad.userName = "huhai123";
            ad.State ="1";
            bool row = SalePayManager.GetAdd(ad);
            DataTable dt = SalePayManager.Get();
            string buy = dt.Rows[0]["BuyReceiptID"].ToString();
            if (this.DropDownList2.SelectedValue == buy)
            {
                Response.Write("<script>alert('已经有相关订单的数据，在此添加不可用！');</script>");
                return;
            }
            else
            {
                if (row == true)
                {
                    Response.Write("<script>alert('采购成功！');</script>");
                }
                else
                {
                    Response.Write("<script>alert('采购失败！');</script>");
                }
            }
         
        }
        }
    }
