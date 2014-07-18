<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GetDoctor.ascx.cs" Inherits="General_GetDoctor" %>
<table>
    <tr>
        <td style="width: 54px">
            <asp:Label ID="Label1" runat="server" Text="Last Name" Width="74px"></asp:Label></td>
        <td style="width: 55px">
            <asp:TextBox ID="txtSearchValue" runat="server" MaxLength="20" Style="position: static"></asp:TextBox></td>
        <td style="width: 30px">
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Style="position: static"
                Text="Search" /></td>
    </tr>
    <tr>
        <td style="width: 54px">
        </td>
        <td style="width: 55px">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Width="188px" Height="21px"></asp:Label></td>
        <td style="width: 30px">
        </td>
    </tr>
    <tr>
        <td style="width: 54px">
        </td>
        <td style="width: 55px">
<asp:ListBox ID="lstInstructors" runat="server" Style="left: -227px; position:static;
    top: 87px" Visible="False" Width="186px" OnSelectedIndexChanged="lstInstructors_SelectedIndexChanged"></asp:ListBox>
        </td>
        <td style="width: 30px">
        </td>
    </tr>
</table>
