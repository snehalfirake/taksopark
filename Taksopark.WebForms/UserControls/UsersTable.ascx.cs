using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Taksopark.WebForms.Models;

namespace Taksopark.WebForms.UserControls
{
    public partial class UsersTable : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string DataSourceID
        {
            get
            {
                return UsersGV.DataSourceID;
            }
            set
            {
                UsersGV.DataSourceID = value;
            }
        }
        protected void UsersGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UsersGV.PageIndex = e.NewPageIndex;
            UsersGV.DataBind();
        }
    }
}