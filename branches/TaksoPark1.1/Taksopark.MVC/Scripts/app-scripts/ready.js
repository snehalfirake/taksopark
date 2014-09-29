var flag = false;

$(document).ready(function () {
    $('#ExtendedFormOpenButtonId').click(function () {
        var $extendedOrderPanel = $("#ExtendedOrderFormId");
        if ($extendedOrderPanel.is(":visible")) {
            $("#ExtendedOrderFormId").slideUp(400);
            $("#ExtendedFormOpenButtonId").text("Extended \u25BC");
            $("#date-time").val("");
            $('input:radio[name=service]').prop("checked", false);
        } else {
            $("#ExtendedOrderFormId").slideDown(400);
            $("#ExtendedFormOpenButtonId").text("Extended \u25B2");
        }
    });
    $("#dtBox").DateTimePicker();
});
