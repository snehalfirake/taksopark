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

namespace Taksopark.WebForms.Dispatcher
{
    public partial class Order : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Request> GetAllRequests(string status)
        {
            var emptyResult = new List<Request>();
            emptyResult.Add(new Request()
            {
                Id = -1,
                RequesTime = default(DateTime)
            });
            if (status == "All")
            {
                IOperatorBl operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
                var orders = operatorBl.GetAllRequests();
                if (orders.Count > 0)
                {
                    return orders;
                }
                else
                {
                    return emptyResult;
                }
            }
            else
            {
                IOperatorBl operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
                var orders = operatorBl.GetAllRequestsByStatus(status);
                if (orders.Count > 0)
                {
                    return orders;
                }
                else
                {
                    return emptyResult;
                }
            }
        }
    }
}