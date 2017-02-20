<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="SalaryCalculator.Account.Profile" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" CssClass="jumbotron">
    <h1>User profile</h1>
    <div class="row">
        <div class="col-md-3 table-background">
            <asp:Image ID="ImageID" runat="server" Width="200" Height="200" />
            <asp:FileUpload ID="FileUpload" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator"
                runat="server"
                Text="* Image path required."
                ControlToValidate="FileUpload"
                SetFocusOnError="true"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
            <asp:Button ID="ButtonLoad" runat="server" OnClick="ButtonLoad_Click" Text="Upload photo" CssClass="btn btn-warning" />
        </div>
        <div class="col-md-9 table-background">
            <h2>Company information</h2>
            <asp:Repeater ID="DetailInfo" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <p>
                        <span class="glyphicon glyphicon-user"> Username: </span> <%# DataBinder.Eval(Container.DataItem, "UserName") %>
                    </p>
                    <p>
                      <span class="glyphicon glyphicon-hand-right"> E-mail: </span> <%# DataBinder.Eval(Container.DataItem, "EMail") %>
                    </p>
                    <p>
                       <span class="glyphicon glyphicon-tower"> Company name: </span> <%# DataBinder.Eval(Container.DataItem, "CompanyName") %>
                    </p>
                    <p>
                       <span class="glyphicon glyphicon-lock"> Company address: </span> <%# DataBinder.Eval(Container.DataItem, "CompanyAddress") %>
                    </p>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
