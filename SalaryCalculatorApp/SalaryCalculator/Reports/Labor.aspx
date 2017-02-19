<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Labor.aspx.cs" Inherits="SalaryCalculator.Reports.Labor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Labor report</h1>
    </div>
    <asp:GridView ID="AllLaborContracts" 
                  runat="server"
                  AutoGenerateColumns="true"
                  CssClass="table table-responsive table-striped table-bordered table-hover table-condensed table-background"
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
        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
    </asp:GridView>
</asp:Content>
