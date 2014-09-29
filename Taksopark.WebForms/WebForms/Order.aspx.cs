using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Taksopark.DAL.Models;
using Unity.WebForms;
using Taksopark.WebForms.WebForms;
using Taksopark.DAL.Enums;

namespace Taksopark.WebForms.Dispatcher
{
    public partial class Order : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Request> GetAllRequests(string status)
        {
            if (status == "All")
            {
                IOperatorBl operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
                var orders = operatorBl.GetAllRequests();
                return orders.OrderBy(o => o.RequesTime).ToList();
                
            }
            else
            {
                IOperatorBl operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
                var orders = operatorBl.GetAllRequestsByStatus((int)Enum.Parse(typeof(RequestStatusEnum), status));
                return orders.OrderBy(o => o.RequesTime).ToList();
            }
        }

        protected void timerToRefreshOrders_Tick(object sender, EventArgs e)
        {
            OrdersTable.DataBind();
        }
    }
}