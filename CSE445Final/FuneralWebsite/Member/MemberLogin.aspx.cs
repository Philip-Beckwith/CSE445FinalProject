using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace FuneralWebsite.Member
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnMemberLogin_Click(object sender, EventArgs e)
        {
            string username = txbxUsername.Text.Trim();
            string password = txbxPassword.Text.Trim();

            string filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\Member.xml";

            //TODO, add Hashing Stuff
            //HashRef.ServiceClient h = new HashRef.ServiceClient(); // hashing
            //string pwdEncrypt = h.Hash(password, "CSE445");

            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filepath);    // open file
            XmlElement rootElement = myDoc.DocumentElement;
            foreach (XmlNode node in rootElement.ChildNodes)
            {
                if (node["username"].InnerText == username)
                {
                    if (node["password"].InnerText == password)
                    {
                        //member logged in succesfully
                        lblLoginError.Visible = false;

                        //Create a Login cookie for the member
                        HttpCookie myCookies = new HttpCookie("LoginCookie");
                        myCookies["valid"] = "true";
                        myCookies["username"] = username;
                        // myCookies["password"] = password;
                        Response.Cookies.Add(myCookies);

                        //Saving Name in Session State
                        Session["UserName"] = username;

                        //if logged in successfully then go to Member.aspx
                        Response.Redirect("Member.aspx");
                        return;
                    }
                    else
                    {//if username exists but password does match. 
                        lblLoginError.Visible = true;
                        return;
                    }
                }
            }
            lblLoginError.Visible = true;
            return;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberRegister.aspx");
        }
    }
}