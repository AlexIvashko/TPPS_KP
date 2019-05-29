<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="ManageRoles.aspx.cs" Inherits="travel_agency.Roles.ManageRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="d-flex flex-column justify-content-center">
    <div class="container">
    <div class="form-group">
        <b>Create a New Role: </b>
        <asp:TextBox ID="RoleName" runat="server" CssClass="form-control col-4"></asp:TextBox>
        <br />
        <asp:Button ID="CreateRoleButton" runat="server"
            Text="Create Role"
            OnClick="CreateRoleButton_Click"
            CssClass="btn btn-primary" />
        <br />
    </div>
        </div>
    <div class="container">
    <asp:GridView ID="RoleList" runat="server" 
        AutoGenerateColumns="false" 
        CssClass="table table-bordered">
         <Columns>    
             <asp:CommandField DeleteText="Delete Role" ShowDeleteButton="True"/>
             <asp:TemplateField HeaderText="Role">
                 <ItemTemplate>
                     <asp:Label runat="server" ID="RoleNameLabel" Text='<%# Container.DataItem %>'
                         CssClass="form-control" />
                 </ItemTemplate>
             </asp:TemplateField>    
         </Columns> 
    </asp:GridView>
    </div>
        </div>
</asp:Content>
