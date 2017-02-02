<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalaryCalculator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>SALARY CALCULATOR</h1>
        <p class="lead">This is a simple application, which allows you to calculate your incomes both from labor and non-labor contracts</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4 jumbotron">
            <h2>LABOR CONTRACTS</h2>
            <p>
                You can easily calculate your social security income and social securities taxes.           
            </p>
            <p>
                <a class="btn btn-info" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4 jumbotron">
            <h2>NON-LABOR CONTRACTS</h2>
            <p>
                You can easily calculate your social security income and social securities taxes.
                In just seconds you can get your net wage.           
            </p>
            <p>
                <a class="btn btn-info" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4 jumbotron">
            <h2>FREELANCE CONTRACTS</h2>
            <p>
                You can easily your income as freelancer.
            </p>
            <p>
                <a class="btn btn-info" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
