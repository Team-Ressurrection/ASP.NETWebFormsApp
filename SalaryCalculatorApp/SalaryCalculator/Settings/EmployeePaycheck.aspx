<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeePaycheck.aspx.cs" Inherits="SalaryCalculator.Settings.Administrator" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="LaborContracts" runat="server" ItemType="SalaryCalculator.Data.Models.EmployeePaycheck"
        SelectMethod="AllLaborContracts_GetData"
        UpdateMethod="LaborContracts_UpdateContract"
        DeleteMethod="LaborContracts_DeleteContract"
        InsertItemPosition="LastItem"
        DataKeyNames="Id">
        <LayoutTemplate>
            <table class="gridview jumbotron" border="1" id="MainContent_GridViewPaycheck" style="border-collapse: collapse;">
                <tbody>
                    <tr>
                        <th scope="col">
                            <asp:LinkButton Text="Created Date" runat="server" ID="LinkButtonCreatedDate" CommandName="Sort" CommandArgument="CreatedDate" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="First Name" runat="server" ID="LinkButtonFirstName" CommandName="Sort" CommandArgument="Employee.FirstName" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Middle Name" runat="server" ID="LinkButtonMiddleName" CommandName="Sort" CommandArgument="Employee.MiddleName" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Last Name" runat="server" ID="LinkButtonLastName" CommandName="Sort" CommandArgument="Employee.LastName" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Gross Salary" runat="server" ID="LinkButtonGS" CommandName="Sort" CommandArgument="GrossSalary" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Gross Fixed Bonus" runat="server" ID="LinkButtonGFB" CommandName="Sort" CommandArgument="GrossFixedBonus" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Gross Non Fixed Bonus" runat="server" ID="LinkButtonGNFB" CommandName="Sort" CommandArgument="GrossNonFixedBonus" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Social Security Income" runat="server" ID="LinkButtonSSI" CommandName="Sort" CommandArgument="SocialSecurityIncome" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Personal Insurance" runat="server" ID="LinkButtonPI" CommandName="Sort" CommandArgument="PersonalInsurance" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Income Tax" runat="server" ID="LinkButtonIncomeTax" CommandName="Sort" CommandArgument="IncomeTax" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Net Wage" runat="server" ID="LinkButtonNetWage" CommandName="Sort" CommandArgument="NetWage" />
                        </th>
                        <th scope="col">Modify</th>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    <tr>
                        <td colspan="2">
                            <asp:DataPager runat="server" ID="DataPagerPaycheck" PageSize="5">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.CreatedDate %></td>
                <td><%#: Item.Employee.FirstName %></td>
                <td><%#: Item.Employee.MiddleName %></td>
                <td><%#: Item.Employee.LastName %></td>
                <td><%#: Item.GrossSalary %></td>
                <td><%#: Item.GrossFixedBonus %></td>
                <td><%#: Item.GrossNonFixedBonus %></td>
                <td><%#: Item.SocialSecurityIncome %></td>
                <td><%#: Item.PersonalInsurance %></td>
                <td><%#: Item.IncomeTax %></td>
                <td><%#: Item.NetWage %></td>
                <td>
                    <asp:Button runat="server" ID="LinkButtonEdit" Text="Edit" CommandName="Edit" CssClass="btn btn-warning" />
                    <asp:Button runat="server" ID="LinkButtonDelete" Text="Delete" CommandName="Delete" CssClass="btn btn-danger" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxCreatedDate" Text="<%#: BindItem.CreatedDate %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxFirstName" Text="<%#: BindItem.Employee.FirstName %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxMiddleName" Text="<%#: BindItem.Employee.MiddleName %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxLastName" Text="<%#: BindItem.Employee.LastName %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxGrossSalary" Text="<%#: BindItem.GrossSalary %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxGrossFixedBonus" Text="<%#: BindItem.GrossFixedBonus %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxGrossNonFixedBonus" Text="<%#: BindItem.GrossNonFixedBonus %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxSSI" Text="<%#: BindItem.SocialSecurityIncome %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxPI" Text="<%#: BindItem.PersonalInsurance %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxIncomeTax" Text="<%#: BindItem.IncomeTax %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxNetWage" Text="<%#: BindItem.NetWage %>" />
                </td>


                <td>
                    <asp:Button runat="server" ID="LinkButtonEdit" Text="Save" CommandName="Update" CssClass="btn btn-success" />
                    <asp:Button runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" CssClass="btn btn-danger" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <%-- <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Employee.FirstName %>" />--%>
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Insert" CommandName="Insert" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>

    <%--    <asp:GridView ID="AllNonLaborContracts"
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
                    <%--<%#: Eval("Employee.FirstName") %>
                    <%#: Eval("Employee.MiddleName") %>
                    <%#: Eval("Employee.LastName") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
</asp:Content>

<%--<asp:Content runat="server" ContentPlaceHolderID="MainContent" CssClass="jumbotron">
    <h1>Administrator settings</h1>

    <asp:GridView ID="AllLaborContracts" 
                  runat="server"
                  SelectMethod="AllLaborContracts_GetData"
                  AutoGenerateColumns="true"
                  CssClass="jumbotron"
                  AllowPaging="false"
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

        
</asp:Content>--%>
