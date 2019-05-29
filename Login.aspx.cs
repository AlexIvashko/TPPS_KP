using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace travel_agency
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    // This is an unauthorized, authenticated request...
                    Response.Redirect("~/UnauthorizedAccess.aspx");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Validate the user against the Membership framework user store
            if (System.Web.Security.Membership.ValidateUser(UserName.Text, Password.Text))
            {
                // Log the user into the site
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, !RememberMe.Checked);
            }
            // If we reach here, the user's credentials were invalid
            InvalidCredentialsMessage.Visible = true;
        }
    }
}