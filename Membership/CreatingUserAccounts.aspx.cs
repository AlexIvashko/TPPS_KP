using System;
using System.Web.Security;
using MySql.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;

namespace travel_agency.Membership
{
    public partial class CreatingUserAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            string createStatus = "New user has been created successfully!";
            try {

                MembershipUser newUser = System.Web.Security.Membership.CreateUser(Username.Text, Password.Text, Email.Text);
                // Add the user to the role 
                System.Web.Security.Roles.AddUserToRole(newUser.UserName, "User");
            }
            catch (MembershipCreateUserException ex)
            {
                createStatus = GetErrorMessage(ex.StatusCode);
            }
            catch (HttpException ex)
            {
                createStatus = ex.Message;
            }
            CreateAccountResults.Text = createStatus;

        }

        public string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that email address already exists. Please enter a different email address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The email address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}