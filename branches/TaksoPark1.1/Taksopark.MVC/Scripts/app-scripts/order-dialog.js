var query = $(function () {
    $("#order-dialog").dialog({
        width: 590,
        resizable: false,
        autoOpen: false,
        position: ["top", "center"],
        buttons: [
        {
            text: "Order",
            height: 34,
            width: 74,
            click: function () {
                var txtplaceFrom = $("#placeFromTextBoxId").val();
                var txtplaceTo = $("#placeToTextBoxId").val();
                var txtphone = $("#phoneTextBoxId").val();
                var txtdate = $("#date-time").val();
                var checked_radio = $('input:radio[name=service]:checked').val();
                $.ajax({
                    url: "/Home/OrderTaxi",
                    type: "POST",
                    cache: false,
                    datatype: "json",
                    data: {
                        from: txtplaceFrom,
                        to: txtplaceTo,
                        phone: txtphone,
                        date: txtdate,
                        service: checked_radio
                    },
                    success: function (data) {
                        if (data.RequestId) {
                            $('.ui-dialog-buttonpane').find('button:first').css('visibility', 'hidden');
                            $(":button:contains('Reject')").text('Ok');
                            $(".message").text("Your order has been successfully submited!").css("color", "green");
                            $("#placeFromTextBoxId").val("");
                            $("#placeToTextBoxId").val("");
                            $("#phoneTextBoxId").val("");
                            $("#date-time").val("");
                            $('input:radio[name=service]').prop("checked", false);
                            $("#ExtendedOrderFormId").slideUp(400);
                            $("#ExtendedFormOpenButtonId").text("Extended \u25BC");
                        } else {
                            $('.ui-dialog-buttonpane').find('button:first').css('visibility', 'hidden');
                            $(":button:contains('Reject')").text('Close');
                            $("#order-dialog").html("<span style='color:orange;'>Validation error! One or more fields are filled incorrectly </span>");
                        }
                    },
                    error: function () {
                        $('.ui-dialog-buttonpane').find('button:first').css('visibility', 'hidden');
                        $("#order-dialog").html("<span style='color:red;'>Something wrong! Please try again</span>");
                        $(":button:contains('Reject')").text('Close');
                    }

                });
            },
        },
            {
                text: "Reject",
                height: 34,
                width: 74,
                click: function () {
                    $(this).dialog("close");
                    
                }
            }]
    });

    $("#orderTaxiButtonId").on("click", function () {
        var placeFrom = $("#placeFromTextBoxId").val();
        var placeTo = $("#placeToTextBoxId").val();
        var phone = $("#phoneTextBoxId").val();
        var time = $("#date-time").val();
        var serviceVal= $('input:radio[name=service]:checked').val();

        if ((!($("#placeFromTextBoxId").val() == "") && (!$("#placeToTextBoxId").val() == "") && (!$("#phoneTextBoxId").val() == ""))) {
            $("#order-dialog").dialog("open");
            if ((time == "") && (serviceVal == undefined)) {
                $("#AdditionalOrderId").css("display", "none");
                $("#line").css("display", "none");
            } else {
                $("#AdditionalOrderId").css("display", "inline");
                $("#line").css("display", "block");
            }
            $(".message").html("<span class='color1'>Do</span> <span style='color: black;'>you want to submit the order?</span>");
            $('.ui-dialog-buttonpane').find('button:first').css('visibility', 'visible');
            $(":button:contains('Ok')").text('Reject');
            $("#cover").toggleClass("cover");
            $("#order-dialog").css({ 'z-index': 20 });
            $("#cover").css({ 'z-index': 40 });
            $("#dialogFromId").val(placeFrom);
            $("#dialogToId").val(placeTo);
            $("#dialogPhoneId").val(phone);
            if (time != "") {
                $("#dialogForwardTimeId").val(time);
            } else {
                $("#dialogForwardTimeId").val("-||-");
            }
            if (serviceVal != undefined) {
                $("#dialogServiceId").val(serviceVal);
            } else {
                $("#dialogServiceId").val("-||-");
            }


        } else {
            $(this).dialog("close");
        }
    });
});