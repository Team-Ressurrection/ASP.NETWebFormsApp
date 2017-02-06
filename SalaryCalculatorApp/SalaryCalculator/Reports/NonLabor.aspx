<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NonLabor.aspx.cs" Inherits="SalaryCalculator.Reports.NonLabor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>NonLabor report</h1>
    </div>
    <asp:GridView ID="AllNonLaborContracts" 
                  runat="server"
                  AutoGenerateColumns="true"
                  CssClass="jumbotron"
                  AllowPaging="true"
                  PageSize="5"
                  PageIndex="1"
                  OnPageIndexChanging="AllNonLaborContracts_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Employee Name">
                <ItemTemplate>
                    <%#: Eval("Employee.FirstName") %>  
                    <%#: Eval("Employee.MiddleName") %> 
                    <%#: Eval("Employee.LastName") %> 
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
