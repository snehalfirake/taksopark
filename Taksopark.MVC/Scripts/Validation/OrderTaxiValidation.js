var orderTaxiValidation;

$(function () {
    orderTaxiValidation = new OrderTaxiValidation();
    orderTaxiValidation.initialize();
});

function OrderTaxiValidation() {
    var _this = this;

    _this.initialize = function () {

        $("#placeFromTextBoxId").focus(function () {
            if ($("#placeFromTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#placeFromTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#paceFromErrorSpanId").hide();
            _this.EnableSendMessageButton();
            _this.EnableShowTheWayButton();
        });

        $("#placeToTextBoxId").focus(function () {
            if ($("#placeToTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#placeToTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#paceToErrorSpanId").hide();
            _this.EnableSendMessageButton();
            _this.EnableShowTheWayButton();
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

        $("#showTheWayButtonId").click(function () {
            _this.PlaceFromTextBoxValidation();
            _this.PlaceToTextBoxValidation();
            if ($("#phoneTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#phoneTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#phoneErrorSpanId").hide();
        });
    };

    _this.PlaceFromTextBoxValidation = function () {
        var textBoxId = '#placeFromTextBoxId';
        var placeFromTextBoxValue = $(textBoxId).val();
        if (!(_this.PlaceFromOrPlaceToRegularExpression(placeFromTextBoxValue))) {
            if (textBoxId != 'undefined') {
                $("#paceFromErrorSpanId").show();
                $(textBoxId).removeClass("textBoxValidationClass").addClass("error-textBoxValidationClass");
                $('#paceFromErrorSpanId').replaceWith('<span id="paceFromErrorSpanId">' +
                    "Please enter a valid Place From" + '</span>');
            }
            _this.DisableSendMessageButton();
            _this.DisableShowTheWayButton();
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
        if (!(_this.PlaceFromOrPlaceToRegularExpression(placeToTextBoxValue))) {
            if (textBoxId != 'undefined') {
                $("#paceToErrorSpanId").show();
                $(textBoxId).removeClass("textBoxValidationClass").addClass("error-textBoxValidationClass");
                $('#paceToErrorSpanId').replaceWith('<span id="paceToErrorSpanId">' +
                    "Please enter a valid Place To" + '</span>');
            }
            _this.DisableSendMessageButton();
            _this.DisableShowTheWayButton();
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
        if (!(_this.PhoneRegularExpression(phoneTextBoxValue))) {
            if (textBoxId != 'undefined') {
                $("#phoneErrorSpanId").show();
                $(textBoxId).removeClass("textBoxValidationClass").addClass("error-textBoxValidationClass");
                $('#phoneErrorSpanId').replaceWith('<span id="phoneErrorSpanId">' +
                    "Please enter a valid Phone Number" + '</span>');
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

    _this.PlaceFromOrPlaceToRegularExpression = function (testString) {
        var exp = new RegExp("^[А-ЯЄІЇа-яєії]{3,30}[\ \]{0,1}[А-ЯЄІЇа-яєії]{0,30}[\ \]{0,1}[А-ЯЄІЇа-яєії]{0,30}[\ \]{0,1}[0-9]{0,4}[\ \]{0,1}[А-ЯЄІЇа-яєії]{0,1}$");
        return exp.test(testString);
    };

    _this.PhoneRegularExpression = function (testString) {
        var exp = new RegExp("^[(]{0,1}[0-9]{3}[)]{0,1}[-\ \.]{0,1}[0-9]{3}[-\ \.]{0,1}[0-9]{4}$");
        return exp.test(testString);
    };

    _this.DisableSendMessageButton = function () {
        document.getElementById("orderTaxiButtonId").disabled = true;
    };

    _this.EnableSendMessageButton = function () {
        document.getElementById("orderTaxiButtonId").disabled = false;
    };

    _this.DisableShowTheWayButton = function () {
        document.getElementById("showTheWayButtonId").disabled = true;
    };

    _this.EnableShowTheWayButton = function () {
        document.getElementById("showTheWayButtonId").disabled = false;
    };
};