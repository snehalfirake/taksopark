using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taksopark.WebForms.UserControls.Dispatcher
{
    public partial class OrderInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string DataSourceID
        {
            get
            {
                return detailsView1.DataSourceID;
            }
            set
            {
                detailsView1.DataSourceID = value;
            }
        }

        public object DataSource
        {
            get
            {
                return detailsView1.DataSource;
            }
            set
            {
                detailsView1.DataSource = value;
            }
        }
    }
}