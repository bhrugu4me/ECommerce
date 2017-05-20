<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="WebManageBrand.aspx.cs" Inherits="ECommerce.admin.WebManageBrand" %>
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
                            <asp:TextBox ID="txtcname" runat="server" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="txtcname" ErrorMessage="Please Enter Brand Name" ForeColor="Red" Font-Bold="true" Display="Dynamic" />
         
                        </div>
                        <div class="form-group">
                            <label for="desc">Description:</label>
                            <asp:TextBox ID="txtdesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                              <asp:RequiredFieldValidator runat="server" CssClass="help-block" ControlToValidate="txtcname" ErrorMessage="Please Enter Description" ForeColor="Red" Font-Bold="true" Display="Dynamic" />
                        </div>
                       
                     <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                    <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnsave_Click"  />
                   <asp:Button ID="btnreset" runat="server" CssClass="btn btn-default" Text="Reset" />
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
