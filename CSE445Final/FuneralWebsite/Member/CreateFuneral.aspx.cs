using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml;

namespace FuneralWebsite.Member
{
    public class Funeral
    {
        public string nameOfDeceased = "";
        public string date = "Date";
        public string eulogy = "";
        public string price = "$10000"; //default
        public int type = 0;
        public int casketType = 0;
        public string numberOfFlowers = "0";
    }
    public partial class CreateFuneral : System.Web.UI.Page
    {
        static CalendarService.CalendarServicesClient calendarService = new CalendarService.CalendarServicesClient();
        static SaveFuneral.EulogyServicesClient save = new SaveFuneral.EulogyServicesClient();
        Funeral funeral;

        protected void Page_Load(object sender, EventArgs e)
        {
            //If the cookie is not valid, do not grant access to the page.
            HttpCookie myCookies = Request.Cookies["LoginCookie"];
            if (myCookies == null)
            {
                Response.Redirect("MemberLogin.aspx");
            }
            else if (myCookies["valid"] != "true")
            {
                Response.Redirect("MemberLogin.aspx");
            }

            String savedFuneralJson = "";

            if(Session["UserName"] != null && Session["NameOfTheDead"] != null)
            {
                savedFuneralJson = save.getEulogy((String)Session["UserName"], (String)Session["NameOfTheDead"]);
                if (savedFuneralJson.StartsWith("\""))
                {
                    savedFuneralJson = savedFuneralJson.Substring(1,savedFuneralJson.Length-2);
                }
            }

            if (Page.IsPostBack) { }
            else if (!savedFuneralJson.Equals("") && !savedFuneralJson.Contains("ERROR:"))
            {
                funeral = new JavaScriptSerializer().Deserialize<Funeral>(savedFuneralJson);
                loadInfo();
            }
            else if (Session["CurrentFuneral"] != null)
            {
                funeral = (Funeral) Session["CurrentFuneral"];
                loadInfo();
            }

            if(funeral == null)
            {
                funeral = new Funeral();
            }
        }

        private void loadInfo()
        {
            NameOfTheDead.Text = funeral.nameOfDeceased;
            reservedDay.Text = funeral.date;
            eulogy.Text = funeral.eulogy;
            Cost.Text = funeral.price;
            FuneralType.SelectedIndex = funeral.type;
            CasketType.SelectedIndex = funeral.casketType;
            NumberOfFlowers.Text = funeral.numberOfFlowers;
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
            updateSession();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (1 == calendarService.ReserveDay(dateLabel.Text, (String)Session["UserName"]))
            {
                reservedDay.Text = dateLabel.Text;
            }
            updateSession();
        }

        protected void saveChanges_Click(object sender, EventArgs e)
        {
            updateSession();

            String JsonFuneral = new JavaScriptSerializer().Serialize(funeral);
            JsonFuneral = "\"" + JsonFuneral + "\"";
            String responce = "";

            while (!responce.Contains((string)Session["NameOfTheDead"]))
            {
                responce = save.makeOrEditEulogy((String)Session["UserName"], (String)Session["NameOfTheDead"], JsonFuneral);
            }

            Session["NameOfTheDead"] = NameOfTheDead.Text;

            LinkUserToFuneral();
        }

        public Funeral compileFuneralObject()
        {
            calculatePrice();

            funeral.nameOfDeceased = NameOfTheDead.Text;
            funeral.date = reservedDay.Text;
            funeral.eulogy = eulogy.Text;
            funeral.price = Cost.Text;

            return funeral;
        }

        public void calculatePrice()
        {
            AWeirdPricingService.Service1Client priceService = new AWeirdPricingService.Service1Client();
            int funeralType = 0;
            int casketType = 0;
            int numberOfFlowers = 0;

            try
            {
                funeralType = Int32.Parse(FuneralType.SelectedValue);
                casketType = Int32.Parse(CasketType.SelectedValue);
                numberOfFlowers = Int32.Parse(NumberOfFlowers.Text);

                Cost.Text = priceService.getRate(funeralType, casketType, numberOfFlowers, false).ToString();
            }
            catch 
            {
                Cost.Text = "$N/A";
            }
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            updateSession();

            Response.Redirect("Member.aspx");
        }

        protected void NameOfTheDead_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void updateName_Click(object sender, EventArgs e)
        {
            updateSession();
        }

        private void updateSession()
        {
            calculatePrice();

            funeral.nameOfDeceased = NameOfTheDead.Text;
            funeral.date = reservedDay.Text;
            funeral.eulogy = eulogy.Text;
            funeral.price = Cost.Text;
            funeral.type = FuneralType.SelectedIndex;
            funeral.casketType = CasketType.SelectedIndex;
            funeral.numberOfFlowers = NumberOfFlowers.Text;

            Session["CurrentFuneral"] = funeral;
            Session["NameOfTheDead"] = funeral.nameOfDeceased;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            updateSession();
        }

        protected void LinkUserToFuneral()
        {
            if (Session["NameOfTheDead"] == null || Session["UserName"] == null) { return; }
            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml");
            if (File.Exists(fLocation))
            {
                FileStream FS = new FileStream(fLocation, FileMode.Open);
                XmlDocument xd = new XmlDocument();
                xd.Load(FS);
                FS.Close();

                XmlElement rootElement = xd.DocumentElement;
                foreach (XmlNode node in rootElement.ChildNodes)
                {
                    if (node["username"].InnerText == (String)Session["UserName"])
                    {
                        //Add new funeral to user already here.
                        foreach(XmlNode funerals in node.ChildNodes)
                        {
                            if (funerals.InnerText.Equals(Session["NameOfTheDead"])) 
                            {
                                return;
                            }
                            
                        }
                        //Adding Funeral To Member.
                        XmlElement nFuneral = xd.CreateElement("NameOfTheDead");
                        nFuneral.InnerText = (String)Session["NameOfTheDead"];
                        node.AppendChild(nFuneral);
                    }
                }

                xd.Save(fLocation);
            }
        }

    }
}