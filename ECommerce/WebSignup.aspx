<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSignup.aspx.cs" Inherits="ECommerce.WebSignup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <!-- Bootstrap core CSS -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/fonts.css" />
    <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css" />
    <!-- PAGE LEVEL PLUGINS STYLES -->
    <!-- REQUIRE FOR SPEECH COMMANDS -->
    <link rel="stylesheet" type="text/css" href="assets/css/plugins/gritter/jquery.gritter.css" />

    <!-- Tc core CSS -->
    <link id="qstyle" rel="stylesheet" href="assets/css/themes/style-4.css" />
    <!--[if lte IE 8]>
		<link rel="stylesheet" href="assets/css/ie-fix.css" />
	<![endif]-->

    <style type="text/css">
        #ui-datepicker-div {
            z-index: 999 !important;
        }
    </style>

    <!-- core JavaScript -->



    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script src="assets/js/plugins/pace/pace.min.js"></script>
    <!-- PAGE LEVEL PLUGINS JS -->
    <script src="assets/js/plugins/fuelux/wizard.min.js"></script>
    <script src="assets/js/plugins/jquery-validation/jquery.validate.min.js"></script>
    <script src="assets/js/plugins/jquery-validation/additional-methods.min.js"></script>
    <script src="assets/js/plugins/bootstrap-datepicker/bootstrap-datepicker.js"></script>
    <!-- Themes Core Scripts -->
    <script src="assets/js/main.js"></script>

    <!-- REQUIRE FOR SPEECH COMMANDS -->
    <script src="assets/js/speech-commands.js"></script>
    <script src="assets/js/plugins/gritter/jquery.gritter.min.js"></script>

    <!-- initial page level scripts for examples -->
    <script src="assets/js/plugins/slimscroll/jquery.slimscroll.init.js"></script>
    <script>
        $(document).ready(function () {

            $.validator.addMethod("EMAIL", function (value, element) {
                return this.optional(element) || /^[a-zA-Z0-9._-]+@[a-zA-Z0-9-]+\.[a-zA-Z.]{2,5}$/i.test(value);
            }, "Email Id is invalid, Please enter a valid email id.");

            $.validator.addMethod("Phone", function (value, element) {
                return this.optional(element) || /[0-9-()+]{3,20}/i.test(value);
            }, "Enter valid phone number, enter only digits");

            $.validator.addMethod("DateFormat", function (value, element) {
                return value.match(/^(0[1-9]|[12][0-9]|3[01])[- //.](0[1-9]|1[012])[- //.](19|20)\d\d$/);
            }, "Please enter a date in the format dd/mm/yyyy");

            //documentation : http://docs.jquery.com/Plugins/Validation/validate		
            $('#validateform').validate({
                errorElement: 'div',
                errorClass: 'help-block',
                focusInvalid: false,
                rules: {
                    txtemail: {
                        required: true,
                        email: true
                    },
                    txtfirstname: {
                        required: true
                    },
                    txtlastname: {
                        required: true
                    },
                    txtcntno: {
                        required: true,
                        phone: true
                    },
                    txtpwd: {
                        required: true
                    },
                    txtcpwd: {
                        required: true
                    },
                    txtunm: {
                        required: true
                    },
                    ddlutype: {
                        required: true
                    },
                },

                messages: {
                    txtemail: {
                        required: "Please Specify Email.",
                        email: "Please provide a valid email."
                    },
                    txtfirstname: {
                        required: "Please Specify First Name.",
                    },

                    txtlastname: {
                        required: "Please Specify Last Name.",
                    },

                    txtpwd: {
                        required: "Please Specify Password.",
                    },

                    txtcpwd: {
                        required: "Please Specify Confirm Password.",
                    },
                    txtunm: {
                        required: "Please Specify User Name.",
                    },
                    ddlutype: {
                        required: "Please Select User Type"
                    },
                    txtcntno: {
                        required: "Please Specify Phone.",
                        phone: "Please provide a valid Phone."
                    },

                },


                invalidHandler: function (event, validator) { //display error alert on form submit   
                    $('.alert-danger', $('.login-form')).show();
                },

                highlight: function (element) {
                    var id_attr = "#" + $(element).attr("id") + "1";
                    $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
                    $(id_attr).removeClass('glyphicon-ok').addClass('glyphicon-remove');
                },
                unhighlight: function (element) {
                    var id_attr = "#" + $(element).attr("id") + "1";
                    $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
                    $(id_attr).removeClass('glyphicon-remove').addClass('glyphicon-ok');
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

</head>

<body style="background-color: #555">

    <div class="col-lg-10" style="padding-left: 10%">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle pull-right" data-toggle="collapse" data-target=".top-collapse">
                <i class="fa fa-bars"></i>
            </button>

            <div class="clearfix">
            </div>
        </div>

        <div class="portlet">
            <div class="portlet-heading dark">
                <div class="portlet-title" style="float: right; margin-top: 6px">
                    <h4>Registration </h4>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="portlet-body">


                <form id="validateform" class="form-horizontal" runat="server">
                    <br />
                    <center> 
                 <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label></center>
                    <asp:ScriptManager ID="scrip1" runat="server"></asp:ScriptManager>

                    <div class="form-horizontal">

                        <div class="form-group">
                            <label class="col-sm-4 control-label" for="utype">User Type:</label>
                            <div class="col-sm-4">
                                <div class="input-group clearfix">
                                    <asp:DropDownList ID="ddlusertype" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="None" ControlToValidate="ddlusertype" />
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="col-sm-4 control-label" for="name">First Name:</label>
                            <div class="col-sm-4">
                                <div class="clearfix">
                                    <asp:TextBox type="text" ID="txtfirstname" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req1" runat="server" Display="None" ControlToValidate="txtfirstname" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-4 control-label" for="name">Last Name:</label>
                            <div class="col-sm-4">
                                <div class="clearfix">
                                    <asp:TextBox type="text" ID="txtlastname" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="None" ControlToValidate="txtlastname" />
                                </div>
                            </div>
                        </div>

                        <hr class="separator" />

                        <div class="form-group">
                            <label class="col-sm-4 control-label">User Name:</label>
                            <div class="col-sm-4">
                                <div class="clearfix">
                                    <asp:TextBox type="text" ID="txtemailid" runat="server" CssClass="form-control EMAIL"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtemailid" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemailid" Display="None" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">Password:</label>
                            <div class="col-sm-4">
                                <div class="clearfix">
                                    <asp:TextBox type="text" ID="txtpassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtpassword" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">Confirm Password:</label>
                            <div class="col-sm-4">
                                <div class="clearfix">

                                    <asp:TextBox type="text" ID="txtcpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtcpassword" />
                                    <asp:CompareValidator ID="cmp1" runat="server" Display="None" ControlToValidate="txtcpassword" ControlToCompare="txtpassword" />
                                </div>
                            </div>
                        </div>
                        <hr class="separator" />


                        <div class="form-group">
                            <label class="col-sm-4 control-label">Gender:</label>
                            <div class="col-sm-4">
                                <div class="input-group clearfix">

                                    <asp:RadioButtonList ID="rbgender" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="rfvgender" runat="server" ControlToValidate="rbgender" Display="None" ErrorMessage="Select gender" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">Birth Date:</label>
                            <div class="col-sm-4">
                                <div class="clearfix">

                                    <asp:TextBox ID="txtbirthdate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvbirthdate" runat="server" ControlToValidate="txtbirthdate" Display="None" ErrorMessage="Select valid birthdate" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-4 control-label" for="Phone">Contact No:</label>
                            <div class="col-sm-4">
                                <div class="input-group clearfix">
                                    <span class="input-group-addon"><i class="fa fa-phone"></i></span>
                                    <asp:TextBox type="text" ID="txtmobileno" runat="server" CssClass="form-control Phone"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtmobileno" />
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="hf_id" runat="server" Value="0" />


                        <div class="form-actions">
                            <div class="form-group">
                                <div class="col-sm-offset-4 col-sm-9">
                                    <asp:LinkButton ID="btnsubmit" OnClick="btnsignup_Click" runat="server" Width="100px" type="button" CssClass="btn btn-primary btn-line" OnClientClick="return checkvalid();" Text="Register"></asp:LinkButton>
                                    &nbsp;&nbsp;
                                                    <asp:LinkButton ID="btncancel" runat="server" type="button" CssClass="btn btn-line btn-warning" CausesValidation="false" Text="Reset" Width="100px" OnClick="btncancel_Click"></asp:LinkButton>

                                </div>
                            </div>
                        </div>

                        <div class="footer-wrap">
                            <span class="pull-left">
                                <a href="WebLogin.aspx"><i class="fa fa-angle-double-left"></i>Sign In</a>
                            </span>


                            <div class="clearfix"></div>
                        </div>

                    </div>


                </form>

            </div>

            <!-- END YOUR CONTENT HERE -->


        </div>


    </div>
</body>
</html>
