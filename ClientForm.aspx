<%@ Page Title="ASP.NET" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="ClientForm.aspx.cs" Inherits="travel_agency.ClientForm" %>
<asp:content id="Content1" contentplaceholderid="Main" runat="server">
    <table id="table1" style="width:100%; height:300px; margin-top: 0px;">
    <tr>
        <td class="auto-style5"><div class="well"><h3>Таблиця "Клієнти"</h3></div></td>
    </tr>
    <tr valign="top">
        <td>
            <asp:GridView ID="GridView1" runat="server"
                 AutoGenerateColumns="false" 
          ShowFooter="true" ShowHeader="true"
          AllowPaging="true" PageSize="10"  
          onrowdeleting="GridView1_RowDeleting" Font-Size="14pt" 
          onrowediting="GridView1_RowEditing" 
          onrowcancelingedit="GridView1_RowCancelingEdit" 
          onpageindexchanging="GridView1_PageIndexChanging" 
          HorizontalAlign="Center" 
          onrowupdating="GridView1_RowUpdating" 
          onrowdatabound="GridView1_RowDataBound"
          CssClass="table table-hover table-bordered">
          <Columns>

            <asp:TemplateField HeaderText="ПІБ Клієнта"
              ItemStyle-Width="200">
              <ItemTemplate>
                <asp:Label id="myLabel1" runat="server"
                  Text='<%# Bind("Name")%>' />
              </ItemTemplate>
              <EditItemTemplate>
                <asp:TextBox ID="myTextBox1" runat="server" Width="200" CssClass="form-control"
                  Text='<%# Bind("Name") %>'/>
              </EditItemTemplate>
              <FooterTemplate>
                 <asp:TextBox ID="myFooterTextBox1" runat="server" CssClass="form-control"
                   Width="200" Text='<%# Bind("Name") %>' />
              </FooterTemplate>
            </asp:TemplateField>
          
            <asp:TemplateField HeaderText="Вік клієнта"
              ItemStyle-Width="300">
              <ItemTemplate>
                <asp:Label id="myLabel2" runat="server"
                  Text='<%# Bind("Age")%>' />
              </ItemTemplate>
              <EditItemTemplate>
                <asp:TextBox ID="myTextBox2" runat="server" Width="300" CssClass="form-control"
                  Text='<%# Bind("Age") %>'/>
              </EditItemTemplate>
              <FooterTemplate>
                <asp:TextBox ID="myFooterTextBox2" runat="server" Width="300" CssClass="form-control"
                  Text='<%# Bind("Age") %>' />
              </FooterTemplate>
            </asp:TemplateField>
       
            <asp:TemplateField HeaderText="Батьківщина"
              ItemStyle-Width="300">
              <ItemTemplate>
                <asp:Label id="myLabel3" runat="server" Width="300"
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
              <EditItemTemplate>
                <asp:ImageButton ID="ibUpdate" runat="server" 
                  CommandName="Update"
                  ImageUrl="~/img/update.png" CssClass="image-buttons" />
                <asp:ImageButton ID="ibCancel" runat="server" 
                  CommandName="Cancel"
                  ImageUrl="~/img/cancel.png" CssClass="image-buttons" />
              </EditItemTemplate>
              <FooterTemplate>
                <asp:ImageButton ID="ibInsert" runat="server" 
                  CommandName="Insert" OnClick="ibInsert_Click" 
                  ImageUrl="~/img/add.png" CssClass="image-buttons" /> 
              </FooterTemplate>
            </asp:TemplateField>
          </Columns>

         
          <EmptyDataTemplate>
            <table border="2" cellpadding="0" cellspacing="0">
              <tr>
                <td width="200" align="center">ПІБ Клієнта</td>
                <td width="300" align="center">Вік</td>
                <td width="300" align="center">Рідна країна</td>
                <td>Операції</td>
              </tr>
              <tr>
                <td>
                  <asp:TextBox ID="emptyClientNameTextBox" runat="server" CssClass="form-control"
                    Width="200"/>
                </td>
                <td>
                  <asp:TextBox ID="emptyClientAgeTextBox" runat="server" CssClass="form-control"
                    Width="300"/>
                </td>
                <td>
                 <asp:DropDownList ID="EmptyCountryList" runat="server" CssClass="form-control">
                </asp:DropDownList>
                </td>
                <td align="center">
                  <asp:ImageButton ID="emptyImageButton" runat="server" 
                    ImageUrl="~/img/add.png" 
                    OnClick="ibInsertInEmpty_Click" CssClass="image-buttons" />
                </td> 
              </tr>
            </table>
          </EmptyDataTemplate>
          <PagerStyle HorizontalAlign ="Center" />
            </asp:GridView>
 </td>
    </tr>
</table>
</asp:content>
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
