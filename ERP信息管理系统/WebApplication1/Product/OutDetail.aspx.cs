using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Models.ProductOut;

namespace WebApplication1.Product
{
    public partial class OutDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string outID = Request["OutID"];
                ShowDetailInfo(outID);
                ShowGridView(outID);
            }
        }

        public void ShowDetailInfo(string outID)
        {
            SaveOutMessage s = BLL.POutBLL.POutManager.GetDetails(outID);
            this.txtID.Text = s.OutID;
            this.txtCreateDate.Text = s.TradeDate;
            this.txtPeople.Text = s.UserName;
            this.txtHouse.Text = s.HouseStore.ToString();
            this.txtTotal.Text = s.TotalPrice.ToString();
            if (s.State == 1)
            {
                this.txtState.Text = "未审核";
                this.txtState.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.txtState.Text = "已审核";
                this.txtState.ForeColor = System.Drawing.Color.Green;
            }
            this.txtTradeDate.Text = s.TradeDate;
            this.txtDesc.Text = s.Description;
        }

        public void ShowGridView(string outID)
        {
            this.GridViewDetail.DataSource = BLL.POutBLL.POutManager.CheckGridView(outID);
            this.GridViewDetail.DataBind();
        }
    }
}