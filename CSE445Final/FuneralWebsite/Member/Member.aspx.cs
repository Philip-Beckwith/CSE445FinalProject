using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FuneralWebsite.Member
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If the cookie is not valid, do not grant access to the page.
            HttpCookie myCookies = Request.Cookies["LoginCookie"];
            if(myCookies == null)
            {
                Response.Redirect("MemberLogin.aspx");
            }
            else if (myCookies["valid"] != "true")
            {
                Response.Redirect("MemberLogin.aspx");
            }

            Session["UserName"] = myCookies["username"];
            loadFunerals();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateFuneral.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["NameOfTheDead"] = DropDownList1.SelectedValue;
        }

        protected void logoutFunc(object sender, EventArgs e)
        {

        }

        private void loadFunerals()
        {
            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml");
            if (File.Exists(fLocation))
            {
                eulogy.Text = "jlkasfjioajse";
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
                        foreach (XmlNode funerals in node.ChildNodes)
                        {
                            if (funerals["NameOfTheDead"].InnerText.Equals(Session["NameOfTheDead"]))
                            {
                                return;
                            }
                            //Adding Funeral To Member.
                            XmlElement nFuneral = xd.CreateElement("NameOfTheDead");
                            nFuneral.InnerText = (String)Session["NameOfTheDead"];
                            node.AppendChild(nFuneral);
                        }
                    }
                }

                xd.Save(fLocation);
            }
        }
    }
}