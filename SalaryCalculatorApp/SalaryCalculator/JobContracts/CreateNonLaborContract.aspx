<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateNonLaborContract.aspx.cs" Inherits="SalaryCalculator.JobContracts.CreateNonLaborContract" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>NonLabor contract</h1>
    </div>
    <div class="jumbotron">
        <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="FirstName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="MiddleNameLabel" runat="server" Text="Middle Name"></asp:Label>
        <asp:TextBox ID="MiddleName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="LastName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="BirthDateLabel" runat="server" Text="Birth Date"></asp:Label>
        <asp:TextBox ID="BirthDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="ContractValueLabel" runat="server" Text="Gross Contract Value"></asp:Label>
        <asp:TextBox ID="ContractValue" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="CalculateWage" runat="server" Text="Calculate" CssClass="btn btn-info" />
    </div>
</asp:Content>
