var stockholm = new google.maps.LatLng(49.8382112, 24.0294017);
var marker;
var map1;
var myCity;
geocoder = new google.maps.Geocoder();


function initialize() {
    var mapOptions = {
        zoom: 12,
        center: stockholm
    };
    var info = new google.maps.InfoWindow({ content: "" });


    var app;
    map1 = new google.maps.Map(document.getElementById('TaxiMap1'),
            mapOptions);
    //Populate arrayOfValues 
    $.ajax({
        url: 'tolist',
        dataType: 'json',
        success: function (data) {
            for (var i = 0; i < data.length ; i++) {
                app = new google.maps.Marker({
                    position: new google.maps.LatLng(data[i].Latitude, data[i].Longitude),
                    map: map1,
                    title: data[i].Name
                });
                google.maps.event.addListener(app, 'click', function () {
                    alert("Інформація про таксиста")
                });
            }
        }
    });
}


google.maps.event.addDomListener(window, 'load', initialize);


function codeAddress() {



    marker = new google.maps.Marker({ // маркер
        visible: false,
        map: map1,
        animation: google.maps.Animation.BOUNCE,
        icon: {
            path: google.maps.SymbolPath.BACKWARD_CLOSED_ARROW,
            strokeColor: "Green",
            scale: 7,
            strokeWeight: 3
        },

    })
    var address = document.getElementById('adr').value;
    geocoder.geocode({ 'address': 'Львів,' + address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {



            map1.setCenter(results[0].geometry.location);
            marker.setOptions({
                visible: true,
                title: address,
                position: results[0].geometry.location
            });


            myCity = new google.maps.Circle({

                center: results[0].geometry.location,
                radius: 1000,
                strokeColor: "#0000FF",
                strokeOpacity: 0.8,
                strokeWeight: 0.6,
                fillColor: "#0000FF",
                fillOpacity: 0.2
            });
            myCity.setMap(map1);
        } else {
            alert('Не правельно введені дані');
        }
    });
}