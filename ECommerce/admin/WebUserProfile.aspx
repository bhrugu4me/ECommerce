<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="WebUserProfile.aspx.cs" Inherits="ECommerce.admin.WebUserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid body-content">
        <ol class="breadcrumb">
            <li><a href="WebAdminHome.aspx">Home</a></li>
            <li class="active">User Profile </li>
        </ol>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">User Profile </h3>

            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-offset-3 col-md-6">
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        <div class="form-group">
                            <label for="FirstName" class="col-sm-6 control-label">First Name:</label>
                            <div class="col-md-6">
                                <div class="clearfix">
                                    <asp:TextBox ID="txtfirstName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-6 control-label">Last Name:</label>
                            <div class="col-md-6">
                                <div class="clearfix">
                                    <asp:TextBox ID="txtlastname" runat="server" CssClass="form-control" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-6 control-label">Gender:</label>
                            <div class="col-sm-6">
                                <div class="input-group clearfix">
                                    <asp:RadioButtonList ID="rbgender" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                         <div class="form-group">
                            <label for="EmailId" class="col-sm-6 control-label">Email Id:</label>
                            <div class="col-md-6">
                                <div class="clearfix">
                                    <asp:TextBox ID="txtemailid" runat="server" CssClass="form-control" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-6 control-label">Birth Date:</label>
                            <div class="col-sm-6">
                                <div class="clearfix">
                                    <asp:TextBox ID="txtbirthdate" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-6 control-label" for="Phone">Contact No:</label>
                            <div class="col-sm-6">
                                <div class="input-group clearfix">
                                    <span class="input-group-addon"><i class="fa fa-phone"></i></span>
                                    <asp:TextBox type="text" ID="txtmobileno" runat="server" CssClass="form-control Phone"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-6 control-label" for="utype">User Type:</label>
                            <div class="col-sm-6">
                                <div class="input-group clearfix">
                                    <asp:DropDownList ID="ddlusertype" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="form-group">
                                <div class="col-sm-offset-4 col-sm-9">
                                    <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                                    <asp:LinkButton ID="btnsave" runat="server" ClientIDMode="Static" CssClass="btn btn-primary" Text="Save" OnClientClick="return checkvalid();" OnClick="btnsave_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="btnreset" runat="server" ClientIDMode="Static" type="reset" CausesValidation="false" CssClass="btn btn-default" Text="Reset" OnClick="btnreset_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>




    </div>
</asp:Content>
