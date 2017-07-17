using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;
namespace WebApplication1.Product
{
    public partial class IntoDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string appendID = Request["AppendID"];
                ShowDetailInfo(appendID);
                ShowGridView(appendID);
            }
        }

        public void ShowDetailInfo(string appendID)
        {
            SaveIntoMessage s = BLL.PIntoBLL.ProIntoManager.GetDetails(appendID);
            this.txtID.Text = s.AppendID;
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

        public void ShowGridView(string appendID)
        {
            this.GridViewDetail.DataSource = BLL.PIntoBLL.ProIntoManager.CheckGridView(appendID);
            this.GridViewDetail.DataBind();
        }

    }
}