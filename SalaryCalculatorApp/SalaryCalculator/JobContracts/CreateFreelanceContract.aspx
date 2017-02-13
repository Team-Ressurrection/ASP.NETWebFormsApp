<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateFreelanceContract.aspx.cs" Inherits="SalaryCalculator.JobContracts.CreateFreelanceContract" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Freelance contract</h1>
    </div>
    <div class="jumbotron">
        <asp:Label ID="FirstNameLabel" runat="server" Text="First Name" Visible="true"></asp:Label>
        <asp:TextBox ID="FirstName" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="MiddleNameLabel" runat="server" Text="Middle Name" Visible="true"></asp:Label>
        <asp:TextBox ID="MiddleName" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="LastNameLabel" runat="server" Text="Last Name" Visible="true"></asp:Label>
        <asp:TextBox ID="LastName" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="BirthDateLabel" runat="server" Text="Birth Date" Visible="true"></asp:Label>
        <asp:TextBox ID="BirthDate" runat="server" TextMode="Date" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="SocialSecurityIncomeLabel" runat="server" Text="Gross Contract Value" Visible="true"></asp:Label>
        <asp:TextBox ID="SocialSecurityIncome" runat="server" TextMode="Number" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Button ID="CalculateSocialSecurityContributions" runat="server" Text="Calculate" CssClass="btn btn-info" Visible="true" OnClick="CalculateSocialSecurityContributions_Click" />
    </div>
    <asp:GridView ID="DetailsViewSelfEmploymentContributions"
            runat="server"
            AutoGenerateColumns="true"
            CssClass="jumbotron">
            <Columns>
            </Columns>
        </asp:GridView>
</asp:Content>
