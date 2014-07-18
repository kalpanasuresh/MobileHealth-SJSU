<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="Patient_FileUpload" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/General/Health.master" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
	<asp:label id="lblFile" runat="server" Font-Bold="True">Picture:</asp:label>
				<input id="filMyFile" type="file" runat="server">
				<p></p>
				<asp:button id="cmdSend" runat="server" Text="Send" OnClick="cmdSend_Click"/>
				<p></p>
				<asp:Label id="lblInfo" runat="server" Font-Bold="True" Visible="false"></asp:Label>
				<p></p>
				<table>
						<tr>
							<td>
								<asp:Label id="lblText1" runat="server" Font-Bold="True" Visible="false">This was stored as file</asp:Label>
							</td>
							<td>
								<asp:Label id="lblText2" runat="server" Font-Bold="True" Visible="false">This was stored in database</asp:Label>
							</td>
						</tr>
						<tr>
							<td>
								<asp:Image id="imgFile" runat="server" Visible="False"></asp:Image>
							</TD>
							<td>
								<asp:Image id="imgDB" runat="server" Visible="False"></asp:Image>
							</td>
						</TR>
				</TABLE>
        <br />
        <asp:DataList ID="DataList2" runat="server" CellSpacing="2" DataSourceID="SqlDataSource1"
            ItemStyle-CssClass="unselected"
            RepeatColumns="2" SelectedIndex="0" SelectedItemStyle-CssClass="selected">
            <ItemStyle CssClass="unselected" />
            <SelectedItemStyle CssClass="selected" />
            <ItemTemplate>
                &nbsp;<br />
                &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl='<%# "imagefetch.ashx?size=1&imageid=" + Convert.ToString(Eval("Fileid"))+"&PatientID="+Convert.ToInt32(Eval("PatientID")) %>' /> <br />
                &nbsp;<asp:Label ID="FileNameLabel" runat="server" Text='<%# Eval("FileName") %>'></asp:Label><br />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HealthCareConnectionString %>"
            SelectCommand="SELECT [FileName], [FileData], [PatientID], [Fileid] FROM [images] WHERE ([PatientID] = @PatientID)">
            <SelectParameters>
                <asp:SessionParameter Name="PatientID" SessionField="PatientID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
</asp:Content>

