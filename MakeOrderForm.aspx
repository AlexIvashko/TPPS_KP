<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="MakeOrderForm.aspx.cs" Inherits="travel_agency.MakeOrderForm" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-default">
        <asp:LoginView runat="server" ID="orderLoginView">
            <LoggedInTemplate>
                <div class="panel-body">
                    <asp:Label ID="labelMessage" runat="server"></asp:Label>
                    <table class="table table-responsive" style="align-items: center; text-align: center">
                        <thead>
                            <tr>
                                <td>Клієнт</td>
                                <td>Країна для поїздки</td>
                                <td>Готель</td>
                                <td>Кімната</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="clientList" runat="server" 
                                        CssClass="form-control" 
                                        OnTextChanged="clientList_TextChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="countryList" runat="server" CssClass="form-control"
                                        OnTextChanged="countryList_TextChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="hotelList" runat="server" CssClass="form-control"
                                        OnTextChanged="hotelList_TextChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="roomList" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Дата початку туру:</td>
                                <td>
                                    <asp:TextBox ID="TravelStarts" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                                <td>Дата кінця туру:</td>
                                <td>
                                    <asp:TextBox ID="TravelEnds" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr style="align-items: center;">
                                <td style="align-self: center;">
                                    <asp:Button ID="buttonAddOrder" runat="server" CssClass="btn btn-success" Text="Додати"
                                        value="Додати" OnClick="buttonAddOrder_click" />

                                    <input type="button" id="buttonCancel" class="btn btn-default" value="Відміна"
                                        onclick="goBack()" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </LoggedInTemplate>
            <AnonymousTemplate>
                <div class="panel-body">
                    <p>Only registered users are able to make orders.
                        <br />
                        <asp:HyperLink runat="server" 
                            NavigateUrl="~/Membership/CreatingUserAccounts.aspx">
                            Register now</asp:HyperLink>
                    </p>         
                </div>
            </AnonymousTemplate>
        </asp:LoginView>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        thead td {
            width:200px;
            font: bolder 16px Arial,Verdana;
            text-align:center;
        }
               
    </style>
    <link rel="Stylesheet" href="~/Content/bootstrap.min.css"/>
    <script type="text/javascript">
    function goBack()
      {
      window.history.back()
      }
    </script>
</asp:Content>