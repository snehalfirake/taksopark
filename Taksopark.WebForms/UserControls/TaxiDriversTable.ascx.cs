using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.WebForms.Classes;

namespace Taksopark.WebForms.UserControls
{
    public partial class TaxiDriversTable : System.Web.UI.UserControl
    {
        public delegate void GridViewClickedEventHandler(object sender, GridViewEventArgs e);

        public event GridViewClickedEventHandler GridViewClicked;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string DataSourceID
        {
            get
            {
                return TaxiDriversGV.DataSourceID;
            }
            set
            {
                TaxiDriversGV.DataSourceID = value;
            }
        }
        protected void TaxiDriversGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TaxiDriversGV.PageIndex = e.NewPageIndex;
            TaxiDriversGV.DataBind();
        }

        protected void TaxiDriversGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string UserId = TaxiDriversGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                GridViewClicked(this, new GridViewEventArgs(UserId));
            }
        }
    }
}