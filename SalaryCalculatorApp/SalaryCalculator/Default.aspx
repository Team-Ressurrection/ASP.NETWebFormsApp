<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalaryCalculator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>SALARY CALCULATOR</h1>
        <p class="lead">This is a simple application, which allows you to calculate your incomes both from labor and non-labor contracts.
            You can easily calculate your social security income and social securities taxes.
                In just seconds you can get your net wage.
        </p>
        <p><a href="https://www.youtube.com/watch?v=EYgRIzkijdc&feature=youtu.be" class="btn btn-primary btn-block">View quick demo &raquo;</a></p>
    </div>
    <div class="row">
        <h2>Latest registered users</h2>
        <asp:Repeater ID="LatestUsersGridView" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col-md-3 jumbotron" style="margin: 5px">
                    <p>
                        <span class="glyphicon glyphicon-user">Username: </span><%# DataBinder.Eval(Container.DataItem, "UserName") %>
                    </p>
                    <p>
                        <span class="glyphicon glyphicon-hand-right">E-mail: </span><%# DataBinder.Eval(Container.DataItem, "EMail") %>
                    </p>
                    <p>
                        <span class="glyphicon glyphicon-tower">Company name: </span><%# DataBinder.Eval(Container.DataItem, "CompanyName") %>
                    </p>
                    <p>
                        <span class="glyphicon glyphicon-lock">Company address: </span><%# DataBinder.Eval(Container.DataItem, "CompanyAddress") %>
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <%--        <asp:GridView runat="server"
              CssClass="table table-bordered table-hover table-striped table-background" BorderStyle="Double"
              ID="LatestUsersGridView"
              ItemType="SalaryCalculator.Data.Models.User"
              AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="Position">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="UserName" HeaderText="UserName"/>
        <asp:BoundField DataField="EMail" HeaderText="E-Mail"/>
        <asp:BoundField DataField="CompanyName" HeaderText="Company Name"/>
        <asp:BoundField DataField="CompanyAddress" HeaderText="Company Address"/>
    </Columns>
</asp:GridView>--%>
    </div>
    <div class="row">
        <div class="col-md-3 jumbotron" style="margin: 5px">
            <h2>Legislation</h2>
            <p>
                For more information about Labour legislation area visit here.           
            </p>
            <p>
                <a class="btn btn-info" href="https://www.mlsp.government.bg/index.php?section=CONTENT&I=629">MLSP &raquo;</a>
            </p>
        </div>
        <div class="col-md-3 jumbotron" style="margin: 5px">
            <h2>Taxes</h2>
            <p>
                For more information about taxes visit National Revenue Agency site.          
            </p>
            <p>
                <a class="btn btn-info" href="http://www.nap.bg/page?id=387">NRA &raquo;</a>
            </p>
        </div>
        <div class="col-md-3 jumbotron" style="margin: 5px">
            <h2>Insurance</h2>
            <p>
                For more information about social security information visit National Social Security Institute
            </p>
            <p>
                <a class="btn btn-info" href="http://www.nssi.bg/legislationbg">NSSI &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
