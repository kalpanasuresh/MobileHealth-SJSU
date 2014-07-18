<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="LinkDoc.aspx.cs" Inherits="Patient_LinkDoc" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %> 
<%@ Register Src="../General/GetDoctor.ascx" TagName="GetDoctor" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

    <div>
        <table>
            <caption>
                <span style="font-size: 14pt; color: #ffffff; font-family: Arial">Adding a Doctor</span></caption>
            <tr>
                <td style="width: 54px">
                    <asp:Label ID="Label1" runat="server" Text="Please enter doctor's last name" Width="114px" Font-Bold="True" ForeColor="#000000" Height="32px"></asp:Label></td>
                <td style="width: 55px">
                    <asp:TextBox ID="txtSearchValue" runat="server" MaxLength="20" Style="position: static"></asp:TextBox></td>
                <td style="width: 30px">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Style="position: static"
                        Text="Search" /></td>
            </tr>
            <tr>
                <td style="width: 54px">
                    <asp:Label ID="LBLdOC" runat="server" Font-Bold="True" Height="26px" Text="Select a doctor from the list"
                        Width="112px"></asp:Label></td>
                <td style="width: 55px">
                    <asp:ListBox ID="lstInstructors" runat="server"
                        Style="left: -227px; position: static; top: 87px" Visible="False" Width="186px" OnSelectedIndexChanged="lstInstructors_SelectedIndexChanged1">
                    </asp:ListBox>
                </td>
                <td style="width: 30px">
                    <br />
                    <br />
                    <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Doctor" Visible="False" /></td>
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
                <td colspan="2">
                    <strong>List of Doctors already addded:</strong></td>
                <td style="width: 30px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" Font-Names="Arial" Font-Size="10pt"
                        ForeColor="#333333" GridLines="None">
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    &nbsp;
                </td>
            </tr>
        </table>
        &nbsp;</div>
</asp:Content>

