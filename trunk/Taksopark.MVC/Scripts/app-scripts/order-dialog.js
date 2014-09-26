var query = $(function () {
    $("#order-dialog").dialog({
        width: 590,
        resizable: false,
        autoOpen: false,
        position: ["center", "center"],
        buttons: [
        {
            text: "Order",
            height: 34,
            width: 74,
            click: function () {
                var txtplaceFrom = $("#placeFromTextBoxId").val();
                var txtplaceTo = $("#placeToTextBoxId").val();
                var txtphone = $("#phoneTextBoxId").val();
                $.ajax({
                    url: "/Home/OrderTaxi",
                    type: "POST",
                    cache: false,
                    datatype: "json",
                    data: {
                        from: txtplaceFrom,
                        to: txtplaceTo,
                        phone: txtphone
                    },
                    success: function (data) {
                        if (data.RequestId) {
                            $('.ui-dialog-buttonpane').find('button:first').css('visibility', 'hidden');
                            $(":button:contains('Reject')").text('Ok');
                            $(".message").text("Your order has been successfully completed!").css("color", "green");
                            $("#placeFromTextBoxId").val("");
                            $("#placeToTextBoxId").val("");
                            $("#phoneTextBoxId").val("");
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
                    window.location.reload(true);
                }
            }]
    });

    $("#orderTaxiButtonId").on("click", function () {

        var placeFrom = $("#placeFromTextBoxId").val();
        var placeTo = $("#placeToTextBoxId").val();
        var phone = $("#phoneTextBoxId").val();

        if ((!($("#placeFromTextBoxId").val() == "") && (!$("#placeToTextBoxId").val() == "") && (!$("#phoneTextBoxId").val() == ""))) {
            $("#order-dialog").dialog("open");

            $("#dialogFromId").val(placeFrom);
            $("#dialogToId").val(placeTo);
            $("#dialogPhoneId").val(phone);
        } else {
            $(this).dialog("close");
            alert("Type data!!!");
        }
    });
});