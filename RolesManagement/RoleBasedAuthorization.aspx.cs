using System;
using System.Security.Permissions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace travel_agency.Roles
{
    public partial class RoleBasedAuthorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindUserGrid();
        }

        protected void UserGrid_OnPreRender(object sender, EventArgs e)
        {
            bool isAdmin = User.IsInRole("Administrator");
            bool isSupervisor = User.IsInRole("Supervisor");
            if (isAdmin || isSupervisor)
                UserGrid.Columns[4].Visible = true;
            else
                UserGrid.Columns[4].Visible = false;
        }

        private void BindUserGrid()
        {
            System.Web.Security.MembershipUserCollection allUsers =
                System.Web.Security.Membership.GetAllUsers();
            UserGrid.DataSource = allUsers;
            UserGrid.DataBind();
        }
        protected void UserGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the grid's EditIndex and rebind the data

            UserGrid.EditIndex = e.NewEditIndex;
            BindUserGrid();
        }

        protected void UserGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Revert the grid's EditIndex to -1 and rebind the data
            UserGrid.EditIndex = -1;
            BindUserGrid();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrator")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Supervisor")]
        protected void UserGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Exit if the page is not valid
            if (!Page.IsValid)
                return;

            // Determine the username of the user we are editing
            string UserName = UserGrid.DataKeys[e.RowIndex].Value.ToString();

            // Read in the entered information and update the user
            TextBox EmailTextBox = UserGrid.Rows[e.RowIndex].FindControl("Email") as TextBox;
            TextBox CommentTextBox = UserGrid.Rows[e.RowIndex].FindControl("Comment") as TextBox;

            // Return information about the user
            System.Web.Security.MembershipUser UserInfo = System.Web.Security.Membership.GetUser(UserName);

            // Update the User account information
            UserInfo.Email = EmailTextBox.Text.Trim();
            UserInfo.Comment = CommentTextBox.Text.Trim();

            System.Web.Security.Membership.UpdateUser(UserInfo);

            // Revert the grid's EditIndex to -1 and rebind the data
            UserGrid.EditIndex = -1;
            BindUserGrid();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        protected void UserGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Determine the username of the user we are editing
            string UserName = UserGrid.DataKeys[e.RowIndex].Value.ToString();

            // Delete the user
            System.Web.Security.Membership.DeleteUser(UserName);

            // Revert the grid's EditIndex to -1 and rebind the data
            UserGrid.EditIndex = -1;
            BindUserGrid();
        }

        protected void UserGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != UserGrid.EditIndex)
            {
                // Programmatically reference the Edit and Delete LinkButtons
                LinkButton EditButton = e.Row.FindControl("EditButton") as LinkButton;

                LinkButton DeleteButton = e.Row.FindControl("DeleteButton") as LinkButton;

                EditButton.Visible = (User.IsInRole("Administrator") || User.IsInRole("Supervisor"));
                DeleteButton.Visible = User.IsInRole("Administrator");
            }
        }
    }
}