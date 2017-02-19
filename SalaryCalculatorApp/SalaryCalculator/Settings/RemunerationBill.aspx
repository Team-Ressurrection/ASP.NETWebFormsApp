<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RemunerationBill.aspx.cs" Inherits="SalaryCalculator.Settings.RemunerationBill" %>

<asp:Content id="ContentBody" contentplaceholderid="MainContent" runat="server">
    <asp:ListView ID="NonLaborContracts" runat="server" ItemType="SalaryCalculator.Data.Models.RemunerationBill"
        SelectMethod="NonLaborContracts_GetData"
        UpdateMethod="NonLaborContracts_UpdateContract"
        DeleteMethod="NonLaborContracts_DeleteContract"
        InsertItemPosition="LastItem"
        DataKeyNames="Id">
        <LayoutTemplate>
            <table class="gridview table table-responsive table-striped table-bordered table-hover table-condensed table-background" border="1" id="MainContent_GridViewRemunerationBill" style="border-collapse: collapse;">
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
                        <td colspan="10">
                            <asp:DataPager runat="server" ID="DataPagerPaycheck" PageSize="5">
                                <Fields>
                                     <asp:NextPreviousPagerField PreviousPageText="<" FirstPageText="|<" ShowPreviousPageButton="true"
                                        ShowFirstPageButton="true" ShowNextPageButton="false" ShowLastPageButton="false"
                                        ButtonCssClass="btn btn-default btn-xs" RenderNonBreakingSpacesBetweenControls="false" RenderDisabledButtonsAsLabels="false" />
                                    <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="btn btn-primary btn-xs disabled" RenderNonBreakingSpacesBetweenControls="false"
                                        NumericButtonCssClass="btn btn-default btn-xs" ButtonCount="10" NextPageText="..." NextPreviousButtonCssClass="btn btn-default btn-xs" />
                                    <asp:NextPreviousPagerField NextPageText=">" LastPageText=">|" ShowNextPageButton="true"
                                        ShowLastPageButton="true" ShowPreviousPageButton="false" ShowFirstPageButton="false"
                                        ButtonCssClass="btn btn-default btn-xs" RenderNonBreakingSpacesBetweenControls="false" RenderDisabledButtonsAsLabels="false" />
                                
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
                <td><%#: Item.SocialSecurityIncome %></td>
                <td><%#: Item.PersonalInsurance %></td>
                <td><%#: Item.IncomeTax %></td>
                <td><%#: Item.NetWage %></td>
                <td>
                    <asp:Button runat="server" ID="LinkButtonEdit" Text="Edit" CommandName="Edit" CssClass="btn btn-warning btn-xs" />
                    <asp:Button runat="server" ID="LinkButtonDelete" Text="Delete" CommandName="Delete" CssClass="btn btn-danger btn-xs" />
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
                    <asp:Button runat="server" ID="Button1" Text="Save" CommandName="Update" CssClass="btn btn-success btn-xs" />
                    <asp:Button runat="server" ID="Button2" Text="Cancel" CommandName="Cancel" CssClass="btn btn-danger btn-xs" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <%-- <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Employee.FirstName %>" />--%>
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButton1" Text="Insert" CommandName="Insert" />
                    <asp:LinkButton runat="server" ID="LinkButton2" Text="Cancel" CommandName="Cancel" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>
    </asp:Content>
