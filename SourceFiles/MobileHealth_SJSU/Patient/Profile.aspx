<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Patient_Profile" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/General/Health.master" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
        DataKeyNames="PatientID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Height="50px" Width="253px">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <Fields>
            <asp:BoundField DataField="PatientID" HeaderText="PatientID" InsertVisible="False"
                ReadOnly="True" SortExpression="PatientID" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="dateBirth" HeaderText="dateBirth" SortExpression="dateBirth" />
            <asp:BoundField DataField="strEmail" HeaderText="strEmail" SortExpression="strEmail" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
            <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
            <asp:BoundField DataField="zip" HeaderText="zip" SortExpression="zip" />
            <asp:BoundField DataField="locOfPolicy" HeaderText="locOfPolicy" SortExpression="locOfPolicy" />
            <asp:BoundField DataField="Insurance" HeaderText="Insurance" SortExpression="Insurance" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
            <asp:BoundField DataField="secQues" HeaderText="secQues" SortExpression="secQues" />
            <asp:BoundField DataField="secAns" HeaderText="secAns" SortExpression="secAns" />
            <asp:BoundField DataField="provider" HeaderText="provider" SortExpression="provider" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HealthCareConnectionString %>"
        DeleteCommand="DELETE FROM [Patient] WHERE [PatientID] = @PatientID" InsertCommand="INSERT INTO [Patient] ([FirstName], [LastName], [dateBirth], [strEmail], [Address], [city], [state], [zip], [locOfPolicy], [Insurance], [Gender], [phone], [password], [secQues], [secAns], [provider]) VALUES (@FirstName, @LastName, @dateBirth, @strEmail, @Address, @city, @state, @zip, @locOfPolicy, @Insurance, @Gender, @phone, @password, @secQues, @secAns, @provider)"
        SelectCommand="SELECT [PatientID], [FirstName], [LastName], [dateBirth], [strEmail], [Address], [city], [state], [zip], [locOfPolicy], [Insurance], [Gender], [phone], [password], [secQues], [secAns], [provider] FROM [Patient] WHERE ([PatientID] = @PatientID)"
        UpdateCommand="UPDATE [Patient] SET [FirstName] = @FirstName, [LastName] = @LastName, [dateBirth] = @dateBirth, [strEmail] = @strEmail, [Address] = @Address, [city] = @city, [state] = @state, [zip] = @zip, [locOfPolicy] = @locOfPolicy, [Insurance] = @Insurance, [Gender] = @Gender, [phone] = @phone, [password] = @password, [secQues] = @secQues, [secAns] = @secAns, [provider] = @provider WHERE [PatientID] = @PatientID">
        <SelectParameters>
            <asp:SessionParameter Name="PatientID" SessionField="PatientID" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="PatientID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="dateBirth" Type="DateTime" />
            <asp:Parameter Name="strEmail" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="city" Type="String" />
            <asp:Parameter Name="state" Type="String" />
            <asp:Parameter Name="zip" Type="String" />
            <asp:Parameter Name="locOfPolicy" Type="String" />
            <asp:Parameter Name="Insurance" Type="String" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="phone" Type="String" />
            <asp:Parameter Name="password" Type="String" />
            <asp:Parameter Name="secQues" Type="String" />
            <asp:Parameter Name="secAns" Type="String" />
            <asp:Parameter Name="provider" Type="String" />
            <asp:Parameter Name="PatientID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="dateBirth" Type="DateTime" />
            <asp:Parameter Name="strEmail" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="city" Type="String" />
            <asp:Parameter Name="state" Type="String" />
            <asp:Parameter Name="zip" Type="String" />
            <asp:Parameter Name="locOfPolicy" Type="String" />
            <asp:Parameter Name="Insurance" Type="String" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="phone" Type="String" />
            <asp:Parameter Name="password" Type="String" />
            <asp:Parameter Name="secQues" Type="String" />
            <asp:Parameter Name="secAns" Type="String" />
            <asp:Parameter Name="provider" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>

