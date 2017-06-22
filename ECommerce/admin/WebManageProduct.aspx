﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="WebManageProduct.aspx.cs" Inherits="ECommerce.Admin.WebManageProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .body-content {
            padding-left: 12.5% !important;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            //documentation : http://docs.jquery.com/Plugins/Validation/validate		
            $('#validateform').validate({
                errorElement: 'div',
                errorClass: 'help-block',
                focusInvalid: false,
               

                rules: {
                    
                    <%= txtpname.UniqueID %>: {
                         required: true
                     },
                    <%= ddlsell.UniqueID %>: {
                          required: true
                      },
                    <%= ddlcat.UniqueID %>: {
                              required: true
                          }
               
                },

                messages: {
                   
                    <%= txtpname.UniqueID %> : {
                        required: "Please Specify Product Name.",
                    },
                    <%= ddlsell.UniqueID %> : {
                              required: "Please Specify Seller Name.",
                          },
                    <%= ddlcat.UniqueID %> : {
                         required: "Please Specify Category Name.",
                     }
                     
                },
                highlight: function (e) {
                    $(e).closest('.form-group').removeClass('has-info').addClass('has-error');
                },

                success: function (e) {
                    $(e).closest('.form-group').removeClass('has-error').addClass('has-info');
                    $(e).remove();
                },

                errorPlacement: function (error, element) {
                    if (element.is(':checkbox') || element.is(':radio')) {
                        var controls = element.closest('div[class*="col-"]');
                        if (controls.find(':checkbox,:radio').length > 1) controls.append(error);
                        else error.insertAfter(element.nextAll('.labels:eq(0)').eq(0));
                    }
                    else error.insertAfter(element.parent());
                },

                submitHandler: function (form) {
                },
                invalidHandler: function (form) {
                }
            });


            
           
        });

    </script>

    <div class="container-fluid body-content">
        <ol class="breadcrumb">
            <li><a href="WebAdminHome.aspx">Home</a></li>
            <li class="active">Manage Product </li>

        </ol>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Manage Product </h3>

            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-offset-3 col-md-6">
                        <!--<autocomplete ng-model="yourchoice" data="movies" ></autocomplete>-->
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>


                        <div class="form-group">
                            <div class="clearfix">
                            <label for="product" class="control-label">Product Name:</label>
                            <asp:TextBox ID="txtpname" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="txtpname" ErrorMessage="Please Enter Product Name" ForeColor="Red" Font-Bold="true" Display="Dynamic" />

                        </div>
                            </div>
                        <div class="form-group">
                            <label for="fupload">Upload Image:</label>
                            <asp:FileUpload ID="fuproduct" runat="server" CssClass="btn btn-link" />


                        </div>
                        <div class="form-group">
                            <label for="desc">Description:</label>
                            <asp:TextBox ID="txtdesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="txtdesc" ErrorMessage="Please Enter Description" ForeColor="Red" Font-Bold="true" Display="Dynamic" />
                        </div>
                        <div class="form-group">
                            <label for="pcat">Seller</label>
                            <asp:DropDownList ID="ddlsell" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="ddlsell" ErrorMessage="Please Select Seller" ForeColor="Red" Font-Bold="true" Display="Dynamic" />
                        </div>

                        <div class="form-group">
                            <label for="desc">Seller Description:</label>
                            <asp:TextBox ID="txtsdesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="txtsdesc" ErrorMessage="Please Enter Description" ForeColor="Red" Font-Bold="true" Display="Dynamic" />
                        </div>
                        <div class="form-group">
                            <label for="pcat">Category</label>
                            <asp:DropDownList ID="ddlcat" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlcat_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="ddlcat" ErrorMessage="Please Select categary" ForeColor="Red" Font-Bold="true" Display="Dynamic" />
                        </div>

                        <div class="form-group" id="dvsubcat" runat="server">
                            <label for="subcat">SubCategory</label>
                            <asp:DropDownList ID="ddlsubcat" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="ddlsubcat" ErrorMessage="Please Select  subcategary" ForeColor="Red" Font-Bold="true" Display="Dynamic" />
                        </div>

                        <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClientClick="return checkvalid();" OnClick="btnsave_Click" />
                        <asp:Button ID="btnreset" runat="server" CssClass="btn btn-default" Text="Reset" CausesValidation="false" />
                    </div>

                </div>
                <div class="row">
                    <div class="col-lg-1">
                        &nbsp;
                    </div>
                    <div class="separator"></div>

                    <div class="row" id="dvgrid" runat="server">
                        <div class="col-lg-12" style="padding: 7px 7px 7px 7px !important">

                            <asp:GridView ID="gvmanageproduct" runat="server" AllowPaging="true" PageSize="5" DataKeyNames="CategaryId" CssClass="table table-bordered table-responsive table-hover" AutoGenerateColumns="False" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Product Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("CategaryName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Categary">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("SubCategaryName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <div class="glyphicon">
                                                <i class="glyphicon glyphicon-pencil form-control-feedback"></i>
                                                <asp:Button ID="btnedit" runat="server" BackColor="Transparent" BorderWidth="0" CausesValidation="false" CssClass="btn btn-default" CommandArgument='<%# Eval("CategaryId") %>'></asp:Button>
                                            </div>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <div class="glyphicon">
                                                <i class="glyphicon glyphicon-trash form-control-feedback"></i>
                                                <asp:Button ID="btndel" runat="server" BackColor="Transparent" BorderWidth="0" class="btn btn-default" CausesValidation="false" CommandArgument='<%# Eval("CategaryId") %>'></asp:Button>
                                            </div>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
