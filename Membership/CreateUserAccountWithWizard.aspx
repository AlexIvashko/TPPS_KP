<%@ Page Title="" Language="C#" MasterPageFile="~/Agency.Master" AutoEventWireup="true" CodeBehind="CreateUserAccountWithWizard.aspx.cs" Inherits="travel_agency.Membership.CreateUserAccountWithWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        height: 33px;
    }
    .auto-style6 {
        width: 280px;
    }
    .auto-style9 {
        height: 26px;
    }
    .userDataForm {
        align: center;
        justify-content: center;
        background-color: #dddddd;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" CssClass="userDataForm" Width="500px">
    <WizardSteps>
        <asp:CreateUserWizardStep runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="center" colspan="2" class="auto-style9">Sign Up for Your New Account</td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                ControlToValidate="UserName" 
                                ErrorMessage="User Name is required." 
                                ToolTip="User Name is required." 
                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6">
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                ControlToValidate="Password" 
                                ErrorMessage="Password is required." 
                                ToolTip="Password is required." 
                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style6">
                            <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                ControlToValidate="ConfirmPassword" 
                                ErrorMessage="Confirm Password is required." 
                                ToolTip="Confirm Password is required." 
                                ValidationGroup="CreateUserWizard1">*

                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style4">
                            <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                ValidationGroup="CreateUserWizard1">
                                *</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                ControlToCompare="Password" 
                                ControlToValidate="ConfirmPassword" 
                                Display="Dynamic" 
                                ErrorMessage="The Password and Confirmation Password must match." 
                                ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="color:Red;">
                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:CreateUserWizardStep>
        <asp:CompleteWizardStep runat="server" />
    </WizardSteps>
</asp:CreateUserWizard>

</asp:Content>
