<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="Analysis.aspx.cs" Inherits="Doctor_Analysis" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
 <div>
        <table>
            <tr>
                <td colspan="4" style="height: 13px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Please select an option below and enter search criteria"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 69px" valign="top" align="left">
        <asp:Label ID="Label1" runat="server" Text="Select a Type" Font-Bold="True" Width="80px"></asp:Label></td>
                <td style="width: 80px" valign="top" align="left">
                    <asp:DropDownList
            ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Disease</asp:ListItem>
            <asp:ListItem>Symptom</asp:ListItem>
            <asp:ListItem>Medication</asp:ListItem>
                        <asp:ListItem>Name</asp:ListItem>
        </asp:DropDownList></td>
                <td style="width: 100px" align="left" valign="top">
        <asp:TextBox ID="TextBox1" runat="server" Width="202px"></asp:TextBox>
                    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"
                        Visible="False" Width="202px" Height="99px"></asp:ListBox></td>
                <td style="width: 45px" valign="top" align="left">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ListBox1"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
        </table>
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="#FF6666"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        &nbsp;
    
    </div>
</asp:Content>

