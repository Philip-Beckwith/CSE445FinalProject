using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FuneralWebsite.Staff
{
    public partial class Staff : System.Web.UI.Page
    {
        CalendarService.CalendarServicesClient client = new CalendarService.CalendarServicesClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDisplayReservation_Click(object sender, EventArgs e)
        {
            string data = client.GetAllReservationsBetweenDates(txbxStartDate.Text.Trim(), txbxEndDate.Text.Trim());
            if (data.Trim().Length < 1)
            {
                lblData.Text = "No data available for given dates.";
            }
            else
            {
                lblData.Text = data;
            }
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            client.DeleteAllData();
        }
    }
}