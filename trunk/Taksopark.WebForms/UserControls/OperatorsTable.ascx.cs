using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taksopark.WebForms.UserControls
{
    public partial class OperatorsTable : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string DataSourceID
        {
            get
            {
                return OperatorsGV.DataSourceID;
            }
            set
            {
                OperatorsGV.DataSourceID = value;
            }
        }

        protected void OperatorsGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OperatorsGV.PageIndex = e.NewPageIndex;
            OperatorsGV.DataBind();
        }
    }
}