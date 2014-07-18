<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MCWebUserControl.ascx.cs" Inherits="Patient_MCWebUserControl" %>
<asp:gridview id="GridView1" runat="server" cellpadding="4" forecolor="#333333" gridlines="None" datasourceid="ObjectDataSource1" allowpaging="True" allowsorting="True" font-size="XX-Small" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField DataField="Doctor Name" HeaderText="Doctor Name" SortExpression="Doctor Name" />
        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
        <asp:BoundField DataField="Message" HeaderText="Message" SortExpression="Message" />
        <asp:BoundField DataField="DateSent" HeaderText="DateSent" SortExpression="DateSent" />
    </Columns>
</asp:gridview>
<asp:objectdatasource id="ObjectDataSource1" runat="server" oldvaluesparameterformatstring="original_{0}"
    selectmethod="GetData" typename="DataSet1TableAdapters.DataTable1TableAdapter"><SelectParameters>
<asp:SessionParameter SessionField="PatientID" Name="Param1" Type="String"></asp:SessionParameter>
</SelectParameters>
</asp:objectdatasource>
&nbsp;&nbsp;
