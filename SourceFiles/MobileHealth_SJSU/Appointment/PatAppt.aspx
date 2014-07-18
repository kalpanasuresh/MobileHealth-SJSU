<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="PatAppt.aspx.cs" Inherits="Appointment_PatAppt" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

			<div id="mainbody">
				<center style="text-align: left">
                    &nbsp;</center>
                <center style="text-align: left">
                    <table style="text-align: left">
                        <caption>
                            <span style="font-size: 11pt; color: #ffffff; font-family: Arial"><strong>Patient's
                                Appointment Page</strong></span></caption>
                        <tr>
                            <td style="width: 91px; height: 28px;">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Enter doctor's last name"></asp:Label></td>
                            <td style="width: 100px; height: 28px;">
				<asp:textbox id="txtSearchValue" style="POSITION: static;" runat="server" MaxLength="20"></asp:textbox></td>
                            <td style="width: 100px; height: 28px;">
                                <asp:button id="btnSearch" style="POSITION: static;" runat="server"
					Text="Search" OnClick="btnSearch_Click"></asp:button></td>
                        </tr>
                        <tr>
                            <td style="width: 91px; height: 11px">
                            </td>
                            <td style="width: 100px; height: 11px">
                                <asp:listbox id="lstInstructors" style="POSITION: static" runat="server" Visible="False"
					Width="186px"></asp:listbox><br />
                    <asp:label id="lblMessage" runat="server" Width="183px" Font-Bold="True" Height="11px"></asp:label></td>
                            <td style="width: 100px; height: 11px">
                                &nbsp;<asp:button id="btnGo" style="POSITION: static;" runat="server" Visible="False"
					Width="38px" Text="Go" Height="23px" OnClick="btnGo_Click"></asp:button></td>
                        </tr>
                        <tr>
                            <td style="width: 91px; height: 25px;" valign="top">
                <asp:Label ID="Label1" runat="server" Text="Enter Date" Font-Bold="True"></asp:Label></td>
                            <td style="width: 100px; height: 25px;">
                                <asp:TextBox
                    ID="txtDate" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDate"
                                    ErrorMessage="Not a valid date" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator></td>
                            <td style="width: 100px; height: 25px;" valign="top">
                <asp:Button ID="Button1" runat="server" Height="23px" OnClick="Button1_Click" Style="position: static;" Text="Go" Width="38px" /></td>
                        </tr>
                    </table>
                    <br>
				<table class="setup" width="100%">
					<tr style="COLOR: white; BACKGROUND-COLOR:Black" vAlign="top">
						<td style="width: 18%">8:00 am
							<asp:radiobutton id="radMakeApp1" style="LEFT: 21px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							8:30 am
							<asp:radiobutton id="radMakeApp2" style="LEFT: 21px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							9:00 am
							<asp:radiobutton id="radMakeApp3" style="LEFT: 21px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							9:30 am
							<asp:radiobutton id="radMakeApp4" style="LEFT: 21px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							10:00 am
							<asp:radiobutton id="radMakeApp5" style="LEFT: 15px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							10:30 am
							<asp:radiobutton id="radMakeApp6" style="LEFT: 15px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							11:00 am
							<asp:radiobutton id="radMakeApp7" style="LEFT: 15px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							11:30 am
							<asp:radiobutton id="radMakeApp8" style="LEFT: 15px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment"></asp:radiobutton></td>
						<td width="50%">12:00 pm
							<asp:radiobutton id="radMakeApp9" style="LEFT: 17px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							12:30 pm
							<asp:radiobutton id="radMakeApp10" style="LEFT: 17px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							1:00 pm
							<asp:radiobutton id="radMakeApp11" style="LEFT: 23px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							1:30 pm
							<asp:radiobutton id="radMakeApp12" style="LEFT: 23px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							2:00 pm
							<asp:radiobutton id="radMakeApp13" style="LEFT: 23px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							2:30 pm
							<asp:radiobutton id="radMakeApp14" style="LEFT: 23px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							3:00 pm
							<asp:radiobutton id="radMakeApp15" style="LEFT: 23px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							3:30 pm
							<asp:radiobutton id="radMakeApp16" style="LEFT: 23px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							4:00 pm
							<asp:radiobutton id="radMakeApp17" style="LEFT: 23px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							4:30 pm
							<asp:radiobutton id="radMakeApp18" style="LEFT: 23px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment" Height="20px" Width="109px"></asp:radiobutton><br>
							5:00 pm
							<asp:radiobutton id="radMakeApp19" style="LEFT: 23px; POSITION: relative" runat="server" Visible="False"
								Checked="True" GroupName="SchedApp" Text="Make Appointment"></asp:radiobutton></td>
					</tr>
				</table>
				<br>
				</center>
				<center><asp:button id="btnSubmit" runat="server" Visible="False" Text="Submit" OnClick="btnSubmit_Click"></asp:button>&nbsp;</center>
			</div>
</asp:Content>