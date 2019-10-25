//This is reading from Js
var map, infoWindow;
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

    //Calculate each marker from event location
    //Determine left panel datas
    google.maps.event.addListener(map, 'click', function (event) {
        var thumbImagesInDistance = [];
        for (var j = 0; j < LatLngCollection.length; j++) {
            var LatLngVar = new google.maps.LatLng(LatLngCollection[j].markerLat, LatLngCollection[j].markerLng);
            var distance = google.maps.geometry.spherical.computeDistanceBetween(event.latLng, LatLngVar);
            if (distance > circle.radius) {
                markers[j].setVisible(false);
            }
            else {
                markers[j].setVisible(true);
                thumbImagesInDistance.push('<img width="350" height="196" src=https://mwebimagestor.blob.core.windows.net/images/' + LatLngCollection[j].photoPath + '>')
            }
        }
        addCarousel(thumbImagesInDistance);
    });



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
            //infoWindow.setContent(myLocMarker);
            //infoWindow.open(map);
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

    //-------------------------------------------------------------------------------
    // Create the search box and link it to the UI element.
    var input = document.getElementById('pac-input');
    var searchBox = new google.maps.places.SearchBox(input);
    //map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    // Bias the SearchBox results towards current map's viewport.
    map.addListener('bounds_changed', function () {
        searchBox.setBounds(map.getBounds());
    });

    // Listen for the event fired when the user selects a prediction and retrieve
    // more details for that place.
    searchBox.addListener('places_changed', function () {
        var places = searchBox.getPlaces();

        if (places.length == 0) {
            return;
        }


        // For each place, get the icon, name and location.
        var bounds = new google.maps.LatLngBounds();
        places.forEach(function (place) {
            if (!place.geometry) {
                console.log("Returned place contains no geometry");
                return;
            }

            if (place.geometry.viewport) {
                // Only geocodes have viewport.
                bounds.union(place.geometry.viewport);
            } else {
                bounds.extend(place.geometry.location);
            }
        });
        map.fitBounds(bounds);
    });

    setMarkers();
};


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
