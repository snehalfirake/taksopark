var orderTaxi;

$(function () {
    orderTaxi = new OrderTaxi();
    orderTaxi.initialize();
});
function OrderTaxi() {
    var _this = this;
    var directionDisplay;
    var map;

    _this.initialize = function () {

        directionsDisplay = new google.maps.DirectionsRenderer();
        var lviv = new google.maps.LatLng(49.8382112, 24.0294017);
        var myOptions = {
            zoom: 12,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            center: lviv
        };
        map = new google.maps.Map(document.getElementById("TaxiMap1"), myOptions);
        directionsDisplay.setMap(map);

        $("#showTheWayButtonId").click(function () {
            _this.CalcRoute();
        });
    };

    var directionsService = new google.maps.DirectionsService();

    _this.CalcRoute = function () {

        var distanceInput = document.getElementById("distance");
        var priceInput = document.getElementById("price");
        var placeFrom = $("#placeFromTextBoxId").val();
        var placeTo = $("#placeToTextBoxId").val();
        var start = "Львів, " + placeFrom;
        var end = "Львів, " + placeTo;

        if ((orderTaxiValidation.PlaceFromOrPlaceToRegularExpression(placeFrom)) &&
            (orderTaxiValidation.PlaceFromOrPlaceToRegularExpression(placeTo))) {
            var request = {
                origin: start,
                destination: end,
                travelMode: google.maps.DirectionsTravelMode.DRIVING
            };
        }
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
                distanceInput.value = response.routes[0].legs[0].distance.value / 1000;
                if (parseFloat(distanceInput.value) < 2) {
                    priceInput.value = 18;
                } else if (parseInt(distanceInput.value) > 2) {
                    priceInput.value = parseInt((distanceInput.value * 3) + 15);
                }
            }
        });
    };
};