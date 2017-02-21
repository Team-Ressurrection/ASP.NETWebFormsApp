<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateNonLaborContract.aspx.cs" Inherits="SalaryCalculator.JobContracts.CreateNonLaborContract" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>NonLabor contract</h1>
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
        <asp:Label ID="ContractValueLabel" runat="server" Text="Gross Contract Value" Visible="true"></asp:Label>
        <asp:TextBox ID="ContractValue" runat="server" TextMode="Number" CssClass="form-control" Visible="true"></asp:TextBox>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidatorCV"
            runat="server"
            Text="Contract value is required field."
            ControlToValidate="ContractValue"
            SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:Button ID="CalculateWage" runat="server" Text="Calculate" CssClass="btn btn-info" Visible="true" OnClick="CalculateWage_Click" />
        <asp:Button ID="SaveDocument" runat="server" Text="Save" CssClass="btn btn-danger" Visible="false" OnClick="SaveDocument_Click" />
        <asp:Literal ID="SmetkaIzplateniSumi" runat="server" Visible="false">
            <h2>СМЕТКА ЗА ИЗПЛАТЕНИ СУМИ</h2>
            <p>1. Сума по тази сметка</p>
            <p>2. Нормативно признати разходи за дейността (25% или 40% от ред 1)</p>
            <p>3. Облагаем доход по тази сметка (ред 1 – ред 2)</p>
            <p>4. Облагаема част от сумата на ред 3 (попълва се от физическото лице)</p>
            <p>5. Осигурителен доход от сумата на ред 1, върху който се дължат осигурителни вноски (попълва се от физическото лице)</p>
            <p>6. Задължителни осигурителни вноски, в т.ч. за:	</p>
            <p>а) за фондовете на ДОО ( ….% от ред 5, съгласно т. 1 от забележката)</p>
            <p>б) допълнително задължително пенсионно осигуряване (ДЗПО) в универсален</p>
            <p>в) здравно осигуряване (3.2% от ред 5 )</p>
            <p>7. Сума, подлежаща на авансово облагане (ред 4 - ред 6)</p>
            <p>8. Дължим авансов данък (10% от ред 7)</p>
            <p>9. Сума за получаване (ред 1 – ред 6 – ред 8)</p>
        </asp:Literal>
    </div>
    <asp:GridView ID="DetailsViewRemunerationBill"
        runat="server"
        AutoGenerateColumns="false"
        CssClass="table table-responsive table-striped table-bordered table-hover table-condensed table-background">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" DataFormatString="{0:d}" />
            <asp:BoundField DataField="Employee.FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="Employee.MiddleName" HeaderText="Middle Name" />
            <asp:BoundField DataField="Employee.LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="GrossSalary" HeaderText="Gross Salary" DataFormatString="{0:F2}" />
            <asp:BoundField DataField="SocialSecurityIncome" HeaderText="Social security income" DataFormatString="{0:F2}" />
            <asp:BoundField DataField="PersonalInsurance" HeaderText="Personal insurance" DataFormatString="{0:F2}" />
            <asp:BoundField DataField="IncomeTax" HeaderText="Income Tax" DataFormatString="{0:F2}" />
            <asp:BoundField DataField="NetWage" HeaderText="Net Wage" DataFormatString="{0:F2}" />
        </Columns>
    </asp:GridView>
</asp:Content>
