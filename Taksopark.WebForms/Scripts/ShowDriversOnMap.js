window.onload = function () {
    //console.log('window.onload');
    showFreeTaxiDrivers();
}

function load() {
    //console.log('load()')
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(showFreeTaxiDrivers);
}


function showFreeTaxiDrivers() {
    var centerPosition = document.getElementById("Content_driversDropDownList");

    var lat;
    var lng;
    for (var i = 0; i < markers.length; i++) {
        //console.log(markers.length);
        if (centerPosition.value == markers[i].id) {
            lat = markers[i].lat;
            lng = markers[i].lng;
            //console.log(lat);
            //console.log(lng);
            break;
        }
    }
    if (typeof (lat) != undefined && typeof (lng) != undefined) {
        //console.log('not undefined');
        var mapOptions = {
            center: new google.maps.LatLng(lat, lng),
            zoom: 13,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        var map = new google.maps.Map(document.getElementById("driverMap"), mapOptions);
        for (i = 0; i < markers.length; i++) {
            var data = markers[i]
            if (data.lat != lat && data.lng != lng) {
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title
                });
            } else {
                var image = 'http://s17.postimg.org/qriecy497/spotlight_poi22.png';
                var myLatLng = new google.maps.LatLng(lat, lng);
                var beachMarker = new google.maps.Marker({
                    position: myLatLng,
                    map: map,
                    icon: image,
                    title: data.title
                });
            }

            //(function (marker, data) {
            //    google.maps.event.addListener(marker, "click", function (e) {
            //        infoWindow.setContent(data.description);
            //        infoWindow.open(map, marker);
            //    });
            //})(marker, data);
        }      
    } else {
        console.log('undefined');
        var infoWindowEmptyMap = new google.maps.infoWindow();
        var lviv = new google.maps.LatLng(49.8382112, 24.0294017);
        var myOptions = {
            zoom: 12,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            center: lviv
        };
        map = new google.maps.Map(document.getElementById("driverMap"), myOptions);
    }
}