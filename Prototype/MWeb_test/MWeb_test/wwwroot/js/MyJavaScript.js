 var map, infoWindow;
var sandiego = { lat: 32.8227269, lng: -117.1496352 };
var oceanside = { lat: 33.306769, lng: -117.308317 };
var gmarker2, gmarker3;

//hard code markers---------------------------------------------------------------------------
var HCMarker;
var markers = [];
//var LatLngCollection;

//LatLngCollection = [
//    [32.818429, -117.150000],
//    [32.918429, -117.05000],
//    [32.718429, -117.25],
//    [32.618429, -117.35],
//    [32.7, -117.03],
//    [32.65,-117.035]
//]

//sandbox
//var MarkerObj = JSON.parse('{"MarkerLat":33.355555,"MarkerLng":-118.35555,"photo":""}');
//var JsonToMarker;
//console.log(MarkerObj.MarkerLat);
//console.log(MarkerObj.MarkerLng);
//function MarkersFromDatabase() {
//    JsonToMarker = new google.maps.Marker({
//        position: new google.maps.LatLng(MarkerObj.MarkerLat, MarkerObj.MarkerLng),
//        map: map
//    });
//}

//console.log("@Model");

//--------------------------------------------------------------------------------------------
//LatLngCollection[0] = new google.maps.LatLng(32.818429, -117.150000);
//LatLngCollection[1] = new google.maps.LatLng(32.918429, -117.05000);
//LatLngCollection[2] = new google.maps.LatLng(32.718429, -117.25);
//LatLngCollection[3] = new google.maps.LatLng(32.618429, -117.35);
        var LatLngCollection = JSON.parse('@Html.Raw(Json.Serialize(Model))');

function setMarkers() {
    //LatLngCollection.forEach((LatLng) => { console.log(LatLng) });
    //console.log('@Html.Raw(Model)');
    for (var i = 0; i < LatLngCollection.length; i++) {
        console.log(LatLngCollection[i]);
        HCMarker = new google.maps.Marker({
            position: new google.maps.LatLng(LatLngCollection[i].markerLat, LatLngCollection[i].markerLng),
            map: map
        });
        markers.push(HCMarker);
    }
}

