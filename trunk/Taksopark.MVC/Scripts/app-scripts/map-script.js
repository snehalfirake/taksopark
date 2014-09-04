//var map = null;

//function GetMap() {
//    map = new VEMap('myMap');
//    map.AttachEvent("ondoubleclick", AddPushpin);
//    map.LoadMap(new VELatLong(59.43655681809183, 24.75275516510011), 15, VEMapStyle.Road, false);
//}

//onload = GetMap;

function GetMap() {
    var map = new Microsoft.Maps.Map(document.getElementById("myMap"), {
        credentials: "AgqM0fOmSlYtmmbRFiuc01WRlU4_1-SsVPG5X4N0phbXF88SDDx_7pyisFB_MJWa",
        center: new Microsoft.Maps.Location(49.8382600, 24.0232400),
        mapTypeId: Microsoft.Maps.MapTypeId.road,
        zoom: 15
    });
}


function AddPushpin(e) {
    var pixel = new VEPixel(e.mapX, e.mapY);
    var point = map.PixelToLatLong(pixel);

    var pin = new VEShape(VEShapeType.Pushpin, point);
    pin.SetTitle("Double Click");
    pin.SetDescription("DoubleClick Event");
    map.AddShape(pin);

    AddPointToRoute(point);

    return true;
}

function AddPointToRoute(point) {
    var tr = document.createElement("tr");
    var td = document.createElement("td");
    td.innerText = point.Latitude;
    tr.appendChild(td);

    td = document.createElement("td");
    td.innerText = point.Longitude;
    tr.appendChild(td);

    var table = document.getElementById('routeTable');
    table.appendChild(tr);
}

