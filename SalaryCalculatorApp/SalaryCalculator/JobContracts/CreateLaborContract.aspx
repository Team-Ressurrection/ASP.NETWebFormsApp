<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateLaborContract.aspx.cs" Inherits="SalaryCalculator.JobContracts.CreateLaborContract" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Labor contract</h1>
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
        <asp:Label ID="GrossBaseSalaryLabel" runat="server" Text="Gross Contract Value" Visible="true"></asp:Label>
        <asp:TextBox ID="GrossBaseSalary" runat="server" TextMode="Number" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidatorGBS"
            runat="server"
            Text="Gross salary is required field."
            ControlToValidate="GrossBaseSalary"
            SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:Label ID="FixedBonusLabel" runat="server" Text="Fixed Monthly bonus" Visible="true"></asp:Label>
        <asp:TextBox ID="FixedBonus" runat="server" TextMode="Number" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Label ID="NonFixedBonusLabel" runat="server" Text="Non-Fixed Monthly bonus" Visible="true"></asp:Label>
        <asp:TextBox ID="NonFixedBonus" runat="server" TextMode="Number" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:Button ID="CalculateWage" runat="server" Text="Calculate" CssClass="btn btn-danger" Visible="true" OnClick="CalculateWage_Click" />
    </div>
    <asp:GridView ID="DetailsViewPaycheck"
        runat="server"
        AutoGenerateColumns="false"
        CssClass="table table-responsive table-striped table-bordered table-hover table-condensed table-background">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" DataFormatString="{0:d}" />
            <asp:BoundField DataField="Employee.FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="Employee.MiddleName" HeaderText="Middle Name" />
            <asp:BoundField DataField="Employee.LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="GrossSalary" HeaderText="Gross Salary" DataFormatString="{0:F2}"/>
            <asp:BoundField DataField="GrossFixedBonus" HeaderText="Gross Fixed Bonus" DataFormatString="{0:F2}"/>
            <asp:BoundField DataField="GrossNonFixedBonus" HeaderText="Gross Non-Fixed Bonus" DataFormatString="{0:F2}"/>
            <asp:BoundField DataField="SocialSecurityIncome" HeaderText="Social security income" DataFormatString="{0:F2}"/>
            <asp:BoundField DataField="PersonalInsurance" HeaderText="Personal insurance" DataFormatString="{0:F2}"/>
            <asp:BoundField DataField="IncomeTax" HeaderText="Income Tax" DataFormatString="{0:F2}"/>
            <asp:BoundField DataField="NetWage" HeaderText="Net Wage" DataFormatString="{0:F2}"/>
        </Columns>
    </asp:GridView>
</asp:Content>
