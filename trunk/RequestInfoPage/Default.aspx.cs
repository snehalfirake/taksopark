using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RequestInfoPage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }

            Item item = new Item();

            List<Item> list = new List<Item>();
            list.Add(item);

            formView.DataSource = list;

            this.DataBind();
        }


        //клас створений для прив'язки даних з formView (таблиця про замовника)

        public class Item
        {
            public DateTime CreatedTime { get { return DateTime.Now; } }
            public string CreatorId { get { return "12345"; } }
            public string Phone { get { return "+38(068)-52-93-558"; } }
            public string Status { get { return "Active"; } }
            public string StartPoint { get { return "Lviv, Lypneva 2"; } }
            public string DestinationPoint { get { return "Lviv, Oleny Stepanivny 45"; } }
        }

        protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelSelectedDriverInfo.Text = dropDownList.SelectedValue.ToString();
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            labelSelectedDriverInfo.Text = "yes";
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            labelSelectedDriverInfo.Text = "no";
        }

        protected void statusList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}