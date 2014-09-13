var сontactsValidation;

$(function () {
    сontactsValidation = new ContactsValidation();
    сontactsValidation.initialize();
});

function ContactsValidation() {
    var _this = this;

    _this.initialize = function () {

        $("#nameTextBoxId").focus(function () {
            if ($("#nameTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#nameTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#nameErrorValidationSpanId").hide();
            _this.EnableSendMessageButton();
        });

        $("#emailTextBoxId").focus(function () {
            if ($("#emailTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#emailTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#emailErrorValidationSpanId").hide();
            _this.EnableSendMessageButton();
        });

        $("#messageTextAreaId").focus(function () {
            if ($("#messageTextAreaId").hasClass("error-textAreaValidationClass")) {
                $("#messageTextAreaId").removeClass("error-textAreaValidationClass").addClass("textAreaValidationClass");
            }
            $("#messageErrorValidationSpanId").hide();
            _this.EnableSendMessageButton();
        });

        $("#sendMessageButtonId").click(function () {
            _this.NameTextBoxValidation();
            _this.EmailTextBoxValidation();
            _this.MessageTextAreaValidation();
        });

        $("#clearContentButtonId").click(function () {
            if ($("#nameTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#nameTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            if ($("#emailTextBoxId").hasClass("error-textBoxValidationClass")) {
                $("#emailTextBoxId").removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            if ($("#messageTextAreaId").hasClass("error-textAreaValidationClass")) {
                $("#messageTextAreaId").removeClass("error-textAreaValidationClass").addClass("textAreaValidationClass");
            }
            $("#nameErrorValidationSpanId").hide();
            $("#emailErrorValidationSpanId").hide();
            $("#messageErrorValidationSpanId").hide();
            _this.EnableSendMessageButton();
        });

    };

    _this.NameTextBoxValidation = function () {
        var textBoxId = '#nameTextBoxId';
        var nameTextBoxValue = $(textBoxId).val();
        if (!(_this.NameRegularExpression(nameTextBoxValue))) {
            if (textBoxId != 'undefined') {
                $("#nameErrorValidationSpanId").show();
                $(textBoxId).removeClass("textBoxValidationClass").addClass("error-textBoxValidationClass");
                $('#nameErrorValidationSpanId').replaceWith('<span id="nameErrorValidationSpanId">' +
                    "Please enter a valid Name" + '</span>');
            }
            _this.DisableSendMessageButton();
            return false;
        }
        else {
            if ($(textBoxId).hasClass("error-textBoxValidationClass")) {
                $(textBoxId).removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#nameErrorValidationSpanId").hide();
            return true;
        }
    };
    
    _this.EmailTextBoxValidation = function () {
        var textBoxId = '#emailTextBoxId';
        var emailTextBoxValue = $(textBoxId).val();
        if (emailTextBoxValue == "" || !(_this.EmailRegularExpression(emailTextBoxValue))) {
            if (textBoxId != 'undefined') {
                $("#emailErrorValidationSpanId").show();
                $(textBoxId).removeClass("textBoxValidationClass").addClass("error-textBoxValidationClass");
                $('#emailErrorValidationSpanId').replaceWith('<span id="emailErrorValidationSpanId">' +
                    "Please provide a valid email address" + '</span>');
            }
            _this.DisableSendMessageButton();
            return false;
        }
        else {
            if ($(textBoxId).hasClass("error-textBoxValidationClass")) {
                $(textBoxId).removeClass("error-textBoxValidationClass").addClass("textBoxValidationClass");
            }
            $("#emailErrorValidationSpanId").hide();
            return true;
        }
    };

    _this.MessageTextAreaValidation = function () {
        var textBoxId = '#messageTextAreaId';
        var messageTextAreaValue = $(textBoxId).val();
        if (messageTextAreaValue == "" || !(_this.MessageRegularExpression(messageTextAreaValue))) {
            if (textBoxId != 'undefined') {
                $("#messageErrorValidationSpanId").show();
                $(textBoxId).removeClass("textAreaValidationClass").addClass("error-textAreaValidationClass");
                $('#messageErrorValidationSpanId').replaceWith('<span id="messageErrorValidationSpanId">' +
                    "Message field can't be empty, please fill it." + '</span>');
            }
            _this.DisableSendMessageButton();
            return false;
        }
        else {
            if ($(textBoxId).hasClass("error-textAreaValidationClass")) {
                $(textBoxId).removeClass("error-textAreaValidationClass").addClass("textAreaValidationClass");
            }
            $("#messageErrorValidationSpanId").hide();
            return true;
        }
    };

    _this.NameRegularExpression = function (testString) {
        var exp = new RegExp("^([A-Za-zА-ЯЄІа-яєі0-9 ]){2,50}$");
        return exp.test(testString);
    };

    _this.EmailRegularExpression = function (testString) {
        var exp = new RegExp("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}$");
        return exp.test(testString);
    };

    _this.MessageRegularExpression = function (testString) {
        var exp = new RegExp("^[A-Za-zА-ЯЄІа-яєі0-9!@#$%^&*()_+{},.<>:;?= ]{2,3500}$");
        return exp.test(testString);
    };

    _this.DisableSendMessageButton = function () {
        document.getElementById("sendMessageButtonId").disabled = true;
    };

    _this.EnableSendMessageButton = function () {
        document.getElementById("sendMessageButtonId").disabled = false;
    };
};