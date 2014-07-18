<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="DiagResult.aspx.cs" Inherits="Patient_DiagResult" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Text="You are diagnoised with" Width="131px" Font-Bold="True"></asp:Label></td>
            <td style="width: 100px">
                <asp:Label ID="lblName" runat="server" Text="Label" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="#FFFFFF"></asp:Label></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label5" runat="server" Text="You can take the following medication(s)" Font-Bold="True"></asp:Label></td>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Label" Font-Names="Arial" Font-Size="10pt" ForeColor="#FFFFFF"></asp:Label></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/General/SendSMS.aspx" OnClick="LinkButton1_Click" ForeColor="#FFFF00">Click here to send an SMS to doctor or set an appointment</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>

