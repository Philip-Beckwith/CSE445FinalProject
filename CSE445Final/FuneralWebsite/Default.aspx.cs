using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FuneralWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMemberPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member/Member.aspx");
        }

        protected void btnStaffPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Staff/Staff.aspx");
        }

        protected void memberLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member/MemberLogin.aspx");
        }

        protected void staffLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}