using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FuneralWebsite
{
    public partial class captchaControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = "~/imageProcess.aspx";
        }

        protected void Button1_Click(object sender, EventArgs e) // to show captcha string
        {
            ImageService.ServiceClient fromService = new
            ImageService.ServiceClient();
            //string userLength = TextBox1.Text;
            Session["userLength"] = "4";
            string myStr = fromService.GetVerifierString("4");
            Session["generatedString"] = myStr;
            Button1.Text = "Show Me Another Image String";
            Image1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e) // to submit captcha string
        {
            if (Session["generatedString"].Equals(TextBox2.Text))
            {
                Session["CaptchaValid"] = true;
                Label3.Text = "Congratulation. The code you entered is correct!";
            }
            else
            {
                Label3.Text = "I am sorry, the string you entered does not match the image.Please try again!";
                Session["CaptchaValid"] = false;
            }
        }
    }
}