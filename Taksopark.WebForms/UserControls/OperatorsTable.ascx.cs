using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.WebForms.Classes;

namespace Taksopark.WebForms.UserControls
{
    public delegate void GridViewClickedEventHandler(object sender, GridViewEventArgs e);
    public partial class OperatorsTable : System.Web.UI.UserControl
    {
        public event GridViewClickedEventHandler GridViewClicked;
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

        protected void OperatorsGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string OperatorId = OperatorsGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
            //string OperatorName = OperatorsGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
            //string LastName = OperatorsGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
            //string Login = OperatorsGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
            //string PhoneNumber = OperatorsGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
            //string Email = OperatorsGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
            //string Password = OperatorsGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
            //string Status = OperatorsGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text;
            GridViewClicked(this, new GridViewEventArgs(OperatorId/*, OperatorName, LastName, Login, PhoneNumber, Email,
                Password, Status*/));
        }
    }
}