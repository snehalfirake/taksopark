using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taksopark.WebForms.Classes;

namespace Taksopark.WebForms.UserControls
{
    public partial class CarsTable : System.Web.UI.UserControl
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
                return CarsGV.DataSourceID;
            }
            set
            {
                CarsGV.DataSourceID = value;
            }
        }
        protected void CarsGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CarsGV.PageIndex = e.NewPageIndex;
            CarsGV.DataBind();
        }

        protected void CarsGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (GridViewClicked != null)
            {
                string UserId = CarsGV.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                GridViewClicked(this, new GridViewEventArgs(UserId));
            }
        }
    }
}