//Center button
function CenterControl(controlDiv, map) {
    // Set CSS for the control border.
    var controlUI = document.createElement('div');
    controlUI.style.backgroundImage = "url(data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHg9IjBweCIgeT0iMHB4Igp3aWR0aD0iMzAiIGhlaWdodD0iMzAiCnZpZXdCb3g9IjAgMCAxNzIgMTcyIgpzdHlsZT0iIGZpbGw6IzAwMDAwMDsiPjxnIGZpbGw9Im5vbmUiIGZpbGwtcnVsZT0ibm9uemVybyIgc3Ryb2tlPSJub25lIiBzdHJva2Utd2lkdGg9IjEiIHN0cm9rZS1saW5lY2FwPSJidXR0IiBzdHJva2UtbGluZWpvaW49Im1pdGVyIiBzdHJva2UtbWl0ZXJsaW1pdD0iMTAiIHN0cm9rZS1kYXNoYXJyYXk9IiIgc3Ryb2tlLWRhc2hvZmZzZXQ9IjAiIGZvbnQtZmFtaWx5PSJub25lIiBmb250LXdlaWdodD0ibm9uZSIgZm9udC1zaXplPSJub25lIiB0ZXh0LWFuY2hvcj0ibm9uZSIgc3R5bGU9Im1peC1ibGVuZC1tb2RlOiBub3JtYWwiPjxwYXRoIGQ9Ik0wLDE3MnYtMTcyaDE3MnYxNzJ6IiBmaWxsPSJub25lIj48L3BhdGg+PGcgZmlsbD0iIzM0OThkYiI+PHBhdGggZD0iTTg1LjkxMDQyLDUuNjU0OTVjLTMuMTYyMDMsMC4wNDk0MyAtNS42ODcwNSwyLjY0OTYgLTUuNjQzNzUsNS44MTE3MnY2LjAyNDQ4Yy0zMy4zNTgyNywyLjc3Mzk3IC02MC4wMTU3NCwyOS40MjExIC02Mi43ODY3Miw2Mi43NzU1MmgtNi4wMTMyOGMtMi4wNjc2NSwtMC4wMjkyNCAtMy45OTA4NywxLjA1NzA5IC01LjAzMzIyLDIuODQzYy0xLjA0MjM2LDEuNzg1OTIgLTEuMDQyMzYsMy45OTQ3NCAwLDUuNzgwNjZjMS4wNDIzNiwxLjc4NTkyIDIuOTY1NTgsMi44NzIyNSA1LjAzMzIyLDIuODQzaDYuMDI0NDhjMi43NzM3MSwzMy4zNTUxMyAyOS40MjAzOSw2MC4wMDE4MSA2Mi43NzU1Miw2Mi43NzU1MnY2LjAyNDQ4Yy0wLjAyOTI0LDIuMDY3NjUgMS4wNTcwOSwzLjk5MDg3IDIuODQzLDUuMDMzMjJjMS43ODU5MiwxLjA0MjM2IDMuOTk0NzQsMS4wNDIzNiA1Ljc4MDY2LDBjMS43ODU5MiwtMS4wNDIzNiAyLjg3MjI1LC0yLjk2NTU4IDIuODQzLC01LjAzMzIydi02LjAyNDQ4YzMzLjM1NTEzLC0yLjc3MzcxIDYwLjAwMTgxLC0yOS40MjAzOSA2Mi43NzU1MiwtNjIuNzc1NTJoNi4wMjQ0OGMyLjA2NzY1LDAuMDI5MjQgMy45OTA4NywtMS4wNTcwOSA1LjAzMzIyLC0yLjg0M2MxLjA0MjM2LC0xLjc4NTkyIDEuMDQyMzYsLTMuOTk0NzQgMCwtNS43ODA2NmMtMS4wNDIzNiwtMS43ODU5MiAtMi45NjU1OCwtMi44NzIyNSAtNS4wMzMyMiwtMi44NDNoLTYuMDEzMjhjLTIuNzcwOTgsLTMzLjM1NDQyIC0yOS40Mjg0NSwtNjAuMDAxNTUgLTYyLjc4NjcyLC02Mi43NzU1MnYtNi4wMjQ0OGMwLjAyMTIyLC0xLjU0OTcyIC0wLjU4NTgxLC0zLjA0MjAzIC0xLjY4Mjc5LC00LjEzNjljLTEuMDk2OTgsLTEuMDk0ODcgLTIuNTkwNDUsLTEuNjk5MDMgLTQuMTQwMTMsLTEuNjc0ODJ6TTgwLjI2NjY3LDI4Ljk0NjYxdjUuNDUzMzljLTAuMDI5MjQsMi4wNjc2NSAxLjA1NzA5LDMuOTkwODcgMi44NDMsNS4wMzMyMmMxLjc4NTkyLDEuMDQyMzYgMy45OTQ3NCwxLjA0MjM2IDUuNzgwNjYsMGMxLjc4NTkyLC0xLjA0MjM2IDIuODcyMjUsLTIuOTY1NTggMi44NDMsLTUuMDMzMjJ2LTUuNDUzMzljMjcuMTM3MTYsMi42ODEyNyA0OC42Mjg5NiwyNC4xODIwMSA1MS4zMDg4Niw1MS4zMjAwNWgtNS40NDIxOWMtMi4wNjc2NSwtMC4wMjkyNCAtMy45OTA4NywxLjA1NzA5IC01LjAzMzIyLDIuODQzYy0xLjA0MjM2LDEuNzg1OTIgLTEuMDQyMzYsMy45OTQ3NCAwLDUuNzgwNjZjMS4wNDIzNiwxLjc4NTkyIDIuOTY1NTgsMi44NzIyNSA1LjAzMzIyLDIuODQzaDUuNDUzMzljLTIuNjgxMTIsMjcuMTM1NiAtMjQuMTg0NDYsNDguNjM4OTMgLTUxLjMyMDA1LDUxLjMyMDA1di01LjQ1MzM5YzAuMDIxMjIsLTEuNTQ5NzIgLTAuNTg1ODEsLTMuMDQyMDMgLTEuNjgyNzksLTQuMTM2OWMtMS4wOTY5OCwtMS4wOTQ4NyAtMi41OTA0NSwtMS42OTkwMyAtNC4xNDAxMywtMS42NzQ4MmMtMy4xNjIwMywwLjA0OTQzIC01LjY4NzA1LDIuNjQ5NiAtNS42NDM3NSw1LjgxMTcydjUuNDUzMzljLTI3LjEzNTYsLTIuNjgxMTIgLTQ4LjYzODk0LC0yNC4xODQ0NiAtNTEuMzIwMDUsLTUxLjMyMDA1aDUuNDUzMzljMi4wNjc2NSwwLjAyOTI0IDMuOTkwODcsLTEuMDU3MDkgNS4wMzMyMiwtMi44NDNjMS4wNDIzNiwtMS43ODU5MiAxLjA0MjM2LC0zLjk5NDc0IDAsLTUuNzgwNjZjLTEuMDQyMzYsLTEuNzg1OTIgLTIuOTY1NTgsLTIuODcyMjUgLTUuMDMzMjIsLTIuODQzaC01LjQ0MjE5YzIuNjc5ODksLTI3LjEzODA1IDI0LjE3MTY5LC00OC42Mzg3OCA1MS4zMDg4NSwtNTEuMzIwMDV6TTg2LDYzLjA2NjY3Yy0xMi42NjU3MywwIC0yMi45MzMzMywxMC4yNjc2IC0yMi45MzMzMywyMi45MzMzM2MwLDEyLjY2NTczIDEwLjI2NzYsMjIuOTMzMzMgMjIuOTMzMzMsMjIuOTMzMzNjMTIuNjY1NzMsMCAyMi45MzMzMywtMTAuMjY3NiAyMi45MzMzMywtMjIuOTMzMzNjMCwtMTIuNjY1NzMgLTEwLjI2NzYsLTIyLjkzMzMzIC0yMi45MzMzMywtMjIuOTMzMzN6Ij48L3BhdGg+PC9nPjwvZz48L3N2Zz4=)";
    controlUI.style.backgroundColor = 'white';
    controlUI.style.backgroundRepeat = 'no-repeat';
    controlUI.style.backgroundPositionX = '8px';
    controlUI.style.backgroundPositionY = '7px';
    controlUI.style.borderRadius = '50%';
    controlUI.style.boxShadow = '0 2px 6px rgba(0,0,0,.3)';
    controlUI.style.cursor = 'pointer';
    controlUI.style.marginRight = '10px';
    controlUI.style.marginBottom = '10px';
    controlUI.style.textAlign = 'center';
    controlUI.style.width = '45px';
    controlUI.style.height = '45px';
    controlUI.title = 'Center Me Button';
    controlDiv.appendChild(controlUI);
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var curLoc = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            // Setup the click event listeners: simply set the map to San Diego.
            controlUI.addEventListener('click', function () {
                map.setCenter(curLoc);
                map.setZoom(12);
            });
        });
    }
}

