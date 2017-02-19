<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AllEmployees.aspx.cs" Inherits="SalaryCalculator.Settings.AllEmployees" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="Employees" runat="server" ItemType="SalaryCalculator.Data.Models.Employee"
        SelectMethod="Employees_GetData"
        UpdateMethod="Employees_UpdateEmployee"
        DeleteMethod="Employees_DeleteEmployee"
        InsertItemPosition="LastItem"
        DataKeyNames="Id">
        <LayoutTemplate>
            <table class="gridview table table-responsive table-striped table-bordered table-hover table-condensed table-background table-inverse" border="1" id="MainContent_GridViewEmployees" style="border-collapse: collapse;">
                <tbody>
                    <tr>
                        <th scope="col">
                            <asp:LinkButton Text="First Name" runat="server" ID="LinkButtonFirstName" CommandName="Sort" CommandArgument="FirstName" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Middle Name" runat="server" ID="LinkButtonMiddleName" CommandName="Sort" CommandArgument="MiddleName" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Last Name" runat="server" ID="LinkButtonLastName" CommandName="Sort" CommandArgument="LastName" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Personal ID" runat="server" ID="LinkButtonPID" CommandName="Sort" CommandArgument="PersonalId" />
                        </th>
                        <th scope="col">Modify</th>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    <tr>
                        <td colspan="5">
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
                <td><%#: Item.FirstName %></td>
                <td><%#: Item.MiddleName %></td>
                <td><%#: Item.LastName %></td>
                <td><%#: Item.PersonalId %></td>
                <td>
                    <asp:Button runat="server" ID="LinkButtonEdit" Text="Edit" CommandName="Edit" CssClass="btn btn-warning btn-xs" />
                    <asp:Button runat="server" ID="LinkButtonDelete" Text="Delete" CommandName="Delete" CssClass="btn btn-danger btn-xs" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxFirstName" Text="<%#: BindItem.FirstName %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxMiddleName" Text="<%#: BindItem.MiddleName %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxLastName" Text="<%#: BindItem.LastName %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxPersonalId" Text="<%#: BindItem.PersonalId %>" />
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
                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.FirstName %>" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButton1" Text="Insert" CommandName="Insert" />
                    <asp:LinkButton runat="server" ID="LinkButton2" Text="Cancel" CommandName="Cancel" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
