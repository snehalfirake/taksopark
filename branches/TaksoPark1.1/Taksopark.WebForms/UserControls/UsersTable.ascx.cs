using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.WebForms.Classes;
using Taksopark.WebForms.UserControls;

namespace Taksopark.WebForms.UserControls
{

    public partial class UsersTable : System.Web.UI.UserControl
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

        protected void UsersGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string UserId = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                GridViewClicked(this, new GridViewEventArgs(UserId));
            }
        }
    }
}