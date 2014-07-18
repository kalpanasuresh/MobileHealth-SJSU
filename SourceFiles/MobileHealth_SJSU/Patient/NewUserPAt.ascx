<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewUserPAt.ascx.cs" Inherits="Patient_NewUserPAt" %>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <table border="0">
            <tr>
                <td align="center" colspan="2">
                    <asp:label id="Label15" runat="server" font-size="Small">Sign Up for Your New Account</asp:label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Size="Smaller">User Name:</asp:Label></td>
                <td>
                    <asp:TextBox ID="UserName" runat="server" AutoPostBack="True" OnTextChanged="UserName_TextChanged"
                        Width="105px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        ErrorMessage="User Name is required." ToolTip="User Name is required.">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="UserName"
                        ErrorMessage="*" SetFocusOnError="True"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPass" Font-Size="Smaller">Password:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" OnTextChanged="Password_TextChanged" TextMode="Password"
                        Width="105px" Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPass"
                        ErrorMessage="Password is required." ToolTip="Password is required.">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword"
                        Font-Size="Smaller">Confirm Password:</asp:Label></td>
                <td>
                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="105px" Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                        ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required.">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email" Font-Size="Smaller">E-mail:</asp:Label></td>
                <td>
                    <asp:TextBox ID="Email" runat="server" Width="105px" Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                        ErrorMessage="E-mail is required." ToolTip="E-mail is required.">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Not a valid email"
                        Font-Size="Smaller" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question" Font-Size="Smaller">Security Question:</asp:Label></td>
                <td>
                    <asp:TextBox ID="Question" runat="server" Width="105px" Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                        ErrorMessage="Security question is required." ToolTip="Security question is required.">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" Font-Size="Smaller">Security Answer:</asp:Label></td>
                <td>
                    <asp:TextBox ID="Answer" runat="server" Width="105px" Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                        ErrorMessage="Security answer is required." ToolTip="Security answer is required.">*</asp:RequiredFieldValidator>
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
                    <asp:Button  id="Button1" runat="server" onclick="Button1_Click" Text="Next"  />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table border="0">
            <tr>
                <td align="center" colspan="2">
                    <asp:label id="Label14" runat="server" font-size="Small">Sign Up for Your New Account</asp:label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label16" runat="server" Font-Size="Smaller">First Name</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtFName" runat="server" Font-Size="Smaller" ></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtFName" ErrorMessage="*"
                        ToolTip="*">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label17" runat="server" Font-Size="Smaller">Last Name</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtLName" runat="server" Font-Size="Smaller" ></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtLName" ErrorMessage="*">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label1" runat="server" Font-Size="Smaller">Gender</asp:Label></td>
                <td>
                    &nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Size="Smaller"
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Selected="True">Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label2" runat="server" Font-Size="Smaller">Date of Birth</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtDoB" runat="server" Width="108px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDoB"
                        ErrorMessage="*" ToolTip="*">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDoB"
                        Display="Dynamic" ErrorMessage="Not a valid Date" Font-Size="Smaller" Operator="DataTypeCheck"
                        Type="Date"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label3" runat="server" Font-Size="Smaller">Phone</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" Width="110px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhone"
                        ErrorMessage="*">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPhone"
                        ErrorMessage="Not a valid phone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}))?\d{3}\d{4}"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label12" runat="server" Font-Size="Smaller">Provider</asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlProvider" runat="server">
                        <asp:ListItem Value="txt.att.net">AT&amp;T</asp:ListItem>
                        <asp:ListItem Value="messaging.sprintpcs.com ">Sprint</asp:ListItem>
                        <asp:ListItem Value="vtext.com">Verizon</asp:ListItem>
                        <asp:ListItem Value="tmomail.net">T-Mobile</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label5" runat="server" Font-Size="Smaller">Address</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtAddr" runat="server" Width="110px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddr"
                        ErrorMessage="*">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label6" runat="server" Font-Size="Smaller">City</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" Width="112px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity"
                        ErrorMessage="*">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label7" runat="server" Font-Size="Smaller">State</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" Width="113px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtState"
                        ErrorMessage="*">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label8" runat="server" Font-Size="Smaller">Zip</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server" Width="112px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip"
                        ErrorMessage="*">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Not a valid zip"
                        Font-Size="Smaller" ValidationExpression="\d{5}(-\d{4})?" ControlToValidate="txtZip"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="color: red">
                    <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
                    <asp:Button id="Button2" runat="server" onclick="Button2_Click" Text="Next" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View3" runat="server">
        <table border="0">
            <tr>
                <td align="center" colspan="2">
                    <asp:label id="Label13" runat="server" font-size="Small">Sign Up for Your New Account</asp:label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label9" runat="server" Font-Size="Smaller">Health Insurance</asp:Label></td>
                <td style="width: 101px">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" Font-Size="Smaller" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True">Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label10" runat="server" Font-Size="Smaller">Location of Policy</asp:Label></td>
                <td style="width: 101px">
                    <asp:DropDownList ID="ddlLocPolicy" runat="server" Font-Size="Smaller" Width="61px">
                        <asp:ListItem>CA</asp:ListItem>
                    </asp:DropDownList>&nbsp; (Optional)</td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label11" runat="server" Font-Size="Smaller" Width="100px">Health Plan Name</asp:Label></td>
                <td style="width: 101px">
                    <asp:DropDownList ID="ddlHealthPlan" runat="server" Font-Size="Smaller">
                        <asp:ListItem>Aetna</asp:ListItem>
                        <asp:ListItem>Kaizer</asp:ListItem>
                        <asp:ListItem>Blue Cross</asp:ListItem>
                        <asp:ListItem>Blue Shield</asp:ListItem>
                        <asp:ListItem>Sutter Health</asp:ListItem>
                        <asp:ListItem>United HealthCare</asp:ListItem>
                    </asp:DropDownList>(Optional)&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="color: red">
                    <asp:Literal ID="Literal2" runat="server" EnableViewState="False"></asp:Literal>
                    <asp:Button id="Button3" runat="server" onclick="Command1_Click" Text="Create" />
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
