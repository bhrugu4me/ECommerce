<%@ Page Title="Admin - Manage Stock" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="WebManageStock.aspx.cs" Inherits="ECommerce.Admin.WebManageStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
      .body-content {
    padding-left:12.5% !important;
}
        </style>

    <div class="container-fluid body-content">
        <ol class="breadcrumb">
            <li><a href="WebAdminHome.aspx">Home</a></li>
            <li class="active">Manage Stock </li>
        </ol>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Manage Stock </h3>


            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-6">
                        <!--<autocomplete ng-model="yourchoice" data="movies" ></autocomplete>-->
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>

                        <div class="form-group">
                            <label for="lblsprod">Select Product</label>
                            <asp:DropDownList ID="ddlprod" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlprod_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="ddlprod" ErrorMessage="Please Select Product" ForeColor="Red" Font-Bold="true" Display="Dynamic" />
                            
                        </div>
                    </div>
                    </div>
                <div class="row">
                        <div class="col-md-6">
                            <label for="">Current Stock</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtcstock" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <label for="">Current Price</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtcprice"  cssclass="form-control" runat="server"></asp:TextBox>

                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label for="">New Stock</label>
                            <div class="form-group">
                                <asp:TextBox runat="server" cssclass="form-control" AutoPostBack="true" OnTextChanged="txtnewstck_TextChanged" ID ="txtnewstck"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Write New Stock" ID="RequiredFieldValidator1" ControlToValidate="txtnewstck" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <label for="">New Price</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtnprice" runat="server" CssClass="form-control"   OnTextChanged="txtnewstck_TextChanged"></asp:TextBox>

                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label for="">New Available Stock</label>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtnasotck" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-12"></div>
                        <div class="form-group  col-md-offset-3">

                            <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                            <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" CausesValidation="false" OnClick="btnsave_Click" />
                            <asp:Button ID="btnreset" runat="server" CssClass="btn btn-default" Text="Reset" CausesValidation="false" OnClick="btnreset_Click" />
                        </div>
                    </div>
                </div>
          
        </div>
    </div>


</asp:Content>
