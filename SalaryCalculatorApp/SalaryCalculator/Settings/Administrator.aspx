<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Administrator.aspx.cs" Inherits="SalaryCalculator.Settings.Administrator" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" CssClass="jumbotron">
    <h1>Administrator settings</h1>

    <asp:GridView ID="AllLaborContracts" 
                  runat="server"
                  AutoGenerateColumns="true"
                  CssClass="jumbotron"
                  AllowPaging="true"
                  PageSize="5"
                  PageIndex="1"
                  OnPageIndexChanging="AllLaborContracts_PageIndexChanging">
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
