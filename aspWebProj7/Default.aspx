<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="aspWebProj7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div>
<asp:Label ID="Label1" Text="First Name" runat="server" AssociatedControlID="txtFName" />
<asp:TextBox runat="server" ID="txtFName" />
<br />
<asp:Label ID="Label2" Text="Last Name" runat="server" AssociatedControlID="txtLName" />
<asp:TextBox runat="server" ID="txtLName" />
<br />
<asp:Label ID="Label3" Text="Email" runat="server" AssociatedControlID="txtEmail" />
<asp:TextBox runat="server" ID="txtEmail" />
<br />
<asp:Label ID="Label4" Text="Address Line 1" runat="server" AssociatedControlID="txtLine1" />
<asp:TextBox runat="server" ID="txtLine1" />
<br />
<asp:Label ID="Label5" Text="Address Line 1" runat="server" AssociatedControlID="txtLine2" />
<asp:TextBox runat="server" ID="txtLine2" />
<br />
<asp:Label ID="Label6" Text="ZIP" runat="server" AssociatedControlID="txtZIP" />
<asp:TextBox runat="server" ID="txtZIP" />
<br />
<asp:Label ID="Label7" Text="City" runat="server" AssociatedControlID="txtCity" />
<asp:TextBox runat="server" ID="txtCity" />
<br />
<p>
<asp:Button ID="btnSubmit" runat="server" Text="Submit"
OnClick="btnSubmit_Click" />
</p>
</div>
<asp:GridView runat="server" ID="PeopleGridView" AutoGenerateSelectButton="True" DataKeyNames="Id" OnSelectedIndexChanged="PeopleGridView_SelectedIndexChanged" OnRowDeleting="PeopleGridView_RowDeleting"></asp:GridView>
</asp:Content>
