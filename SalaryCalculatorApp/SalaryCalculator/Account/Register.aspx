﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SalaryCalculator.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="jumbotron">
        <h2><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <h4>Create a new account</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                        CssClass="text-danger" ErrorMessage="The email field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CompanyName" CssClass="col-md-2 control-label">Company Name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="CompanyName" CssClass="form-control"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CompanyName"
                        CssClass="text-danger" ErrorMessage="The company name field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CompanyAddress" CssClass="col-md-2 control-label">Company Address</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="CompanyAddress" CssClass="form-control"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CompanyAddress"
                        CssClass="text-danger" ErrorMessage="The company address field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                        CssClass="text-danger" ErrorMessage="The password field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

