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

          function checkvalid() {
              var submit = true;

              var $valid = $("#validateform").valid();
              if (!$valid) {
                  $validator.focusInvalid();
                  submit = false;
              }
              return submit;

          }


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
                            <div class="col-md-4">
                                <div class="clearfix">
         
                                    <asp:TextBox ID="txtbname" runat="server"  CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server"  CssClass="help-block" ControlToValidate="txtbname" ErrorMessage="Please Enter Brand Name" ForeColor="Red" Font-Bold="true" Display="None" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="desc" class="col-sm-4 control-label">Description:</label>
                            <div class="col-md-4">
                                <div class="clearfix">
                            <asp:TextBox ID="txtdesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                       <div class="form-actions">
                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-9">
                       
                     <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                    <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClientClick="return checkvalid();" OnClick="btnsave_Click"  />
                   <asp:Button ID="btnreset" runat="server" CssClass="btn btn-default" Text="Reset" OnClick="btnreset_Click" />

                       
                </div>
            </div>
                           </div>
                    </div>
                </div>
            <div class="row">
                <div class="col-lg-1">
                    &nbsp;
                </div>
            </div>
         <div class="separator"></div>
             
                   <div class="row" id="dvgrid" runat="server">
                <div class="col-lg-8 col-md-offset-2">
                    
                    <asp:GridView ID="gvmanageBrand" runat="server" AllowPaging="true" PageSize="5" DataKeyNames="BrandId" CssClass="table table-bordered table-responsive table-hover" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Brand Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("BrandName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                             <asp:TemplateField HeaderText="Edit">
                                  <ItemTemplate>
                                      <div class="glyphicon">
            <i class="glyphicon glyphicon-pencil form-control-feedback"></i>
            <asp:Button ID="btnedit" runat="server" BackColor="Transparent" BorderWidth="0" CausesValidation="false" CssClass="btn btn-default" OnClick="btnedit_Click" CommandArgument='<%# Eval("BrandId") %>' ></asp:Button>
        </div>
                                </ItemTemplate>
                         
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                 <ItemTemplate>
                                      <div class="glyphicon">
            <i class="glyphicon glyphicon-trash form-control-feedback"></i>
            <asp:Button ID="btndel" runat="server" BackColor="Transparent" BorderWidth="0" class="btn btn-default"  CausesValidation="false" CommandArgument='<%# Eval("BrandId") %>' OnClick="btndel_Click"></asp:Button>
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
</asp:Content>
