<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="General_Login" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %>  
<%@ Register TagPrefix="cc1" Namespace="WebControlCaptcha" Assembly="WebControlCaptcha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;
        background-color: lemonchiffon; width: 217px; height: 9px;">
        <tbody>
            <tr>
                <td>
                    <table border="0" cellpadding="0">
                        <tbody>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="Label1" runat="server" Alignment="Center" Font-Bold="True" Font-Size="Small">Log In</asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 63px; height: 24px">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Size="9pt">User Name:</asp:Label></td>
                                <td style="width: 3px; height: 24px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 63px; height: 24px">
                                    <asp:TextBox ID="UserName" runat="server" Height="18px" OnTextChanged="UserName_TextChanged"
                                        Width="88px"></asp:TextBox></td>
                                <td style="width: 3px; height: 24px">
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 63px">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Size="9pt">Password:</asp:Label></td>
                                <td style="width: 3px">
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 63px">
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="91px"></asp:TextBox></td>
                                <td style="width: 3px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 63px">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Size="Smaller" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="122px" BackColor="Transparent">
                                        <asp:ListItem Selected="True">Doctor</asp:ListItem>
                                        <asp:ListItem>Patient</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td style="width: 3px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 63px">
                                <cc1:captchacontrol id="CaptchaControl1" runat="server" Height="28px" Width="188px" ></cc1:captchacontrol>
            &nbsp;
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="185px" />
                                </td>
                                <td style="width: 3px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 13px">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: red; height: 20px;">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" OnClick="LoginButton_Click"
                                        Text="Log In" ValidationGroup="Login" /></td>
                            </tr>
                        </tbody>
                    </table>
                   
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Panel ID="Panel1" runat="server" BackColor="Silver" GroupingText="Registration" Font-Bold="True" HorizontalAlign="Justify">
                        &nbsp;
                        <asp:RadioButtonList
            ID="Radiobuttonlist2" runat="server" Font-Size="Smaller" OnSelectedIndexChanged="Radiobuttonlist2_SelectedIndexChanged"
            RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" BackColor="White" Font-Bold="True" Width="129px">
            <asp:ListItem>Doctor</asp:ListItem>
            <asp:ListItem>Patient</asp:ListItem>
        </asp:RadioButtonList></asp:Panel>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>

