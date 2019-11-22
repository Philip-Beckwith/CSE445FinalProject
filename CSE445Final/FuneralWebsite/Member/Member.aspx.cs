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
        }
    }
}