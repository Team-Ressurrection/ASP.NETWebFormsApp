<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="SalaryCalculator.Account.Profile" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" CssClass="jumbotron">
    <h1>User profile</h1>
    <asp:Image ID="ImageID" runat="server" Width="200" Height="200"/>
    <asp:FileUpload ID="FileUpload" runat="server"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator"
        runat="server"
        Text="* Image path required."
        ControlToValidate="FileUpload"
        SetFocusOnError="true"
        Display="Dynamic">
    </asp:RequiredFieldValidator>
    <asp:Button ID="ButtonLoad" runat="server" OnClick="ButtonLoad_Click" Text="Upload photo" CssClass="btn btn-warning" />
    <asp:FormView runat="server" ID="DetailsView" AutoGenerateRows="false">
        <ItemTemplate>
            <div>
                <%# Context.User.Identity.GetUserName() %>
                <br />
                <%# Context.User.Identity.Name %>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
