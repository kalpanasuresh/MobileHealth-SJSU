<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="Health.aspx.cs" Inherits="Patient_Health" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<asp:Panel ID="Panel1" runat="server" GroupingText="Please enter your information here">
        <table>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" Text="Type"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        Width="128px">
                        <asp:ListItem>Height</asp:ListItem>
                        <asp:ListItem>Weight</asp:ListItem>
                        <asp:ListItem>Blood Pressure</asp:ListItem>
                        <asp:ListItem>Heart Reat</asp:ListItem>
                        <asp:ListItem>Test</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtTest" runat="server" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="Result/comment"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtName" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" Text="Measure"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtMeasure" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label4" runat="server" Text="Date Performed"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                </td>
                <td style="width: 100px">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDate"
                        ErrorMessage="Not a valid date" Type="Date" Operator="DataTypeCheck"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                    <asp:Literal ID="Error" runat="server"></asp:Literal></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="White"
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1"
            Font-Names="Arial" Font-Size="7pt" ForeColor="Black" GridLines="Vertical" Width="350px">
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#CCCCCC" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HealthCareConnectionString %>"
            SelectCommand="SELECT [PatientID], [Type], [Measure], [Results], [dateCreated], [other] FROM [MedicalInfo] WHERE ([PatientID] = @PatientID)">
            <SelectParameters>
                <asp:SessionParameter Name="PatientID" SessionField="PatientID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
</asp:Content>

