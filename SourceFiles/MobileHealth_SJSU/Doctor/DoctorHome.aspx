<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="DoctorHome.aspx.cs" Inherits="Doctor_DoctorHome" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
 <div>
     <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
         Text="Welcome "></asp:Label><br />
     <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="List of all the patients linked to you"></asp:Label><br />

     <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
         <tr>
             <td style="width: 184px" valign="top">
                  <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Font-Names="Arial" Font-Size="8pt" EmptyDataText="No patients are found" Width="422px">
                      <FooterStyle BackColor="#CCCC99" />
                      <RowStyle BackColor="#F7F7DE" />
                      <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                      <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                      <AlternatingRowStyle BackColor="White" />
     </asp:GridView>
                 &nbsp; &nbsp;
             </td>
         </tr>
     </table>
  
    </div>
</asp:Content>

