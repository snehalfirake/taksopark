using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taksopark.DAL.Enums;
using Taksopark.DAL.Models;

namespace Taksopark.WebForms.Models
{
    public class RequestModel : Request
    {
        public RequestModel(Request request)
        {
            this.Id = request.Id;
            this.CreatorId = request.CreatorId;
            this.OperatorId = request.OperatorId;
            this.DriverId = request.DriverId;
            this.PhoneNumber = request.PhoneNumber;
            this.Price = request.Price;
            this.RequesTime = request.RequesTime;
            this.StartPoint = request.StartPoint;
            this.FinishPoint = request.FinishPoint;
            this.Status = request.Status;
        }

        public string StatusIconUrl
        {
            get
            {
                if (this.Status == (int) RequestStatusEnum.Active)
                {
                    return "~/Images/StatusImages/Active.png";
                }
                else if (this.Status == (int)RequestStatusEnum.InProgress)
                {
                    return "~/Images/StatusImages/InProgress.png";
                }
                else if (this.Status == (int)RequestStatusEnum.Rejected)
                {
                    return "~/Images/StatusImages/Rejected.png";
                }
                else if (this.Status == (int)RequestStatusEnum.Closed)
                {
                    return "~/Images/StatusImages/Closed.png";
                }
                else
                {
                    throw new InvalidOperationException("Request status icon url cannot be obtained due to incorrect status of the request");
                }
            }
        }

        private string _created = string.Empty;
        public string CreatedAt
        {
            get
            {
                return GetDate();
            }
        }

        public string Date
        {
            get
            {
                return this.RequesTime.ToString("MMMM dd, yyyy");
            }
        }

        public string Time
        {
            get
            {
                return this.RequesTime.ToString("H:mm:ss");
            }
        }

        protected String GetDate()
        {

            var subtract = DateTime.Now.Subtract(RequesTime);

            string timeAgo;
            if (subtract.Days == 0)
            {
                if (subtract.Hours > 0)
                {
                    switch (subtract.Hours)
                    {
                        case 1:
                            timeAgo = "hour";
                            break;
                        default:
                            timeAgo = "hours";
                            break;
                    }

                    return String.Format("{0} {1} ago", subtract.Hours, timeAgo);
                }
                if (subtract.Minutes > 0)
                {
                    switch (subtract.Minutes)
                    {
                        case 1:
                            timeAgo = "minute";
                            break;
                        default:
                            timeAgo = "minutes";
                            break;
                    }

                    return String.Format("{0} {1} ago", subtract.Minutes, timeAgo);
                }

                return String.Format("{0} sec ago", subtract.Seconds);
            }

            return String.Format("{0} days ago", subtract.Days);
            //return String.Format("{0} {1} {2}", RequesTime.Day, months[RequesTime.Month - 1], RequesTime.Year, subtract.Days);
        }

        public string EstimatedPrice
        {
            get { return this.Price.Value.ToString("0.00") + " UAH"; }
        }

        //private string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}