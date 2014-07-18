<%@ Page Language="C#" MasterPageFile="~/General/Health.master" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="Patient_NewUser" Title="Untitled Page" %>

<%@ Register Src="NewUserPAt.ascx" TagName="NewUserPAt" TagPrefix="uc1" %>


<%@ MasterType VirtualPath="~/General/Health.master" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <uc1:NewUserPAt ID="NewUserPAt1" runat="server" />
</asp:Content>

