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
        console.log("mapScript.js-initialize");
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
            _this.calcRoute({
                success: function (data) {
                    _this.updateEstimatedCost(estimatedDistance);
                }
            });
        });
    };

    _this.updateEstimatedCost = function (estimatedDistance) {
        $.ajax({
            url: "/Home/CalcEstimatedCost",
            type: "POST",
            cache: false,
            datatype: "json",
            data: {
                distance: Math.round(estimatedDistance),
                isTracking: $("#TrackingRadioId").is(':checked') ? true : false,
                animalWeight: $("#AnimalWeightId").val(),
                isHaulage: $("#HaulageRadioId").is(':checked') ? true : false
            },
            success: function (data) {
                $("#price").text(data.EstimatedCost.toFixed(2));
                $("#dialogCostId").val(data.EstimatedCost.toFixed(2));
            },
            error: function () {
                alert("error");
            }
        });
    };
   
    $("#placeFromTextBoxId, #placeToTextBoxId, #AnimalWeightId, #HaulageRadioId, #TrackingRadioId").change(function () {
        _this.calcRoute({
            success: function (data) {
                _this.updateEstimatedCost(data.estimatedDistance);
            }
        });
    });

    //$("#placeToTextBoxId").change(function() {
    //   _this.calcRoute();
    //});

   
    var directionsService = new google.maps.DirectionsService();

    _this.calcRoute = function (settings) {
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
                if (typeof (settings.success) === 'function') {
                    var dist = parseFloat(response.routes[0].legs[0].distance.value / 1000);
                    console.log("calcRoute() dist = " + dist);
                    $("#distance").text(dist);
                    settings.success({
                        estimatedDistance: dist
                    });
                }
                
            }
        });
    };
};