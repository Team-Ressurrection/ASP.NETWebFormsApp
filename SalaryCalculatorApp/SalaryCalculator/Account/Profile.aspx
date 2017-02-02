<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="SalaryCalculator.Account.Profile" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" CssClass="jumbotron">
    <h1>User profile</h1>
    <asp:FileUpload ID="FileUpload" runat="server" />
    <asp:Button ID="ButtonLoad" runat="server" OnClick="ButtonLoad_Click" Text="Upload photo" CssClass="btn btn-warning"/>
</asp:Content>
