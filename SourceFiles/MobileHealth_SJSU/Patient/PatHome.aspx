<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="PatHome.aspx.cs" Inherits="Patient_PatHome" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

    <div>
        &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
            Text="Welcome "></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
    </div>
</asp:Content>

