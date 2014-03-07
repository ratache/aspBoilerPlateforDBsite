<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PeopleDynamic.aspx.cs" Inherits="aspWebProj7.PeopleDynamic" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:GridView runat="server" ID="peopleGridView" AutoGenerateColumns="false"
            DataKeyNames="Id" ItemType="aspWebProj7.Models.Person"
            OnRowDeleting="PeopleGridView_RowDeleting" OnSelectedIndexChanged="PeopleGridView_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
                <asp:TemplateField HeaderText="Name" SortExpression="LastName">
                    <ItemTemplate>
                        <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="LastName" Mode="ReadOnly" />,
                        <asp:DynamicControl ID="DynamicControl2" runat="server" DataField="FirstName" Mode="ReadOnly" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Email" SortExpression="Email" DataField="Email" />
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <%# Item.Address.ToString() %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:FormView ID="PeopleFormView" runat="server" ItemType="aspWebProj7.Models.Person"
        DefaultMode="Insert" DataKeyNames="Id" RenderOuterTable="false"
        InsertMethod="InsertPerson" UpdateMethod="UpdatePerson"
        SelectMethod="SelectPerson">
        <InsertItemTemplate>
            <label>
                <span class="lefty">First Name:</span>
                <asp:DynamicControl ID="DynamicControl3" runat="server" DataField="FirstName" Mode="Edit" />
            </label>
            <br />
            <label>
                <span class="lefty">Last Name:</span>
                <asp:DynamicControl ID="DynamicControl4" runat="server" DataField="LastName" Mode="Edit" />
            </label>
            <br />
            <label>
                <span class="lefty">Email:</span>
                <asp:DynamicControl ID="DynamicControl5" runat="server" DataField="Email" Mode="Edit" />
            </label>
            <br />
            <p>
                <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Insert" />
            </p>
        </InsertItemTemplate>
        <EditItemTemplate>
            <label>
                <span class="lefty">First Name</span>
                <asp:DynamicControl ID="DynamicControl6" runat="server" DataField="FirstName" Mode="Edit" />
            </label>
            <label>
                <span class="lefty">Last Name</span>
                <asp:DynamicControl ID="DynamicControl7" runat="server" DataField="LastName" Mode="Edit" />
            </label>
            <label>
                <span class="lefty">Email</span>
                <asp:DynamicControl ID="DynamicControl8" runat="server" DataField="Email" Mode="Edit" />
            </label>
            <p>
                <asp:Button ID="Button2" runat="server" CommandName="Cancel" CausesValidation="false" />
                <asp:Button ID="Button3" runat="server" CommandName="Update" Text="Update" />
            </p>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>