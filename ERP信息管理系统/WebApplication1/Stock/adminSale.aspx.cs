﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.NewFolder1;
using BLL.NewFolder1;
namespace WebApplication1.Stock
{
    public partial class adminSale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                State();
              
            }
        }
        public void State()
        {
            this.DropDownList2.DataSource = adminSaleManager.GetSatate();
            this.DropDownList2.DataTextField = "StateName";
            this.DropDownList2.DataValueField = "StateID";
            this.DropDownList2.DataBind();
        }
    }
}