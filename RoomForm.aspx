<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="RoomForm.aspx.cs" Inherits="travel_agency.RoomForm" %>

<asp:content id="Content1" contentplaceholderid="Main"
    runat="server">
    <table id="table1" style="width:100%; height: 283px; margin-top: 0px;">
    <tr>
        <td class="auto-style5"><div class="well"><h3>
            <asp:Label id="hotelLabel" runat="server"></asp:Label></h3></div></td>
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
          onrowupdating="GridView1_RowUpdating" CssClass="table table-hover table-bordered">
          <Columns>

            <asp:TemplateField HeaderText="Номер"
              ItemStyle-Width="200">
              <ItemTemplate>
                <asp:Label id="myLabel1" runat="server"
                  Text='<%# Bind("Number")%>' />
              </ItemTemplate>
              <EditItemTemplate>
                <asp:TextBox ID="myTextBox1" runat="server" Width="200" CssClass="form-control"
                  Text='<%# Bind("Number") %>'/>
              </EditItemTemplate>
              <FooterTemplate>
                 <asp:TextBox ID="myFooterTextBox1" runat="server" CssClass="form-control"
                   Width="200" Text='<%# Bind("Number") %>' />
              </FooterTemplate>
            </asp:TemplateField>
          
            <asp:TemplateField HeaderText="Тип"
              ItemStyle-Width="200">
              <ItemTemplate>
                <asp:Label id="myLabel2" runat="server"
                  Text='<%# Bind("Type")%>' />
              </ItemTemplate>
              <EditItemTemplate>
                <asp:DropDownList ID="EditTypesList" runat="server" CssClass="form-control">
                </asp:DropDownList>
              </EditItemTemplate>
              <FooterTemplate>
                <asp:DropDownList ID="AddTypesList" runat="server" CssClass="form-control">
                </asp:DropDownList>
              </FooterTemplate>
            </asp:TemplateField>
       
            <asp:TemplateField HeaderText="К-ть місць"
              ItemStyle-Width="200">
              <ItemTemplate>
                <asp:Label id="myLabel3" runat="server"
                  Text='<%# Bind("Size")%>' />
              </ItemTemplate>
              <EditItemTemplate>
                <asp:TextBox ID="myTextBox3" runat="server" Width="200" CssClass="form-control"
                  Text='<%# Bind("Size") %>'/>
              </EditItemTemplate>
              <FooterTemplate>
                <asp:TextBox ID="myFooterTextBox3" runat="server" CssClass="form-control"
                  Width="200" Text='<%# Bind("Size") %>' />
              </FooterTemplate>
            </asp:TemplateField>
           
           <asp:TemplateField HeaderText="Ціна за добу"
              ItemStyle-Width="200">
              <ItemTemplate>
                <asp:Label id="myLabel4" runat="server"
                  Text='<%# Bind("Price")%>' />
              </ItemTemplate>
              <EditItemTemplate>
                <asp:TextBox ID="myTextBox4" runat="server" Width="200" CssClass="form-control"
                  Text='<%# Bind("Price") %>'/>
              </EditItemTemplate>
              <FooterTemplate>
                <asp:TextBox ID="myFooterTextBox4" runat="server" CssClass="form-control"
                  Width="200" Text='<%# Bind("Price") %>' />
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
            <table class="table table-bordered">
              <tr>
                <td width="200" align="center">Номер</td>
                <td width="200" align="center">Тип</td>
                <td width="200" align="center">К-ть місць</td>
                <td width="200" align="center">Ціна за добу</td>
                <td>Операції</td>
              </tr>
              <tr>
                <td>
                  <asp:TextBox ID="emptyNumberTextBox" runat="server" CssClass="form-control"
                    Width="200"/>
                </td>
                <td>
                  <asp:DropDownList ID="emptyTypesList" runat="server" CssClass="form-control"></asp:DropDownList>
                </td>
                <td>
                  <asp:TextBox ID="emptySizeTextBox" runat="server" CssClass="form-control"
                    Width="200"/>
                </td>
                  <td>
                  <asp:TextBox ID="emptyPriceTextBox" runat="server" CssClass="form-control"
                    Width="200"/>
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
<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
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