using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace FuneralWebsite.Member
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                if(null != myCookies["username"])
                {
                    Session["UserName"] = myCookies["username"];
                }
                
                loadFunerals();
            }
            else { Session["NameOfTheDead"] = DropDownList1.SelectedValue; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["NameOfTheDead"] = "";
            Response.Redirect("CreateFuneral.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void logoutFunc(object sender, EventArgs e)
        {

        }

        private void loadFunerals()
        {
            string fLocation = System.IO.Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml");
            if (File.Exists(fLocation))
            {
                FileStream FS = new FileStream(fLocation, FileMode.Open);
                XmlDocument xd = new XmlDocument();
                xd.Load(FS);
                FS.Close();
                int index = 0;
                XmlElement rootElement = xd.DocumentElement;
                foreach (XmlNode node in rootElement.ChildNodes)
                {
                    if (node["username"].InnerText == (String)Session["UserName"])
                    {
                        //Add funeral to user dropdown.
                        foreach (XmlNode funerals in node.ChildNodes)
                        {
                            if(!funerals.Name.Equals("username") && !funerals.Name.Equals("password"))
                            {
                                ListItem item = new ListItem(funerals.InnerText);
                                item.Value = funerals.InnerText;
                                DropDownList1.Items.Insert(index, item);
                                index++;
                            }
                        }
                    }
                }
            }
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            Session["NameOfTheDead"] = DropDownList1.SelectedValue;
            Response.Redirect("CreateFuneral.aspx");
        }
    }
}