//initiate google maps api centered at Embry-Riddle
function initMap() {

    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 15,
        center: { lat: 32.8195, lng: -117.14099 },
        fullscreenControl: false,
        mapTypeControlOptions: {
            position: google.maps.ControlPosition.BOTTOM_RIGHT
        }
    });

    //Place a marker at clicked location on the map
    google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(event.latLng);
    });
    google.maps.event.addListener(map, 'click', function (event) {

        //dummy points near my school/library so I can check if the function works
        //var sandiegoLatLng = new google.maps.LatLng(sandiego.lat, sandiego.lng);
        //var oceansideLatLng = new google.maps.LatLng(oceanside.lat, oceanside.lng);
        //var oceansideLatLng = new google.maps.LatLng(oceanside.lat, oceanside.lng);

        //Calculate each marker from event location
        for (var j = 0; j < LatLngCollection.length; j++) {
            var LatLngVar = new google.maps.LatLng(LatLngCollection[j].markerLat,LatLngCollection[j].markerLng);
            var distance = google.maps.geometry.spherical.computeDistanceBetween(event.latLng, LatLngVar);
            console.log((distance).toFixed(2));
            if (distance > circle.radius) {
                markers[j].setVisible(false);
            }
            else {
                markers[j].setVisible(true);
            }
        }

        //}
        //var resultOpacity = google.maps.geometry.poly.containsLocation(sandiego, event.circle) ? google.maps.Marker.setVisible(marker2(true)) : google.maps.Marker.setVisible(marker2(false));
        //new google.maps.Marker({
        //    position: sandiego,
        //    map: map,
        //    icon: {
        //        opacity: resultOpacity,
        //        scale: 2
        //    }
        //});
    });
    //marker2 = new google.maps.Marker({
    //    position: sandiego,
    //    map: map
    //});
    //marker3 = new google.maps.Marker({
    //    position: oceanside,
    //    map: map,
    //});
    setMarkers();
    @*var userObj = '@Html.Raw(Model)';
    console.log(userObj);*@
    //MarkersFromDatabase();
    //    function changeMarkerOption(placeMarker(location)) {
    //    google.maps.event.addEventListener(map, 'click', function (event) {
    //        if (google.maps.geometry.poly.containsLocation(sandiego, placeMarker.circle) == true)
    //            marker2.setOptions({
    //                opacity: 1
    //            });
    //        else {
    //            marker2.setOptions({
    //                opacity: 0
    //            });
    //        }
    //    }
    //}
    infoWindow = new google.maps.InfoWindow;
    //check for geolocation(user's current location)
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var curLoc = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            //User location marker that will be placed on the map
            var myLocMarker = new google.maps.Marker({
                position: curLoc,
                icon: {
                    path: google.maps.SymbolPath.BACKWARD_OPEN_ARROW,
                    scale: 3
                },
                map: map
            })
            //place marker, and center map to curLoc
            infoWindow.setContent(myLocMarker);
            infoWindow.open(map);
            map.setCenter(curLoc);
        },
            function () {
                handleLocationError(true, infoWindow, map.getCenter());
            });
    } else {
        handleLocationError(false, infoWindow, map.getCenter());
    }
    function handleLocationError(browserHasGeolocation, infoWindow, curLoc) {
        infoWindow.setPosition(curLoc);
        infoWindow.setContent(browserHasGeolocation ?
            'Error: The geolocation service failed.' :
            'Error: Your browser does not support geolocation.');
        infoWindow.open(map);
    }
    var centerControlDiv = document.createElement('div');
    var centerControl = new CenterControl(centerControlDiv, map);
    centerControlDiv.index = 1;
    map.controls[google.maps.ControlPosition.RIGHT_BOTTOM].push(centerControlDiv);
};

