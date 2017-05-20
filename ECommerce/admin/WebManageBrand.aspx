﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="WebManageBrand.aspx.cs" Inherits="ECommerce.admin.WebManageBrand" %>
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
                            <label for="Brand" class="control-label" >Brand Name:</label>
                            <asp:TextBox ID="txtbname" runat="server" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="txtcname" ErrorMessage="Please Enter Brand Name" ForeColor="Red" Font-Bold="true" Display="Dynamic" />
         
                        </div>
                        <div class="form-group">
                            <label for="desc">Description:</label>
                            <asp:TextBox ID="txtdesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                              <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="txtcname" ErrorMessage="Please Enter Description" ForeColor="Red" Font-Bold="true" Display="Dynamic" />
                        </div>
                       
                     <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                    <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnreset_Click"  />
                   <asp:Button ID="btnreset" runat="server" CssClass="btn btn-default" Text="Reset" OnClick="btnreset_Click" />

                        <div class="separator"></div>
             
                   <div class="row" id="dvgrid" runat="server">
                <div class="col-lg-8 col-md-offset-2">
                    
                    <asp:GridView ID="gvmanageBrand" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvmanageproduct_PageIndexChanging" DataKeyNames="CategaryId" CssClass="table table-bordered table-responsive table-hover" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Brand Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("CategaryName") %>'></asp:Label>
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
            <asp:Button ID="btnedit" runat="server" BackColor="Transparent" BorderWidth="0" CausesValidation="false" CssClass="btn btn-default" OnClick="btnedit_Click" CommandArgument='<%# Eval("CategaryId") %>' ></asp:Button>
        </div>
                                </ItemTemplate>
                         
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                 <ItemTemplate>
                                      <div class="glyphicon">
            <i class="glyphicon glyphicon-trash form-control-feedback"></i>
            <asp:Button ID="btndel" runat="server" BackColor="Transparent" BorderWidth="0" class="btn btn-default"  CausesValidation="false" CommandArgument='<%# Eval("CategaryId") %>' OnClick="btndel_Click"></asp:Button>
        </div>
                                </ItemTemplate>
                         
                            </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
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
