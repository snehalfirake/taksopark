
$(document).ready(function () {
    $("#AnimalWeightId").css("visibility", "hidden");
    
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

    $("input[@name='service'][value='With animals']").change(function () {
            $("#AnimalWeightId").css("visibility", "visible");
    });
    $("input[@name='service'][value='Tracking']").change(function () {
            $("#AnimalWeightId").css("visibility", "hidden");
    });
    $("input[@name='service'][value='Haulage']").change(function () {
            $("#AnimalWeightId").css("visibility", "hidden");
    });
});
