using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace travel_agency.Roles
{
    public partial class ManageRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                DisplayRolesInGrid();
        }

        protected void CreateRoleButton_Click(object sender, EventArgs e)
        {
            string newRoleName = RoleName.Text.Trim();

            if (!System.Web.Security.Roles.RoleExists(newRoleName))
            {
                // Create the role
                System.Web.Security.Roles.CreateRole(newRoleName);
                // Refresh the RoleList Grid    
                DisplayRolesInGrid();
            }

            RoleName.Text = string.Empty;
        }

        private void DisplayRolesInGrid()
        {
            RoleList.DataSource = System.Web.Security.Roles.GetAllRoles();
            RoleList.DataBind();
        }

        protected void RoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the RoleNameLabel
            Label RoleNameLabel = RoleList.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;

            // Delete the role
            System.Web.Security.Roles.DeleteRole(RoleNameLabel.Text, false);

            // Rebind the data to the RoleList grid
            DisplayRolesInGrid();
        }
    }
}