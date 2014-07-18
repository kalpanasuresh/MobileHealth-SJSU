<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="Consult.aspx.cs" Inherits="Patient_Consult" Title="Untitled Page" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/General/Health.master" %> 
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<asp:Wizard ID="myWizard" runat="server" ActiveStepIndex="0" BackColor="#F7F6F3"
            BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
            Font-Size="0.8em" Height="195px" OnNextButtonClick="myWizard_NextButtonClick"
            Width="278px">
            <StepStyle BorderWidth="0px" ForeColor="#5D7B9D" VerticalAlign="Top" />
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Category">
                    <strong>Please choose a cateogry:&nbsp;<br />
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem>Skin</asp:ListItem>
                            <asp:ListItem>Lung</asp:ListItem>
                            <asp:ListItem>Eye-Sight</asp:ListItem>
                            <asp:ListItem>Digestion</asp:ListItem>
                            <asp:ListItem>Cold-Flu</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadioButtonList1"
                            ErrorMessage="Choose a category"></asp:RequiredFieldValidator>
                    </strong>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Symptoms">
                    Please select your symptoms:<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <contenttemplate>
<asp:Label id="Question" runat="server"></asp:Label> <asp:RadioButtonList id="RadioButtonList2" runat="server" Width="145px" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:RadioButtonList> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="RadioButtonList2"></asp:RequiredFieldValidator> 
                            <br />
                            <br />
                            <br />
                            You may have one of the below disease:<br />
                            &nbsp;<asp:GridView ID="GridView1" runat="server">
                            </asp:GridView>
</contenttemplate>
                    </asp:UpdatePanel>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep3" runat="server" StepType="Complete" Title="Result">
                    <asp:Label ID="Label3" runat="server" Text="You are diagnoised with"></asp:Label>
                    <br />
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="You can take the following medication(s)"></asp:Label>
                    &nbsp;<br />
                    <asp:ListBox ID="ListBox1" runat="server" Width="174px"></asp:ListBox>
                    <br />
                    <br />
                    &nbsp;<br />
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/General/SendSMS.aspx">Click here to send an SMS to doctor or set an appointment</asp:LinkButton>
                </asp:WizardStep>
            </WizardSteps>
            <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
            <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <SideBarStyle BackColor="#7C6F57" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
            <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em"
                ForeColor="White" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:Wizard>
        
</asp:Content>