//search box-----------------------------------------------------------------------------
//var card = document.getElementById('pac-card');
//var input = document.getElementById('pac-input');
//map.controls[google.maps.ControlPosition.LEFT_TOP].push(card);
//var autocomplete = new google.maps.places.Autocomplete(input);
//// Bind the map's bounds (viewport) property to the autocomplete object,
//// so that the autocomplete requests use the current map bounds for the
//// bounds option in the request.
//autocomplete.bindTo('bounds', map);
//// Set the data fields to return when the user selects a place.
//autocomplete.setFields(
//    ['address_components', 'geometry', 'icon', 'name']);
//autocomplete.addListener('place_changed', function () {
//    infowindow.close();
//    marker.setVisible(false);
//    var place = autocomplete.getPlace();
//    if (!place.geometry) {
//        // User entered the name of a Place that was not suggested and
//        // pressed the Enter key, or the Place Details request failed.
//        window.alert("No details available for input: '" + place.name + "'");
//        return;
//    }
//    // If the place has a geometry, then present it on a map.
//    if (place.geometry.viewport) {
//        map.fitBounds(place.geometry.viewport);
//    } else {
//        map.setCenter(place.geometry.location);
//        map.setZoom(15);  // Why 15? Because it looks good.
//    }
//    marker.setPosition(place.geometry.location);
//    marker.setVisible(true);
//    var address = '';
//    if (place.address_components) {
//        address = [
//            (place.address_components[0] && place.address_components[0].short_name || ''),
//            (place.address_components[1] && place.address_components[1].short_name || ''),
//            (place.address_components[2] && place.address_components[2].short_name || '')
//        ].join(' ');
//    }
//    infowindowContent.children['place-icon'].src = place.icon;
//    infowindowContent.children['place-name'].textContent = place.name;
//    infowindowContent.children['place-address'].textContent = address;
//    infowindow.open(map, marker);
//});
//document.getElementById('use-strict-bounds')
//    .addEventListener('click', function () {
//        console.log('Checkbox clicked! New state=' + this.checked);
//        autocomplete.setOptions({ strictBounds: this.checked });
//    });
//Marker/circle when clicked on the map-----------------------------------------------------------------
var marker;
var circle;
//Create marker at clicked location
//Create circle at clicked location
function placeMarker(location) {
    if (marker) {
        marker.setPosition(location);
        circle.setCenter(location);
    } else {
        marker = new google.maps.Marker({
            position: location,
            map: map
        });
        circle = new google.maps.Circle({
            center: location,
            map: map,
            strokeColor: 'rgb(85, 142, 250)',
            strokeOpacity: 0,
            fillColor: 'rgb(85, 142, 250)',
            fillOpacity: 0.35,
            radius: 50000
        });
    }
}
function toggleLoginSidePanel() {
    if (document.getElementById("LoginSidePanel").style.width == '300px') {
        document.getElementById("LoginSidePanel").style.width = '0px';
    } else {
        document.getElementById("LoginSidePanel").style.width = '300px';
    }
}
function toggleOptionSidePanel() {
    if (document.getElementById("OptionPanel").style.width == '300px') {
        document.getElementById("OptionPanel").style.width = '0px';
    } else {
        document.getElementById("OptionPanel").style.width = '300px';
    }
}
function toggleLeftHamburger() {
    if (document.getElementById("LeftHamburger").style.width == '61%') {
        document.getElementById("LeftHamburger").style.width = '0px';
    } else {
        document.getElementById("LeftHamburger").style.width = '61%';
    }
}
window.onclick = function (event) {
    if (event.target != LoginSidePanel) {
        document.getElementById("LoginSidePanel").style.width = '0px';
    }
}
window.onclick = function (event) {
    if (event.target == OptionPanel) {
        document.getElementById("OptionPanel").style.width = '0px';
    }
}
window.onclick = function (event) {
    if (event.target == LeftHamburger) {
        document.getElementById("LeftHamburger").style.width = '0px';
    }
}