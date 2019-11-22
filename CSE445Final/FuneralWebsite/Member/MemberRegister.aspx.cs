using System;
using System.IO;
using System.Xml;

namespace FuneralWebsite.Member
{
    public partial class MemberRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml");
            if (File.Exists(fLocation))
            {
                FileStream FS = new FileStream(fLocation, FileMode.Open);
                XmlDocument xd = new XmlDocument();
                xd.Load(FS);
                FS.Close();

                //check if member already exists:
                XmlElement rootElement = xd.DocumentElement;
                foreach (XmlNode node in rootElement.ChildNodes)
                {
                    if (node["username"].InnerText == txbxUsername.Text)
                    {
                        lblResult.Text = String.Format("*Account with user name {0} already exists.", txbxUsername.Text);
                        lblResult.Visible = true;
                        return;
                    }
                }
                lblResult.Visible = false;

                //Code to Add a member
                XmlElement myMember = xd.CreateElement("member");
                xd.DocumentElement.AppendChild(myMember);

                XmlElement myUser = xd.CreateElement("username");
                myMember.AppendChild(myUser);
                myUser.InnerText = txbxUsername.Text;


                //TODO add password hash instead of saving password plaintext to XML file
                XmlElement myPwd = xd.CreateElement("password");
                myMember.AppendChild(myPwd);
                myPwd.InnerText = txbxPassword.Text;

                xd.Save(fLocation);

                //make the invisible, visible
                lblResult.Visible = true;
                lblResult.Text = "Account Created!";
                btnMember.Visible = true;
            }
        }
        protected void btnMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member.aspx");
        }
    }
}