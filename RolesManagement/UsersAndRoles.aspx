<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="UsersAndRoles.aspx.cs" Inherits="travel_agency.Roles.UsersAndRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Important {
            font-size: large;
            color: Red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container">
        <h1>User role management</h1>
        <h3>Manage Roles by User</h3>
        <p>
            <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>
        </p>
        <div class="form-group">
            <asp:DropDownList ID="UserList" runat="server"
                AutoPostBack="true"
                DataTextField="UserName"
                DataValueField="UserName"
                OnSelectedIndexChanged="UserList_SelectedIndexChanged"
                CssClass="form-control" />

            <asp:Repeater ID="UsersRoleList" runat="server">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="RoleCheckBox"
                        OnCheckedChanged="RoleCheckBox_CheckChanged"
                        AutoPostBack="true"
                        CssClass="form-control"
                        Text='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <h3>Manage Users By Role</h3>
        <p>
            <b>Select a Role:</b>

            <asp:DropDownList ID="RoleList" runat="server"
                AutoPostBack="true"
                OnSelectedIndexChanged="RoleList_SelectedIndexChanged"
                CssClass="form-control" />
        </p>
        <p>
            <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False"
                EmptyDataText="No users belong to this role."
                CssClass="table table-bordered table-hover"
                OnRowDeleting="RolesUserList_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Users">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="UserNameLabel"
                                Text='<%# Container.DataItem %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </p>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserNameToAddToRole">UserName:</asp:Label>
            <asp:TextBox ID="UserNameToAddToRole" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="AddUserToRoleButton" runat="server"
                Text="Add User to Role"
                OnClick="AddUserToRoleButton_Click"
                CssClass="btn btn-success" />

        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="footer" runat="server">

</asp:Content>
