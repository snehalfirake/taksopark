using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.WebForms.Classes;
using Taksopark.WebForms.UserControls;
//using Taksopark.WebForms.Models;

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
            if (GridViewClicked != null)
            {
                string UserId = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                //string UserName = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
                //string LastName = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
                //string Login = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
                //string PhoneNumber = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                //string Email = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
                //string Password = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
                //string Status = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text;
                GridViewClicked(this, new GridViewEventArgs(UserId/*, UserName, LastName, Login, PhoneNumber, Email, 
                    Password, Status*/));
            }
        }
    }
}