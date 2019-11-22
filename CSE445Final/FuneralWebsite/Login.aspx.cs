using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace FuneralWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool myAuthenticate(string username, string password)
        {
            string filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\Staff.xml";

            //Authenticates the "staff" users
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filepath);
            XmlElement rootElement = myDoc.DocumentElement;
            foreach (XmlNode node in rootElement.ChildNodes)
            {
                if (node["username"].InnerText == username)
                {
                    if (node["password"].InnerText == password)
                    {
                        return true;
                    }
                    else
                    {//if username exists but password does match. 
                        return false;
                    }
                }
            }
            return false;
        }
    }
}