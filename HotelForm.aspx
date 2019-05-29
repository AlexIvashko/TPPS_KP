<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="HotelForm.aspx.cs" Inherits="travel_agency.HotelForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main"
    runat="server">
    <div class="container-fluid">
        <div class="well">
            <h3>Таблиця "Готелі"</h3>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="false"
                ShowFooter="true" ShowHeader="true"
                AllowPaging="true" PageSize="10"
                OnRowDeleting="GridView1_RowDeleting" Font-Size="14pt"
                OnRowEditing="GridView1_RowEditing"
                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowCommand="GridView1_RowCommand"
                OnRowDataBound="GridView1_RowDataBound"
                OnPreRender="GridView1_PreRender"
                onRowCreated="GridView1_RowCreated"
                CssClass="table table-hover table-bordered justify-content-center">
                <Columns>

                    <asp:TemplateField HeaderText="Назва готелю">
                        <ItemTemplate>
                            <asp:Label ID="myLabel1" runat="server"
                                Text='<%# Bind("Name")%>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="myTextBox1" runat="server" Width="200" CssClass="form-control"
                                Text='<%# Bind("Name") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="myFooterTextBox1" runat="server" CssClass="form-control"
                                Text='<%# Bind("Name") %>' />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Сервіс">
                        <ItemTemplate>
                            <asp:Label ID="myLabel2" runat="server"
                                Text='<%# Bind("Service")%>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="myTextBox2" runat="server" CssClass="form-control"
                                Text='<%# Bind("Service") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="myFooterTextBox2" runat="server" CssClass="form-control"
                                Text='<%# Bind("Service") %>' />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Країна розташування">
                        <ItemTemplate>
                            <asp:Label ID="myLabel3" runat="server"
                                Text='<%# Bind("Country.Name")%>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="EditCountryList" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="AddCountryList" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Операції">
                        <ItemTemplate>
                            <div class="d-flex justify-content-center">
                                <asp:Button ID="ibEdit" runat="server"
                                    CommandName="Edit"
                                    CssClass="btn btn-secondary" Text="Edit" />
                                <asp:Button ID="ibDelete" runat="server"
                                    CommandName="Delete" Text="Delete"
                                    CssClass="btn btn-danger" />
                                <asp:Button ID="IbSelect" runat="server"
                                    CommandName="Select" Text="Show rooms"
                                    CssClass="btn btn-info" 
                                    CommandArgument='<%# Container.DataItemIndex %>' />
                            </div>
                        </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="ibUpdate" runat="server"
                            CommandName="Update" Text="Update"
                            CssClass="btn btn-info" />
                        <asp:Button ID="ibCancel" runat="server"
                            CommandName="Cancel" Text="Cancel"
                            CssClass="btn btn-toolbar" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="ibInsert" runat="server"
                            CommandName="Insert" OnClick="ibInsert_Click"
                            CssClass="btn btn-success" Text="Add item"/>
                    </FooterTemplate>
                </asp:TemplateField>
                </Columns>


                <EmptyDataTemplate>
                    <table class="table table-hover table-bordered justify-content-center">
                        <tr>
                            <td>Назва готелю</td>
                            <td>Сервіс</td>
                            <td>Країна розташування</td>
                            <td>Операції</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="emptyGroupNameTextBox" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="emptyCuratorNameTextBox" runat="server" />
                            </td>
                            <td>
                                <asp:DropDownList ID="EmptyCountryList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:ImageButton ID="emptyImageButton" runat="server"
                                    ImageUrl="~/img/add.png"
                                    OnClick="ibInsertInEmpty_Click" CssClass="image-buttons" />
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <PagerStyle HorizontalAlign="Center" />

            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style5 {
            height: 32px;
            font: bolder 16px Arial,Verdana;
            text-align:center;
            vertical-align:bottom;
        }
        .image-buttons
        {
            height: 25px;
            width:  25px;
        }
       
    </style>
</asp:Content>
