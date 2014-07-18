<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="ApptDoc.aspx.cs" Inherits="Appointment_ApptDoc" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
			<div id="mainbody">
                <asp:Label ID="Label1" runat="server" Text="Enter Date" Width="71px" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtDate" runat="server" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDate"
                    ErrorMessage="Not a valid date" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>&nbsp;
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Go" /><br>
				<table class="setup" style="width: 31%; height: 250px">
					<tr style="COLOR: white; BACKGROUND-COLOR:Black" vAlign="top">
						<td style="width: 35%">8:00 am
							<asp:dropdownlist id="cmb8" style="LEFT: 13px; POSITION: relative; top: 2px;" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							8:30 am
							<asp:dropdownlist id="cmb830" style="LEFT: 13px; POSITION: relative; top: 1px;" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							9:00 am
							<asp:dropdownlist id="cmb9" style="LEFT: 13px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							9:30 am
							<asp:dropdownlist id="cmb930" style="LEFT: 13px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							10:00 am
							<asp:dropdownlist id="cmb10" style="LEFT: 7px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="No">Yes</asp:ListItem>
								<asp:ListItem Value="Unavailable">Unavailable</asp:ListItem>
							</asp:dropdownlist><br>
							10:30 am
							<asp:dropdownlist id="cmb1030" style="LEFT: 7px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							11:00 am
							<asp:dropdownlist id="cmb11" style="LEFT: 7px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							11:30 am
							<asp:dropdownlist id="cmb1130" style="LEFT: 7px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist></td>
						<td style="width: 38%">12:00 pm
							<asp:dropdownlist id="cmb12" style="LEFT: 29px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							12:30 pm
							<asp:dropdownlist id="cmb1230" style="LEFT: 29px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							1:00 pm
							<asp:dropdownlist id="cmb13" style="LEFT: 35px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							1:30 pm
							<asp:dropdownlist id="cmb1330" style="LEFT: 35px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							2:00 pm
							<asp:dropdownlist id="cmb14" style="LEFT: 35px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							2:30 pm
							<asp:dropdownlist id="cmb1430" style="LEFT: 35px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							3:00 pm
							<asp:dropdownlist id="cmb15" style="LEFT: 35px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							3:30 pm
							<asp:dropdownlist id="cmb1530" style="LEFT: 35px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							4:00 pm
							<asp:dropdownlist id="cmb16" style="LEFT: 35px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							4:30 pm
							<asp:dropdownlist id="cmb1630" style="LEFT: 35px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist><br>
							5:00 pm
							<asp:dropdownlist id="cmb17" style="LEFT: 35px; POSITION: relative" runat="server" Width="53px" Height="22px">
								<asp:ListItem Value="Yes">Yes</asp:ListItem>
								<asp:ListItem Value="No">No</asp:ListItem>
							</asp:dropdownlist></td>
					</tr>
				</table>
				<asp:label id="lblMessage" style="TEXT-ALIGN: center" runat="server" Width="287px" Font-Bold="True">Please review your changes before submitting</asp:label><br>
                <asp:Button ID="Button1" runat="server" OnClick="btnSubmit_Click" Text="Submit" /><br>
				<center>
					<asp:Button id="btnFlip" runat="server" Text="Flip All" Enabled="False" OnClick="btnFlip_Click" Visible="False"></asp:Button>&nbsp;&nbsp;</center>
			</div>
</asp:Content>
