<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateNonLaborContract.aspx.cs" Inherits="SalaryCalculator.JobContracts.CreateNonLaborContract" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>NonLabor contract</h1>
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
        <asp:Label ID="ContractValueLabel" runat="server" Text="Gross Contract Value" Visible="true"></asp:Label>
        <asp:TextBox ID="ContractValue" runat="server" TextMode="Number" CssClass="form-control" Visible="true"></asp:TextBox>
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
</asp:Content>
