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
            if (GridViewClicked != null)
            {
                string UserId = TaxiDriversGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                //string UserName = TaxiDriversGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
                //string LastName = TaxiDriversGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
                //string Login = TaxiDriversGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
                //string PhoneNumber = TaxiDriversGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                //string Email = TaxiDriversGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
                //string Password = TaxiDriversGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
                //string Status = TaxiDriversGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text;
                GridViewClicked(this, new GridViewEventArgs(UserId/*, UserName, LastName, Login, PhoneNumber, Email,
                    Password, Status*/));
            }
        }
    }
}