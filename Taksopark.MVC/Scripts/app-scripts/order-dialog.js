var query = $(function () {
    $("#dialog").dialog({
        autoOpen: false,
        modal: true,
        resizable: false,
        buttons: [{
            text: "Order",
            click: function() {
                $.ajax({
                    url: "/Home/OrderTaxi",
                    type: 'POST',
                    dataType: 'json',
                    cache: false,
                    success: function() {
                        alert("Thank you for using our ");
                    },
                    error: function() {
                        alert("Somthing wrong!!! Please try again");
                    }
                });
                $(this).dialog("close");
            },
},
            {
                text: "Cancel",
                click: function() { 
                    $(this).dialog("close"); 
                }
            }]
    });

    $("#orderTaxiButtonId").on("click", function () {
        if (!(($("#placeFromTextBoxId").val() == "") && ($("#placeToTextBoxId").val() == "") && ($("#phoneTextBoxId").val() == ""))) {
            $("#dialog").dialog("open");
        } else {

        }
    });
});