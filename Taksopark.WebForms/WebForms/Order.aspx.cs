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

        public static IEnumerable<Request> GetAllRequests()
        {
            var operatorBl = HttpContext.Current.Application.GetContainer().Resolve<IOperatorBl>();
            //var orders = operatoerBl.GetActiveRequests();
            var orders = operatorBl.GetAllRequests();
            return orders;
        }
    }
}