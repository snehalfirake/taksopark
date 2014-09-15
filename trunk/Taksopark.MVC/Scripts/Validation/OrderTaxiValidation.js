var loginValidation;

$(function () {
    loginValidation = new LoginValidation();
    loginValidation.initialize();
});

function LoginValidation() {
    var _this = this;

    _this.initialize = function () {

        $("#placeFromTextBoxId").focus(function () {
            if ($("#placeFromTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#placeFromTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#paceFromErrorSpanId").hide();
            _this.EnableSendMessageButton();
        });

        $("#placeToTextBoxId").focus(function () {
            if ($("#placeToTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#placeToTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#paceToErrorSpanId").hide();
            _this.EnableSendMessageButton();
        });

        $("#phoneTextBoxId").focus(function () {
            if ($("#phoneTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#phoneTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#phoneErrorSpanId").hide();
            _this.EnableSendMessageButton();
        });


        $("#placeFromTextBoxId").keypress(function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode == '13') {
                e.preventDefault();
                $("#orderTaxiButtonId").focus();
                if ($('#orderTaxiButtonId').is(":enabled"))
                    $("#orderTaxiButtonId").click();
            }
        });

        $("#placeToTextBoxId").keypress(function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode == '13') {
                e.preventDefault();
                $("#orderTaxiButtonId").focus();
                if ($('#orderTaxiButtonId').is(":enabled"))
                    $("#orderTaxiButtonId").click();
            }
        });

        $("#phoneTextBoxId").keypress(function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode == '13') {
                e.preventDefault();
                $("#orderTaxiButtonId").focus();
                if ($('#orderTaxiButtonId').is(":enabled"))
                    $("#orderTaxiButtonId").click();
            }
        });

        $("#orderTaxiButtonId").click(function () {
            _this.PlaceFromTextBoxValidation();
            _this.PlaceToTextBoxValidation();
            _this.PhoneTextBoxValidation();
        });
    };

    _this.PlaceFromTextBoxValidation = function () {
        var textBoxId = '#placeFromTextBoxId';
        var placeFromTextBoxValue = $(textBoxId).val();
        if (placeFromTextBoxValue == "") {
            if (textBoxId != 'undefined') {
                $("#paceFromErrorSpanId").show();
                $(textBoxId).removeClass("textBoxValidationClass").addClass("error-textBoxValidationClass");
                $('#paceFromErrorSpanId').replaceWith('<span id="paceFromErrorSpanId">' +
                    "Please enter a valid Place From" + '</span>');
            }
            _this.DisableSendMessageButton();
            return false;
        }
        else {
            if ($(textBoxId).hasClass("error-textBoxValidationClass")) {
                $(textBoxId).removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#paceFromErrorSpanId").hide();
            return true;
        }
    };

    _this.PlaceToTextBoxValidation = function () {
        var textBoxId = '#placeToTextBoxId';
        var placeToTextBoxValue = $(textBoxId).val();
        if (placeToTextBoxValue == "") {
            if (textBoxId != 'undefined') {
                $("#paceToErrorSpanId").show();
                $(textBoxId).removeClass("textBoxValidationClass").addClass("error-textBoxValidationClass");
                $('#paceToErrorSpanId').replaceWith('<span id="paceToErrorSpanId">' +
                    "Please enter a valid Place To" + '</span>');
            }
            _this.DisableSendMessageButton();
            return false;
        }
        else {
            if ($(textBoxId).hasClass("error-textBoxValidationClass")) {
                $(textBoxId).removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#paceToErrorSpanId").hide();
            return true;
        }
    };

    _this.PhoneTextBoxValidation = function () {
        var textBoxId = '#phoneTextBoxId';
        var phoneTextBoxValue = $(textBoxId).val();
        if (phoneTextBoxValue == "") {
            if (textBoxId != 'undefined') {
                $("#phoneErrorSpanId").show();
                $(textBoxId).removeClass("textBoxValidationClass").addClass("error-textBoxValidationClass");
                $('#phoneErrorSpanId').replaceWith('<span id="phoneErrorSpanId">' +
                    "Please enter a valid Phone" + '</span>');
            }
            _this.DisableSendMessageButton();
            return false;
        }
        else {
            if ($(textBoxId).hasClass("error-textBoxValidationClass")) {
                $(textBoxId).removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#phoneErrorSpanId").hide();
            return true;
        }
    };

    //_this.NameRegularExpression = function (testString) {
    //    var exp = new RegExp("^([A-Za-zА-ЯЄІа-яєі0-9 ]){2,50}$");
    //    return exp.test(testString);
    //};

    

    _this.DisableSendMessageButton = function () {
        document.getElementById("orderTaxiButtonId").disabled = true;
    };

    _this.EnableSendMessageButton = function () {
        document.getElementById("orderTaxiButtonId").disabled = false;
    };
};