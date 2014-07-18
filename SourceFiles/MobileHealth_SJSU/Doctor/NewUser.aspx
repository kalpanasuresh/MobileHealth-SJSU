<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="Doctor_NewUser" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/General/Health.master" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
 <asp:MultiView ID="MultiView1" runat="server">
           <asp:View ID="View1" runat="server">
               <table border="0">
                   <caption>
                       <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt"
                           ForeColor="#FFFFFF">Doctor Sign up Page - Step1</asp:Label></caption>
                   <tbody>
                       <tr>
                           <td align="right" style="width: 90px">
                               <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Size="Smaller">User Name:</asp:Label></td>
                           <td align="left" valign="top">
                               <asp:TextBox ID="UserName" runat="server" Font-Size="Smaller" OnTextChanged="UserName_TextChanged"
                                   Width="106px" AutoPostBack="True" MaxLength="8" Height="18px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                   ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Step1">*</asp:RequiredFieldValidator>
                               <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="UserName"
                                   ErrorMessage="*" SetFocusOnError="True"></asp:CustomValidator></td>
                       </tr>
                       <tr>
                           <td align="right" style="width: 90px">
                               <asp:Label ID="PasswordLabel" runat="server" Font-Size="Smaller">Password:</asp:Label></td>
                           <td align="left" valign="top">
                               <asp:TextBox ID="txtPass" runat="server" OnTextChanged="txtPass_TextChanged"
                                   TextMode="Password" Font-Names="Arial" Font-Size="9pt" Height="18px" Width="106px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPass"
                                   ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Step1">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td align="right" style="height: 22px; width: 90px;">
                               <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword"
                                   Font-Size="Smaller">Confirm Password:</asp:Label></td>
                           <td style="height: 22px" align="left" valign="top">
                               <asp:TextBox ID="ConfirmPassword" runat="server" Font-Size="9pt" TextMode="Password"
                                   Width="106px" Height="18px" OnTextChanged="ConfirmPassword_TextChanged" Font-Names="Arial"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                   ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required." ValidationGroup="Step1">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td align="right" style="width: 90px">
                               <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label></td>
                           <td align="left" valign="top">
                               <asp:TextBox ID="Email" runat="server" Font-Size="Smaller" Width="106px" Height="18px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                   ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="Step1">*</asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email"
                                   ErrorMessage="Not a valid email" Font-Size="Smaller" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                   ValidationGroup="Step1"></asp:RegularExpressionValidator></td>
                       </tr>
                       <tr>
                           <td align="right" style="width: 90px">
                               <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question" Font-Size="Smaller">Security Question:</asp:Label></td>
                           <td align="left" valign="top">
                               <asp:TextBox ID="Question" runat="server" Font-Size="Smaller" Width="106px" Height="18px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                   ErrorMessage="Security question is required." ToolTip="Security question is required." ValidationGroup="Step1">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td align="right" style="width: 90px">
                               <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" Font-Size="Smaller">Security Answer:</asp:Label></td>
                           <td align="left" valign="top">
                               <asp:TextBox ID="Answer" runat="server" Font-Size="Smaller" Width="106px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                   ErrorMessage="Security answer is required." ToolTip="Security answer is required." ValidationGroup="Step1">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td align="center" colspan="2">
                               <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPass"
                                   ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                   Font-Size="Smaller" ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                           </td>
                       </tr>
                       <tr>
                           <td align="center" colspan="2" style="color: red">
                               <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                               <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Next" ValidationGroup="Step1" /></td>
                       </tr>
                   </tbody>
               </table>
           </asp:View>
           <asp:View ID="View2" runat="server">
               <table border="0">
                   <caption>
                       <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt"
                           ForeColor="#FFFFFF">Doctor Sign up Page - Step2</asp:Label></caption>
                   <tbody>
                       <tr>
                           <td align="right" style="height: 22px">
                               <asp:Label ID="Label4" runat="server" Font-Size="Smaller">First Name</asp:Label></td>
                           <td style="height: 22px">
                               <asp:TextBox ID="txtFName" runat="server" Font-Size="Smaller" OnTextChanged="txtDoB_TextChanged"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFName"
                                   ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator></td>
                       </tr>
                       <tr>
                           <td align="right">
                               <asp:Label ID="Label13" runat="server" Font-Size="Smaller">Last Name</asp:Label></td>
                           <td>
                               <asp:TextBox ID="txtLName" runat="server" Font-Size="Smaller" OnTextChanged="txtDoB_TextChanged"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtLName"
                                   ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator></td>
                       </tr>
                       <tr>
                           <td align="right">
                               <asp:Label ID="Label1" runat="server" Font-Size="Smaller">Gender</asp:Label></td>
                           <td>
                               &nbsp;<asp:RadioButtonList ID="rdGender" runat="server" Font-Size="Smaller" RepeatDirection="Horizontal"
                                   RepeatLayout="Flow">
                                   <asp:ListItem Selected="True">Male</asp:ListItem>
                                   <asp:ListItem>Female</asp:ListItem>
                               </asp:RadioButtonList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                                   ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td align="right">
                               <asp:Label ID="Label2" runat="server" Font-Size="Smaller">Date of Birth</asp:Label></td>
                           <td>
                               <asp:TextBox ID="txtDoB" runat="server" Font-Size="Smaller" OnTextChanged="txtDoB_TextChanged"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDoB"
                                   ErrorMessage="Date of birth required" ToolTip="Date of birth required">*</asp:RequiredFieldValidator>
                               <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDoB"
                                   Display="Dynamic" ErrorMessage="Not a valid Date" Font-Size="Smaller" Operator="DataTypeCheck"
                                   Type="Date"></asp:CompareValidator></td>
                       </tr>
                       <tr>
                           <td align="right">
                               <asp:Label ID="Label3" runat="server" Font-Size="Smaller">Phone</asp:Label></td>
                           <td>
                               <asp:TextBox ID="txtPhone" runat="server" Font-Size="Smaller"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmPassword"
                                   ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                   ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPhone"
                                   ErrorMessage="Not a valid phone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}))?\d{3}\d{4}"></asp:RegularExpressionValidator></td>
                       </tr>
                       <tr>
                           <td align="right">
                               <asp:Label ID="Label12" runat="server" Font-Size="Smaller">Provider</asp:Label></td>
                           <td>
                               <asp:DropDownList ID="ddlProvider" runat="server" Font-Size="Smaller">
                                   <asp:ListItem Value="txt.att.net">AT&amp;T</asp:ListItem>
                                   <asp:ListItem Value="messaging.sprintpcs.com ">Sprint</asp:ListItem>
                                   <asp:ListItem Value="vtext.com">Verizon</asp:ListItem>
                                   <asp:ListItem Value="tmomail.net">T-Mobile</asp:ListItem>
                               </asp:DropDownList></td>
                       </tr>
                       <tr>
                           <td align="right">
                               <asp:Label ID="Label5" runat="server" Font-Size="Smaller">Address</asp:Label></td>
                           <td>
                               <asp:TextBox ID="txtAddr" runat="server" Font-Size="Smaller"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddr"
                                   ErrorMessage="*">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td align="right">
                               <asp:Label ID="Label6" runat="server" Font-Size="Smaller">City</asp:Label></td>
                           <td>
                               <asp:TextBox ID="txtCity" runat="server" Font-Size="Smaller"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity"
                                   ErrorMessage="*">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td align="right">
                               <asp:Label ID="Label7" runat="server" Font-Size="Smaller">State</asp:Label></td>
                           <td>
                               <asp:TextBox ID="txtState" runat="server" Font-Size="Smaller"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtState"
                                   ErrorMessage="*">*</asp:RequiredFieldValidator></td>
                       </tr>
                       <tr>
                           <td align="right">
                               <asp:Label ID="Label8" runat="server" Font-Size="Smaller">Zip</asp:Label></td>
                           <td>
                               <asp:TextBox ID="txtZip" runat="server" Font-Size="Smaller"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip"
                                   ErrorMessage="*">*</asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtZip"
                                   ErrorMessage="Not a valid zip" Font-Size="Smaller" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator></td>
                       </tr>
                       <tr>
                           <td align="center" colspan="2">
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td align="center" colspan="2" style="color: red">
                               <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
                               <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Next" ValidationGroup="CreateUserWizard1" /></td>
                       </tr>
                   </tbody>
               </table>
               </asp:View>
           <asp:View ID="View3" runat="server">
               <table border="0">
                   <tbody>
                       <tr>
                           <td align="center" colspan="2">
                               <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt"
                                   ForeColor="White">Doctor Sign up Page - Step3</asp:Label></td>
                       </tr>
                       <tr>
                           <td align="right" style="height: 22px">
                               <asp:Label ID="Label9" runat="server" Font-Size="Smaller">National Provider ID</asp:Label></td>
                           <td style="height: 22px">
                               <asp:TextBox ID="txtProvID" runat="server" Font-Size="Smaller" Height="18px" Width="166px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlProvider"
                                   ErrorMessage="*">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td align="right" style="height: 20px">
                               <asp:Label ID="Label10" runat="server" Font-Size="Smaller">Professional License Type</asp:Label></td>
                           <td style="height: 20px">
                               <asp:DropDownList ID="ddlLic" runat="server" Font-Size="Smaller" Height="18px" Width="166px">
                                   <asp:ListItem>Medical Doctor</asp:ListItem>
                                   <asp:ListItem>Doctor of Osteopathy</asp:ListItem>
                                   <asp:ListItem>Nursue Practitioner</asp:ListItem>
                                   <asp:ListItem>Physical Assistant</asp:ListItem>
                                   <asp:ListItem>Psychologists</asp:ListItem>
                                   <asp:ListItem>Marriage Family Therapist</asp:ListItem>
                                   <asp:ListItem>Physical Therapist</asp:ListItem>
                                   <asp:ListItem>Registered Dietician</asp:ListItem>
                                   <asp:ListItem>Case Manager</asp:ListItem>
                               </asp:DropDownList>&nbsp;
                           </td>
                       </tr>
                       <tr>
                           <td align="right">
                               <asp:Label ID="Label11" runat="server" Font-Size="Smaller">Primary Speciality</asp:Label></td>
                           <td>
                               <asp:DropDownList ID="ddlPrmSpl" runat="server" Font-Size="Smaller" Width="166px">
                                   <asp:ListItem>Internal Medicine</asp:ListItem>
                                   <asp:ListItem>Dermatology</asp:ListItem>
                                   <asp:ListItem>Cardiology</asp:ListItem>
                                   <asp:ListItem>Chiropractic</asp:ListItem>
                                   <asp:ListItem>Dental Medicine</asp:ListItem>
                                   <asp:ListItem>Gynecology</asp:ListItem>
                                   <asp:ListItem>Obsterics</asp:ListItem>
                                   <asp:ListItem>Pharmacology</asp:ListItem>
                                   <asp:ListItem>Opthalmology</asp:ListItem>
                                   <asp:ListItem>Preventive Medicine</asp:ListItem>
                                   <asp:ListItem>Pulmonology</asp:ListItem>
                               </asp:DropDownList>&nbsp;
                           </td>
                       </tr>
                       <tr>
                           <td align="center" colspan="2" style="color: red">
                               <asp:Literal ID="Literal2" runat="server" EnableViewState="False"></asp:Literal>
                               <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Create" /></td>
                       </tr>
                   </tbody>
               </table>
           </asp:View>
       </asp:MultiView>
</asp:Content>

