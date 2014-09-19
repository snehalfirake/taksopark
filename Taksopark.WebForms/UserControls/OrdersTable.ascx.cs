using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taksopark.WebForms.UserControls.Dispatcher
{
    public partial class OrdersTable : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string DataSourceID
        {
            get
            {
                return gridViewOrders.DataSourceID;
            }
            set
            {
                gridViewOrders.DataSourceID = value;
            }
        }

        protected void gridViewOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewOrders.PageIndex = e.NewPageIndex;
            gridViewOrders.DataBind();
        }
    }
}