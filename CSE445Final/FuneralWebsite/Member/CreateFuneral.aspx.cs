using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace FuneralWebsite.Member
{
    public class Funeral
    {
        public string nameOfDeceased = "";
        public string date = "";
        public string eulogy = "";
        public float price = 1000; //default
    }
    public partial class CreateFuneral : System.Web.UI.Page
    {
        CalendarService.CalendarServicesClient calendarService;
        protected void Page_Load(object sender, EventArgs e)
        {
            calendarService = new CalendarService.CalendarServicesClient();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string date = daySelector.SelectedDate.ToString();
            date = date.Substring(0, date.IndexOf(" "));
            dateLabel.Text = date;

            if (0<calendarService.CheckDayAvailability(date))
            {
                availablity.Text = "Available";
            }
            else
            {
                availablity.Text = "Not Available";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (1 == calendarService.ReserveDay(dateLabel.Text, "Account1"))
            {
                reservedDay.Text = dateLabel.Text;
            }
        }

        protected void saveChanges_Click(object sender, EventArgs e)
        {
            SaveFuneral.EulogyServicesClient save = new SaveFuneral.EulogyServicesClient();

            String JsonFuneral = new JavaScriptSerializer().Serialize(compileFuneralObject());

            save.makeOrEditEulogy("Account1", NameOfTheDead.Text, JsonFuneral);
        }

        public Funeral compileFuneralObject()
        {
            Funeral funeral = new Funeral();

            funeral.nameOfDeceased = NameOfTheDead.Text;
            funeral.date = reservedDay.Text;
            funeral.eulogy = eulogy.Text;

            return funeral;
        }


    }
}