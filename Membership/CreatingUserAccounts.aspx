<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="CreatingUserAccounts.aspx.cs" Inherits="travel_agency.Membership.CreatingUserAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container">
        <h3>Create a new user account</h3>
        <div class="form-group">
            <asp:Label runat="server" CssClass="form-control" AssociatedControlID="Username">Enter username</asp:Label>
            <asp:TextBox runat="server" ID="Username" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="form-control">Enter password</asp:Label>
            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="form-control" AssociatedControlID="Email">Enter email</asp:Label>
            <asp:TextBox runat="server" ID="Email" TextMode="Email" CssClass="form-control"></asp:TextBox>
        </div>
            
            <asp:Button ID="CreateAccountButton" runat="server" CssClass="btn btn-primary" Text="Create account" OnClick="CreateAccountButton_Click"/>
                <br />
                
            <asp:Label runat="server" ID="CreateAccountResults"></asp:Label>
    </div>
</asp:Content>
