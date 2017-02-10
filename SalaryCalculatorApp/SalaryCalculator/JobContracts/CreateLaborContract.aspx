<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateLaborContract.aspx.cs" Inherits="SalaryCalculator.JobContracts.CreateLaborContract" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Labor contract</h1>
    </div>
    <div class="jumbotron">
        <asp:Label ID="FirstNameLabel" runat="server" Text="First Name" Visible="true"></asp:Label>
        <asp:TextBox ID="FirstName" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="MiddleNameLabel" runat="server" Text="Middle Name" Visible="true"></asp:Label>
        <asp:TextBox ID="MiddleName" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="LastNameLabel" runat="server" Text="Last Name" Visible="true"></asp:Label>
        <asp:TextBox ID="LastName" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="PersonalIdLabel" runat="server" Text="Personal ID" Visible="true"></asp:Label>
        <asp:TextBox ID="PersonalId" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="BirthDateLabel" runat="server" Text="Birth Date" Visible="true"></asp:Label>
        <asp:TextBox ID="BirthDate" runat="server" TextMode="Date" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="GrossBaseSalaryLabel" runat="server" Text="Gross Contract Value" Visible="true"></asp:Label>
        <asp:TextBox ID="GrossBaseSalary" runat="server" TextMode="Number" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="FixedBonusLabel" runat="server" Text="Fixed Monthly bonus" Visible="true"></asp:Label>
        <asp:TextBox ID="FixedBonus" runat="server" TextMode="Number" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="NonFixedBonusLabel" runat="server" Text="Non-Fixed Monthly bonus" Visible="true"></asp:Label>
        <asp:TextBox ID="NonFixedBonus" runat="server" TextMode="Number" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Button ID="CalculateWage" runat="server" Text="Calculate" CssClass="btn btn-danger" Visible="true" OnClick="CalculateWage_Click" />
        <asp:GridView ID="DetailsViewPaycheck"
            runat="server"
            AutoGenerateColumns="true"
            CssClass="jumbotron">
            <Columns>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
