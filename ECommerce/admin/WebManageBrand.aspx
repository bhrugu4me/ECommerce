<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="WebManageBrand.aspx.cs" Inherits="ECommerce.admin.WebManageBrand" %>

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
                    
                     <%= txtbname.UniqueID %>: {
                        required: true
                    }
                },

                messages: {
                   
                    <%= txtbname.UniqueID %> : {
                        required: "Please Specify Brand Name.",
                    }
                },

                invalidHandler: function (event, validator) { //display error alert on form submit   
                    $('.alert-danger', $('.login-form')).show();
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
        <li class="active">Manage Brand </li>
    </ol>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Manage Brand </h3>

        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-offset-3 col-md-6">
                        <!--<autocomplete ng-model="yourchoice" data="movies" ></autocomplete>-->
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
               
            
                        <div class="form-group">
                            <label for="Brand" class="col-sm-4 control-label">Brand Name:</label>
                            <div class="col-md-6">
                                <div class="clearfix">
         
                                    <asp:TextBox ID="txtbname" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server"  CssClass="help-block" ControlToValidate="txtbname" ErrorMessage="Please Enter Brand Name" ForeColor="Red" Font-Bold="true" Display="None" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="desc" class="col-sm-4 control-label">Description:</label>
                            <div class="col-md-6">
                                <div class="clearfix">
                            <asp:TextBox ID="txtdesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-9">
                       
                     <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                                <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClientClick="return checkvalid();" />
                   <asp:Button ID="btnreset" runat="server" CssClass="btn btn-default" Text="Reset" />
                </div>
            </div>
                    </div>
                </div>
            <div class="row">
                <div class="col-lg-1">
                    &nbsp;
                </div>
            </div>
        
        </div>
    </div>

    

    
</div>
</asp:Content>
