var loginValidation;

$(function () {
    loginValidation = new LoginValidation();
    loginValidation.initialize();
});

function LoginValidation() {
    var _this = this;

    _this.initialize = function () {

        $("#loginTextBoxId").focus(function () {
            if ($("#loginTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#loginTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#loginValidationErrorSpanId").hide();
            _this.EnableSendMessageButton();
        });

        $("#passwordTextBoxId").focus(function () {
            if ($("#passwordTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#passwordTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#passwordValidationErrorSpanId").hide();
            _this.EnableSendMessageButton();
        });

        $("#loginTextBoxId").keypress(function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode == '13') {
                e.preventDefault();
                $("#loginButtonId").focus();
                if ($('#loginButtonId').is(":enabled"))
                    $("#loginButtonId").click();
            }
        });

        $("#passwordTextBoxId").keypress(function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode == '13') {
                e.preventDefault();
                $("#loginButtonId").focus();
                if ($('#loginButtonId').is(":enabled"))
                    $("#loginButtonId").click();
            }
        });

        $("#loginButtonId").click(function () {
            _this.LoginTextBoxValidation();
            _this.PasswordTextBoxValidation();
        });

    };

    _this.LoginTextBoxValidation = function () {
        var textBoxId = '#loginTextBoxId';
        var loginTextBoxValue = $(textBoxId).val();
        if (loginTextBoxValue == "") {
            if (textBoxId != 'undefined') {
                $("#loginValidationErrorSpanId").show();
                $(textBoxId).removeClass("textBoxValidationClass").addClass("error-textBoxValidationClass");
                $('#loginValidationErrorSpanId').replaceWith('<span id="loginValidationErrorSpanId">' +
                    "Please enter a valid Login" + '</span>');
            }
            _this.DisableSendMessageButton();
            return false;
        }
        else {
            if ($(textBoxId).hasClass("error-textBoxValidationClass")) {
                $(textBoxId).removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#loginValidationErrorSpanId").hide();
            return true;
        }
    };

    _this.PasswordTextBoxValidation = function () {
        var textBoxId = '#passwordTextBoxId';
        var passwordTextBoxValue = $(textBoxId).val();
        if (passwordTextBoxValue == "") {
            if (textBoxId != 'undefined') {
                $("#passwordValidationErrorSpanId").show();
                $(textBoxId).removeClass("textBoxValidationClass").addClass("error-textBoxValidationClass");
                $('#passwordValidationErrorSpanId').replaceWith('<span id="passwordValidationErrorSpanId">' +
                    "Please enter a valid Password" + '</span>');
            }
            _this.DisableSendMessageButton();
            return false;
        }
        else {
            if ($(textBoxId).hasClass("error-textBoxValidationClass")) {
                $(textBoxId).removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#passwordValidationErrorSpanId").hide();
            return true;
        }
    };


    _this.DisableSendMessageButton = function () {
        document.getElementById("loginButtonId").disabled = true;
    };

    _this.EnableSendMessageButton = function () {
        document.getElementById("loginButtonId").disabled = false;
    };
};