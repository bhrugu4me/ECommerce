﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="WebChangePassword.aspx.cs" Inherits="ECommerce.admin.WebChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <style>
.body-content {
            padding-left: 12.5% !important;
        }
    </style>

    <script>
    </script>
      <script type="text/javascript">
          $(document).ready(function () {

             

            //documentation : http://docs.jquery.com/Plugins/Validation/validate		
            $('#validateform').validate({
                errorElement: 'div',
                errorClass: 'help-block',
                focusInvalid: false,
                rules: {
                    
                     <%= txtcurrpwd.UniqueID %>: {
                         required: true
                     },
                     <%= txtnewpwd.UniqueID %>: {
                         required: true
                     },
                     <%= txtcnewpwd.UniqueID %>: {
                         required: true,
                         // equalTo :'txtnewpwd'
                       //  equalTo : '[name="txtnewpwd"]'
                       //  passwordMatch: true 
                     },
                    
                },

                messages: {
                   
                    <%= txtcurrpwd.UniqueID %> : {
                        required: "Please Enter Current Password.",
                    },
                    
                    <%= txtnewpwd.UniqueID %> : {
                        required: "Please Enter New Password.",
                    },
                    
                    <%= txtcnewpwd.UniqueID %> : {
                        required: "Please Enter Confirm New Password.",
                       // passwordMatch:"Your Confirm Password must match with New Password"
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
        <li class="active">Change Password </li>
    </ol>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Change Password </h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-offset-3 col-md-6">
                        <!--<autocomplete ng-model="yourchoice" data="movies" ></autocomplete>-->
                        <asp:Label ID="lblmsg" runat="server" ></asp:Label>
                       <div class="form-group">
                            <label class="col-md-6 control-label" for="utype">Current Password:</label>
                            <div class="col-md-6">
                                <div class="input-group clearfix">
                                    <asp:TextBox type="text" ID="txtcurrpwd" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req1" runat="server" Display="None" ControlToValidate="txtcurrpwd" />
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="col-md-6 control-label" for="name">New Password:</label>
                            <div class="col-md-6">
                                <div class="clearfix">
                                    <asp:TextBox type="text" ID="txtnewpwd" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req2" runat="server" Display="None" ControlToValidate="txtnewpwd" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-6 control-label" for="name">Confirm New Password:</label>
                            <div class="col-md-6">
                                <div class="clearfix">
                                    <asp:TextBox type="text" ID="txtcnewpwd" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req3" runat="server" Display="None" ControlToValidate="txtcnewpwd" />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtnewpwd" ControlToValidate="txtcnewpwd" Display="None" ErrorMessage="CompareValidator"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>

                       <div class="form-actions">
                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-9">
                       
                     <asp:HiddenField ID="hdnid" runat="server" Value="0"  />
                     <asp:LinkButton ID="lnkbtnsave" runat="server" OnClientClick="return checkvalid();" CssClass ="btn btn-primary" text="save" OnClick="lnkbtnsave_Click"></asp:LinkButton>
                   <asp:LinkButton ID="lnkbtnreset" runat="server" CausesValidation="false" CssClass="btn btn-default" Text="Reset" OnClick="lnkbtnreset_Click"></asp:LinkButton> 

                       
                </div>
            </div>
                           </div>
                    </div>
                </div>
          
        </div>
    </div>

    

    
</div>
</asp:Content>
