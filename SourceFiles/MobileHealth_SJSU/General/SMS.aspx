<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="SMS.aspx.cs" Inherits="General_SMS" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %> 
<%@ Register Src="GetDoctor.ascx" TagName="GetDoctor" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<div style="background-color:White">
        <table style="width: 394px">
            <tr>
                <td style="width: 54px">
                    <asp:Label ID="Label3" runat="server" Text="Last Name" Width="74px"></asp:Label></td>
                <td style="width: 55px">
                    <asp:TextBox ID="txtSearchValue" runat="server" MaxLength="20" Style="position: static"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSearchValue"
                        ErrorMessage="*" ValidationGroup="Search"></asp:RequiredFieldValidator></td>
                <td style="width: 30px">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Style="position: static"
                        Text="Search" ValidationGroup="Search" /></td>
            </tr>
            <tr>
                <td style="width: 54px">
                </td>
                <td style="width: 55px">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Height="21px" Width="188px"></asp:Label></td>
                <td style="width: 30px">
                </td>
            </tr>
            <tr>
                <td style="width: 54px">
                </td>
                <td style="width: 55px">
                    <asp:ListBox ID="lstInstructors" runat="server" OnSelectedIndexChanged="lstInstructors_SelectedIndexChanged"
                        Style="left: -227px; position: static; top: 87px" Visible="False" Width="186px">
                    </asp:ListBox>
                </td>
                <td style="width: 30px">
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="Subject" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtSubject" runat="server" Width="181px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSubject"
                        ErrorMessage="*" ValidationGroup="send"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" Text="Message" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtMessage" runat="server" MaxLength="160" TextMode="MultiLine"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Button ID="cmdSend" runat="server" OnClick="cmdSend_Click" Text="Send" ValidationGroup="send" /></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>

