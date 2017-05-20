$(document).ready(function() {

    jQuery.validator.addMethod("password", function(value, element) {
        var result = this.optional(element) || value.length >= 6 && /\d/.test(value) && /[a-z]/i.test(value);
        if (!result) {
            element.value = "";
            var validator = this;
            setTimeout(function() {
                validator.blockFocusCleanup = true;
                element.focus();
                validator.blockFocusCleanup = false;
            }, 1);
        }
        return result;
    }, "Your password must be at least 6 characters long and contain at least one number and one special character.");

    // a custom method making the default value for companyurl ("http://") invalid, without displaying the "invalid url" message
    jQuery.validator.addMethod("defaultInvalid", function(value, element) {
        return value != element.defaultValue;
    }, "");

    $.validator.addMethod("DOB", function(value, element) {

        var day = $("#ddlbdtdd").val();
        var month = $("#ddlbdtmm").val();
        var year = $("#txtbdtyy").val();
        var age = 27;

        var mydate = new Date();
        mydate.setFullYear(year, month - 1, day);

        var currdate = new Date();
        currdate.setFullYear(currdate.getFullYear() - age);

        return currdate > mydate;

    }, "You must be at least 27 years of age.");

//    jQuery.validator.addMethod("phoneUS", function(phone_number, element) {
//        phone_number = phone_number.replace(/\s+/g, '');
//        phone_number = phone_number.replace('/', '');
//        return this.optional(element) || phone_number.length > 9 &&
//                phone_number.match(/^(1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$/) &&
//                !phone_number.match(/^(?:1-?)?(\d)\1\1-?\1\1\1-?\1\1\1\1$/);
//    }, "Please specify a valid phone number.");

  

    jQuery.validator.addMethod("USP", function(phone_number, element) {
        phone_number = phone_number.replace('-', '');
         return this.optional(element) || phone_number.length > 9 &&
                phone_number.match(/^(1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$/) &&
               !phone_number.match(/^(?:1-?)?(\d)\1\1-?\1\1\1-?\1\1\1\1$/);
       
    }, "Please specify a valid phone number.");  
    
//       jQuery.validator.addMethod("SSNV", function(value, element) {
//        //value = value.replace('-', '');
//         var re = /^([0-6]\d{2}|7[0-6]\d|77[0-2])([ \-]?)(\d{2})\2(\d{4})$/;
//         if (!re.test(value)) { return false; }
//        var temp = value;
//        if (value.indexOf("-") != -1) { temp = (value.split("-")).join(""); }
//        if (value.indexOf(" ") != -1) { temp = (value.split(" ")).join(""); }
//         if (temp.substring(0, 3) == "000") { return false; }
//         if (temp.substring(3, 5) == "00") { return false; }
//         if (temp.substring(5, 9) == "0000") { return false; } 
//        
//    }, "Please specify a valid SSN.");  
    
    jQuery.validator.addMethod("ValidationRequired", function(value, element) {
        //        if ($("#bill_to_co").is(":checked"))
        //            return $(element).parents(".subTable").length;
        return !this.optional(element);
    }, "");


    $.validator.addMethod("acclen", function(value, element) {
        // check parameter "#inputUrl:filled" (see validate(...) method below)
        if (value.length < 21) {
            return true;
        }

    }, "Please enter a valid account number");



    jQuery.validator.messages.required = "";
    $("form").validate({
        onkeyup: false,
        //        submitHandler: function() {
        //            alert("submit! use link below to go to the other step");
        //            return true;
        //        },
        messages: {
            password2: {
                required: " ",
                equalTo: "Please enter the same password as above"
            },
            email: {
                required: " ",
                email: "Please enter a valid email address, example: you@yourdomain.com",
                remote: jQuery.validator.format("{0} is already taken, please enter a different address.")
            }
        }
        //debug: true
    });

    $(".resize").vjustify();
    $("div.buttonSubmit").hoverClass("buttonSubmitHover");

    if ($.browser.safari) {
        $("body").addClass("safari");
    }

    $("input.phone").mask("999-999-9999");
    $("input.zipcode").mask("999999");
    $("input.extcode").mask("99999");
    $("input.ssn").mask("999-99-9999");
    $("input.bdt").mask("99");
    $("input.year").mask("9999");
    $("input.aba").mask("999999999");
    $("input.drv").mask("9999-99-9999");
    $("input.dbtcrdno").mask("9999999999999999");
    $("input.accno").mask("99999999999999999999");

    var creditcard = $("#creditcard").mask("9999 9999 9999 9999");

    $("#cc_type").change(
    function() {
        switch ($(this).val()) {
            case 'amex':
                creditcard.unmask().mask("9999 999999 99999");
                break;
            default:
                creditcard.unmask().mask("9999 9999 9999 9999");
                break;
        }
    }
  );

});

$.fn.vjustify = function() {
    var maxHeight=0;
    $(".resize").css("height","auto");
    this.each(function(){
        if (this.offsetHeight > maxHeight) {
          maxHeight = this.offsetHeight;
        }
    });
    this.each(function(){
        $(this).height(maxHeight);
        if (this.offsetHeight > maxHeight) {
            $(this).height((maxHeight-(this.offsetHeight-maxHeight)));
        }
    });
};

$.fn.hoverClass = function(classname) {
	return this.hover(function() {
		$(this).addClass(classname);
	}, function() {
		$(this).removeClass(classname);
	});
};