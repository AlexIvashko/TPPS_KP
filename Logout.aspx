<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="travel_agency.Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container-fluid justify-content-center">
        <div class="container well">
            <p><h3><i>You have been logged out successfully.</i></h3></p>
            <p>
                <b>
                    <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx">To main page</asp:HyperLink>
                    <br />
                    <asp:HyperLink runat="server" NavigateUrl="~/Login.aspx">To login page</asp:HyperLink>
                </b>
            </p>
        </div>
    </div>
</asp:Content>
