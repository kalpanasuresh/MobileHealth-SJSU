<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Doctor_Profile" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/General/Health.master" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HealthCareConnectionString %>"
        DeleteCommand="DELETE FROM [Doctor] WHERE [DocId] = @DocId" InsertCommand="INSERT INTO [Doctor] ([secQues], [secAns], [LicType], [Title], [password], [FirstName], [LastName], [dateBirth], [Gender], [Email], [zip], [NationalProviderID], [PrimarySpl], [OffAddr], [City], [State], [phone]) VALUES (@secQues, @secAns, @LicType, @Title, @password, @FirstName, @LastName, @dateBirth, @Gender, @Email, @zip, @NationalProviderID, @PrimarySpl, @OffAddr, @City, @State, @phone)"
        OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT [DocId], [secQues], [secAns], [LicType], [Title], [password], [FirstName], [LastName], [dateBirth], [Gender], [Email], [zip], [NationalProviderID], [PrimarySpl], [OffAddr], [City], [State], [phone] FROM [Doctor] WHERE ([DocId] = @DocId)"
        UpdateCommand="UPDATE [Doctor] SET [secQues] = @secQues, [secAns] = @secAns, [LicType] = @LicType, [Title] = @Title, [password] = @password, [FirstName] = @FirstName, [LastName] = @LastName, [dateBirth] = @dateBirth, [Gender] = @Gender, [Email] = @Email, [zip] = @zip, [NationalProviderID] = @NationalProviderID, [PrimarySpl] = @PrimarySpl, [OffAddr] = @OffAddr, [City] = @City, [State] = @State, [phone] = @phone WHERE [DocId] = @DocId">
        <SelectParameters>
            <asp:SessionParameter Name="DocId" SessionField="DocID" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="DocId" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="secQues" Type="String" />
            <asp:Parameter Name="secAns" Type="String" />
            <asp:Parameter Name="LicType" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="password" Type="String" />
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="dateBirth" Type="DateTime" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="zip" Type="String" />
            <asp:Parameter Name="NationalProviderID" Type="String" />
            <asp:Parameter Name="PrimarySpl" Type="String" />
            <asp:Parameter Name="OffAddr" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="State" Type="String" />
            <asp:Parameter Name="phone" Type="String" />
            <asp:Parameter Name="DocId" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="secQues" Type="String" />
            <asp:Parameter Name="secAns" Type="String" />
            <asp:Parameter Name="LicType" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="password" Type="String" />
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="dateBirth" Type="DateTime" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="zip" Type="String" />
            <asp:Parameter Name="NationalProviderID" Type="String" />
            <asp:Parameter Name="PrimarySpl" Type="String" />
            <asp:Parameter Name="OffAddr" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="State" Type="String" />
            <asp:Parameter Name="phone" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
        DataKeyNames="DocId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Height="50px" Width="274px">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <Fields>
            <asp:BoundField DataField="DocId" HeaderText="DocId" InsertVisible="False" ReadOnly="True"
                SortExpression="DocId" />
            <asp:BoundField DataField="secQues" HeaderText="secQues" SortExpression="secQues" />
            <asp:BoundField DataField="secAns" HeaderText="secAns" SortExpression="secAns" />
            <asp:BoundField DataField="LicType" HeaderText="LicType" SortExpression="LicType" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="dateBirth" HeaderText="dateBirth" SortExpression="dateBirth" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="zip" HeaderText="zip" SortExpression="zip" />
            <asp:BoundField DataField="NationalProviderID" HeaderText="NationalProviderID" SortExpression="NationalProviderID" />
            <asp:BoundField DataField="PrimarySpl" HeaderText="PrimarySpl" SortExpression="PrimarySpl" />
            <asp:BoundField DataField="OffAddr" HeaderText="OffAddr" SortExpression="OffAddr" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:DetailsView>
</asp:Content>

