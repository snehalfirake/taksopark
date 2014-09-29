$("#ajaxform").ajaxform(function (e) {
    var postData = $(this).serializeArray();
    var formURL = "/Home/OrderTaxi";
    $.ajax(
    {
        url: formURL,
        type: "POST",
        data: postData,
        success: function () {
            //data: return data from server
        },
        error: function () {
            alert("Error!!!"); //if fails      
        }
    });
    e.preventDefault(); //STOP default action
    e.unbind(); //unbind. to stop multiple form submit.
});

