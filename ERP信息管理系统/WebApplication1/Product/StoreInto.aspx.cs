using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Models;
namespace WebApplication1.Product
{
    public partial class StoreInto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //下拉选项 选择库房
                this.DDLSelect.DataSource = BLL.PIntoBLL.ProIntoManager.House();

                this.DDLSelect.DataValueField = "HouseID";
                this.DDLSelect.DataTextField = "HouseName";
                this.DDLSelect.DataBind();
                this.DDLSelect.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

        protected void DDLSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = this.DDLSelect.SelectedItem.Value;
            if (this.DDLSelect.SelectedItem.Text != "请选择")
            {
                //库房数据显示
                List<ProductMessage> list = BLL.PIntoBLL.ProIntoManager.HouseDetail(id);
                this.DLHouse.DataSource = list;
                this.DLHouse.DataBind();
            }
        }
    }
}