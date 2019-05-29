<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="CountryForm.aspx.cs" Inherits="travel_agency.CountryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <div class="well">
        <h3>Таблиця "Країни"</h3>
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
            HorizontalAlign="Center"
            OnRowUpdating="GridView1_RowUpdating" 
            OnPreRender="GridView1_PreRender"
            CssClass="table table-hover table-bordered">
            <Columns>

                <asp:TemplateField HeaderText="Назва">
                    <ItemTemplate>
                        <asp:Label ID="myLabel1" runat="server" Text='<%# Bind("Name")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="myTextBox1" runat="server"
                            CssClass="form-control"
                            Text='<%# Bind("Name") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="myFooterTextBox1" runat="server"
                            CssClass="form-control"
                            Text='<%# Bind("Name") %>' />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Столиця">
                    <ItemTemplate>
                        <asp:Label ID="myLabel2" runat="server"
                            Text='<%# Bind("Capital")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="myTextBox2" runat="server" CssClass="form-control"
                            Text='<%# Bind("Capital") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="myFooterTextBox2" runat="server" CssClass="form-control"
                            Text='<%# Bind("Capital") %>' />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Мова">
                    <ItemTemplate>
                        <asp:Label ID="myLabel3" runat="server"
                            Text='<%# Bind("Language")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="myTextBox3" runat="server"  CssClass="form-control"
                            Text='<%# Bind("Language") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="myFooterTextBox3" runat="server" CssClass="form-control"
                           Text='<%# Bind("Language") %>' />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Валюта">
                    <ItemTemplate>
                        <asp:Label ID="myLabel4" runat="server"
                            Text='<%# Bind("Currency")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="myTextBox4" runat="server" CssClass="form-control"
                            Text='<%# Bind("Currency") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="myFooterTextBox4" runat="server" CssClass="form-control"
                            Text='<%# Bind("Currency") %>' />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Релігія">
                    <ItemTemplate>
                        <asp:Label ID="myLabel5" runat="server"
                            Text='<%# Bind("Religion")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="myTextBox5" runat="server"  CssClass="form-control"
                            Text='<%# Bind("Religion") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="myFooterTextBox5" runat="server" CssClass="form-control"
                            Text='<%# Bind("Religion") %>' />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Операції" ItemStyle-HorizontalAlign="Center"
                    FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <div class="d-flex justify-content-center">
                        <asp:Button ID="ibEdit" runat="server"
                            CommandName="Edit"
                            CssClass="btn btn-secondary" Text="Edit"/>
                        <asp:Button ID="ibDelete" runat="server"
                            CommandName="Delete" Text="Delete"
                            CssClass="btn btn-danger" />
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
                <table class="table table-bordered">
                    <tr>
                        <td>Назва</td>
                        <td>Столиця</td>
                        <td>Мова</td>
                        <td>Валюта</td>
                        <td>Релігія</td>
                        <td>Операції</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="emptyNameTextBox" runat="server" 
                                CssClass="form-control"/>
                        </td>
                        <td>
                            <asp:TextBox ID="emptyCapitalTextBox" 
                                runat="server" CssClass="form-control" />
                        </td>
                        <td>
                            <asp:TextBox ID="emptyLanguageTextBox" 
                                runat="server" CssClass="form-control"/>
                        </td>
                        <td>
                            <asp:TextBox ID="emptyCurrencyTextBox" runat="server" 
                                CssClass="form-control" />
                        </td>
                        <td>
                            <asp:TextBox ID="emptyReligionTextBox" runat="server" 
                                CssClass="form-control" />
                        </td>
                        <td>
                            <asp:Button ID="emptButton" runat="server"
                                OnClick="ibInsertInEmpty_Click" CssClass="btn btn-secondary" />
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <PagerStyle HorizontalAlign="Center" />

        </asp:GridView>
    </div>
</asp:Content>
