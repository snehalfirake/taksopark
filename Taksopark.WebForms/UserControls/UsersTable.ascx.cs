using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.WebForms.Models;

namespace Taksopark.WebForms.UserControls
{
    //public delegate void GridViewClickedEventHandler(object sender, UsersGridViewEventArgs e);
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

        //public event GridViewClickedEventHandler GridViewClicked;

        //public event GridViewCommandEventHandler Row_Command;
        protected void UsersGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UsersGV.PageIndex = e.NewPageIndex;
            UsersGV.DataBind();
        }
        protected void UsersGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Delete")
            //{
            //    int UserID = Convert.ToInt32(e.CommandArgument);
            //    Repository.CustomerRepository rep = new Repository.CustomerRepository();
            //    rep.DeleteCustomer(new Customer() { Id = UserID });
            //}

            //if (Row_Command != null)
            //{
            //    Row_Command(sender, e);
            //}

            //if (GridViewClicked != null)
            //{
            //    string UserName = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
            //    string LastName = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
            //    string Login = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
            //    string Password = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
            //    string Status = UsersGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
            //    GridViewClicked(this, new UsersGridViewEventArgs(UserName, LastName, Login, Password, Status));
            //}
        }
    }
}