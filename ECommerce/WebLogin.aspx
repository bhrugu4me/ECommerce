<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="ECommerce.WebLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Sign In</title>
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
    <!-- Full screen slider -->

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

            //documentation : http://docs.jquery.com/Plugins/Validation/validate		
            $('#validateform').validate({
                errorElement: 'div',
                errorClass: 'help-block',
                focusInvalid: false,
                rules: {
                    txtpwd: {
                        required: true
                    },
                    txtunm: {
                        required: true
                    }
                },

                messages: {
                    txtpwd: {
                        required: "Please Specify Password.",
                    },

                    txtunm: {
                        required: "Please Specify User Name.",
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


    <div class="login-container">


        <div class="portlet">

            <div class="portlet-heading dark">
                <div class="portlet-title" style="float: right; margin-top: 6px">
                    <h4>Sign In </h4>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="portlet-body">

                <form class="form-horizontal" id="validateform" runat="server">
                    <center>  <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label></center>
                    <asp:ScriptManager ID="scrip1" runat="server"></asp:ScriptManager>

                    <div class="form-horizontal">


                        <div class="form-group">
                            <label class="col-sm-4 control-label">UserName/Email:</label>

                            <div class="col-md-6">
                                <div class="clearfix">
                                    <asp:TextBox type="text" ID="txtunm" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtunm" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">Password:</label>
                            <div class="col-md-6">
                                <div class="clearfix">
                                    <asp:TextBox type="text" ID="txtpwd" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtpwd" />
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-9">
                                <asp:LinkButton ID="btnLogin" runat="server" Width="100px" type="button" CssClass="btn btn-primary btn-line" OnClientClick="return checkvalid();" Text="Login<i class='fa fa-key icon-on-right'></i>" OnClick="btnlogin_Click"></asp:LinkButton>


                            </div>
                        </div>
                        <div class="footer-wrap">
                            <%--<span class="pull-left">
								<a href="#" ><i class="fa fa-angle-double-left"></i> Forgot password?</a>
							</span>
                            --%>
                            <span class="pull-right">
                                <a href="WebSignup.aspx">Register here <i class="fa fa-angle-double-right"></i></a>
                            </span>

                            <div class="clearfix"></div>
                        </div>

                    </div>


                </form>
            </div>
        </div>

    </div>
    <!-- END LOGIN BOX -->

    <!-- BEGIN FORGOT BOX -->

    <!-- END FORGOT BOX -->



</body>
</html>


