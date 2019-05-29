<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="travel_agency.MainForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <div class="jumbotron">
            <h3>Топ-3 найпопулярніші готелі</h3>
             <asp:GridView ID="GridView1" runat="server"
          AutoGenerateColumns="false" 
          ShowFooter="False" ShowHeader="true"
          AllowPaging="true" PageSize="10"  
          Font-Size="14pt" 
          onpageindexchanging="GridView1_PageIndexChanging" 
          HorizontalAlign="Center" 
          CssClass="table table-hover table-bordered">
          <Columns>

            <asp:TemplateField HeaderText="Назва готелю"
              ItemStyle-Width="200">
              <ItemTemplate>
                <asp:Label id="myLabel1" runat="server"
                  Text='<%# Bind("Name")%>' />
              </ItemTemplate>
            </asp:TemplateField>
          
            <asp:TemplateField HeaderText="Сервіс"
              ItemStyle-Width="300">
              <ItemTemplate>
                <asp:Label id="myLabel2" runat="server"
                  Text='<%# Bind("Service")%>' />
              </ItemTemplate>
            </asp:TemplateField>
       
            <asp:TemplateField HeaderText="Країна розташування"
              ItemStyle-Width="300">
              <ItemTemplate>
                <asp:Label id="myLabel3" runat="server" Width="300"
                  Text='<%# Bind("Country.Name")%>' />
              </ItemTemplate>
            </asp:TemplateField>
           
          </Columns>
                 </asp:GridView>
    </div>
</asp:Content>
