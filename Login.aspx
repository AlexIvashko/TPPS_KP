<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="travel_agency.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <div class="container h=100">
        <div class="row justify-content-center">
            <div class="col-12">
                <h1>Login</h1>
                <div class="form-group">
                    <label for="UserName">Enter your login</label>
                    <asp:TextBox runat="server"
                        CssClass="form-control col-md-4" placeholder="Login" ID="UserName" />
                </div>
                <div class="form-group">
                    <label for="Password">Password:</label>
                    <asp:TextBox runat="server" ID="Password"
                        type="Password" class="form-control col-md-4" placeholder="Password"></asp:TextBox>
                </div>
                <p>
                    <asp:CheckBox runat="server" ID="RememberMe" Text="Remember Me" />
                </p>
                <p>
                    <asp:Button runat="server" ID="LoginButton"
                        CssClass="btn btn-secondary" Text="Login" OnClick="LoginButton_Click" />
                </p>
                <p>
                    <asp:HyperLink runat="server" NavigateUrl="~/Membership/CreateUserAccountWithWizard.aspx">
                    Create account
                    </asp:HyperLink>
                </p>
                <p>
                    <asp:Label runat="server" ID="InvalidCredentialsMessage"
                        Text="Your username or password is invalid. Please try again."
                        Visible="False" />
                </p>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
    .c1 
    {   
        width: 200px;
    }

    </style>
</asp:Content>
