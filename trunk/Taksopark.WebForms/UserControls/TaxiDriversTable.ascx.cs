using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taksopark.WebForms.UserControls
{
    public partial class TaxiDriversTable : System.Web.UI.UserControl
    {
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
    }
}