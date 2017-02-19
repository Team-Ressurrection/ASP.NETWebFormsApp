<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AllUsers.aspx.cs" Inherits="SalaryCalculator.Settings.AllUsers" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="Users" runat="server" ItemType="SalaryCalculator.Data.Models.User"
        SelectMethod="Users_GetData"
        UpdateMethod="Users_UpdateUser"
        DeleteMethod="Users_DeleteUser"
        InsertItemPosition="LastItem"
        DataKeyNames="Id">
        <LayoutTemplate>
            <table class="gridview table table-responsive table-striped table-bordered table-hover table-condensed table-background table-inverse" border="1" id="MainContent_GridViewUsers" style="border-collapse: collapse;">
                <tbody>
                    <tr>
                        <th scope="col">
                            <asp:LinkButton Text="E-Mail" runat="server" ID="LinkButtonEMail" CommandName="Sort" CommandArgument="Email" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Username" runat="server" ID="LinkButtonUserName" CommandName="Sort" CommandArgument="UserName" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Company Name" runat="server" ID="LinkButtonCompanyName" CommandName="Sort" CommandArgument="CompanyName" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Company Address" runat="server" ID="LinkButtonCompanyAddress" CommandName="Sort" CommandArgument="CompanyAddress" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Image Path" runat="server" ID="LinkButtonImagePath" CommandName="Sort" CommandArgument="ImagePath" />
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
                <td><%#: Item.Email %></td>
                <td><%#: Item.UserName %></td>
                <td><%#: Item.CompanyName %></td>
                <td><%#: Item.CompanyAddress %></td>
                <td><%#: Item.ImagePath %></td>
                <td>
                    <asp:Button runat="server" ID="LinkButtonEdit" Text="Edit" CommandName="Edit" CssClass="btn btn-warning btn-xs" />
                    <asp:Button runat="server" ID="LinkButtonDelete" Text="Delete" CommandName="Delete" CssClass="btn btn-danger btn-xs" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxEMail" Text="<%#: BindItem.Email %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxUN" Text="<%#: BindItem.UserName %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxCN" Text="<%#: BindItem.CompanyName %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxCA" Text="<%#: BindItem.CompanyAddress %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxImagePath" Text="<%#: BindItem.ImagePath %>" />
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
                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Email %>" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButton1" Text="Insert" CommandName="Insert" />
                    <asp:LinkButton runat="server" ID="LinkButton2" Text="Cancel" CommandName="Cancel" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
