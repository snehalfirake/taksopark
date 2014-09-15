var directionDisplay;
var map;

function initialize() {
    directionsDisplay = new google.maps.DirectionsRenderer();
    var lviv = new google.maps.LatLng(49.8382112, 24.0294017);
    var myOptions = {
        zoom: 12,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        center: lviv
    };

    map = new google.maps.Map(document.getElementById("TaxiMap1"), myOptions);
    directionsDisplay.setMap(map);
}
var directionsService = new google.maps.DirectionsService();

function calcRoute() {
    var distanceInput = document.getElementById("distance");

    var start = "Львів, " + document.getElementById("adr1").value;
    var end = "Львів, " + document.getElementById("adr2").value;
    var request = {
        origin: start,
        destination: end,
        travelMode: google.maps.DirectionsTravelMode.DRIVING
    };
    directionsService.route(request, function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            directionsDisplay.setDirections(response);
            distanceInput.value = response.routes[0].legs[0].distance.value / 1000;
        }
    });
}

$(function () {
    initialize();
});