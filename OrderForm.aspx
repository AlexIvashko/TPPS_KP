<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="OrderForm.aspx.cs" Inherits="travel_agency.OrderForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <asp:LoginView ID="loginViewOrders" runat="server">
        <LoggedInTemplate>

        </LoggedInTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Administrator,Supervisor">
                <ContentTemplate>
                    <div class="well">
                        <h3>Таблиця "Замовлення"</h3>
                    </div>

                    <asp:Label ID="labl" runat="server"></asp:Label>
                    <asp:GridView ID="GridView1" runat="server"
                        AutoGenerateColumns="false"
                        ShowFooter="false" ShowHeader="true"
                        AllowPaging="true" PageSize="10"
                        OnRowDeleting="GridView1_RowDeleting" Font-Size="14pt"
                        OnRowEditing="GridView1_RowEditing"
                        OnPageIndexChanging="GridView1_PageIndexChanging"
                        HorizontalAlign="Center"
                        OnRowDataBound="GridView1_RowDataBound"
                        CssClass="table table-hover table-bordered">
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="myLabel0" runat="server"
                                        Text='<%# Bind("Id")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ПІБ Клієнта">
                                <ItemTemplate>
                                    <asp:Label ID="myLabel1" runat="server"
                                        Text='<%# Bind("Client.Name")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Країна туру">
                                <ItemTemplate>
                                    <asp:Label ID="myLabel2" runat="server"
                                        Text='<%# Bind("Room.Hotel.Country.Name")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Готель">
                                <ItemTemplate>
                                    <asp:Label ID="myLabel3" runat="server"
                                        Text='<%# Bind("Room.Hotel.Name")%>' />
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Номер в готелі">
                                <ItemTemplate>
                                    <asp:Label ID="myLabel4" runat="server"
                                        Text='<%# Bind("Room.Number")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Початок туру">
                                <ItemTemplate>
                                    <asp:Label ID="myLabel5" runat="server"
                                        Text='<%# Bind("Travel_starts")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Кінець туру">
                                <ItemTemplate>
                                    <asp:Label ID="myLabel6" runat="server"
                                        Text='<%# Bind("Travel_ends")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ціна">
                                <ItemTemplate>
                                    <asp:Label ID="myLabel7" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Операції" ItemStyle-HorizontalAlign="Center"
                                FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibEdit" runat="server"
                                        CommandName="Edit"
                                        ImageUrl="~/img/edit.png" CssClass="image-buttons" />
                                    <asp:ImageButton ID="ibDelete" runat="server"
                                        CommandName="Delete"
                                        ImageUrl="~/img/delete.png" CssClass="image-buttons" />
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>

                        <EmptyDataTemplate>
                            <div class="well">
                                <h4>На даний момент замовлень немає</h4>
                            </div>
                        </EmptyDataTemplate>
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
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
    <link rel="Stylesheet" href="~/Content/bootstrap.min.css"/>
</asp:Content>