<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateFreelanceContract.aspx.cs" Inherits="SalaryCalculator.JobContracts.CreateFreelanceContract" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Freelance contract</h1>
    </div>
    <div class="jumbotron">
        <asp:Label ID="FirstNameLabel" runat="server" Text="First Name" Visible="true"></asp:Label>
        <asp:TextBox ID="FirstName" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorFN" 
            runat="server" 
            Text="First name is required." 
            ControlToValidate="FirstName" 
            SetFocusOnError="true" Display="Dynamic" CssClass="text-danger">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidatorUsername" 
            runat="server" 
            ValidationGroup="EmployeeInfo"
            ErrorMessage="Employee first name must be between 2 and 20 characters long and contain only letters."
            ControlToValidate="FirstName" ValidationExpression="^[A-Za-z]{2,20}$" CssClass="text-danger" Display="Dynamic" />
        <asp:Label ID="MiddleNameLabel" runat="server" Text="Middle Name" Visible="true"></asp:Label>
        <asp:TextBox ID="MiddleName" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorMN" 
            runat="server" 
            Text="Middle name is required." 
            ControlToValidate="MiddleName" 
            SetFocusOnError="true" Display="Dynamic" CssClass="text-danger">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidatorMN"
            runat="server" 
            ValidationGroup="EmployeeInfo"
            ErrorMessage="Employee middle name must be between 2 and 20 characters long and contain only letters."
            ControlToValidate="MiddleName" ValidationExpression="^[A-Za-z]{2,20}$" CssClass="text-danger" Display="Dynamic" />
        <asp:Label ID="LastNameLabel" runat="server" Text="Last Name" Visible="true"></asp:Label>
        <asp:TextBox ID="LastName" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorLN" 
            runat="server" 
            Text="Last name is required field." 
            ControlToValidate="LastName" 
            SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidatorLN"
            runat="server" 
            ValidationGroup="EmployeeInfo"
            ErrorMessage="Employee last name must be between 2 and 20 characters long and contain only letters."
            ControlToValidate="LastName" ValidationExpression="^[A-Za-z]{2,20}$" CssClass="text-danger" Display="Dynamic" />
        <asp:Label ID="PersonalIdLabel" runat="server" Text="Personal ID" Visible="true"></asp:Label>
        <asp:TextBox ID="PersonalId" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorPID" 
            runat="server" 
            Text="First Name is required." 
            ControlToValidate="PersonalId" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidatorPID" 
            runat="server" 
            ValidationGroup="EmployeeInfo"
            ErrorMessage="Employee personal id must be exactly 10 digits long and contain only digits."
            ControlToValidate="PersonalId" ValidationExpression="^[0-9]{10}$" CssClass="text-danger" Display="Dynamic" />
        <asp:Label ID="CreatedDateLabel" runat="server" Text="Created Date" Visible="true"></asp:Label>
        <asp:TextBox ID="CreatedDate" runat="server" TextMode="Date" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="SocialSecurityIncomeLabel" runat="server" Text="Social security income" Visible="true"></asp:Label>
        <asp:TextBox ID="SocialSecurityIncome" runat="server" TextMode="Number" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorSSI" 
            runat="server" 
            Text="Social security income is required field." 
            ControlToValidate="SocialSecurityIncome" 
            SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:Button ID="CalculateSocialSecurityContributions" runat="server" Text="Calculate" CssClass="btn btn-info" Visible="true" OnClick="CalculateSocialSecurityContributions_Click" />
    </div>
    <asp:GridView ID="DetailsViewSelfEmploymentContributions"
            runat="server"
            AutoGenerateColumns="true"
            CssClass="table table-responsive table-striped table-bordered table-hover table-condensed table-background">
            <Columns>
            </Columns>
        </asp:GridView>
</asp:Content>
