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
        var leftPanel = document.getElementById("insideLeftHamburger")
        //leftPanel.innerHTML = '';
        var thumbImagesInDistance = [];
        for (var j = 0; j < LatLngCollection.length; j++) {
            var LatLngVar = new google.maps.LatLng(LatLngCollection[j].markerLat, LatLngCollection[j].markerLng);
            var distance = google.maps.geometry.spherical.computeDistanceBetween(event.latLng, LatLngVar);
            //console.log(distance);
            if (distance > circle.radius) {
                //document.getElementById(markers[j]).style.visibility = "hidden";
                markers[j].setVisible(false);
            }
            else {
                var numberOfImages = 0;
                markers[j].setVisible(true);
                thumbImagesInDistance.push('<img width="350" height="196" src=https://mwebimagestor.blob.core.windows.net/images/' + LatLngCollection[j].photoPath + '>')
                //leftPanel.innerHTML += '<img width="350" height="196" src=https://mwebimagestor.blob.core.windows.net/images/' + LatLngCollection[j].photoPath + '>';
                //console.log(imagesInDistance);
            }

        }
        //console.log(imagesInDistance[0]);
        addCarousel(thumbImagesInDistance);
        //document.getElementById("imageBag").innerHTML = '<img width="350" height="196" ' + imagesInDistance[0]
    });

    function addCarousel(image) {
        var thumbnailImageBag = document.getElementById("imageBag")
        var allThumbNails;
        //thumbnailImageBag.innerHTML = '<ol class="carousel-indicators">'
        //for (var i = 0; i < imagesInDistance.length; i++) {
        //    thumbnailImageBag.innerHTML += '<li data-target="#imageBag" data-slide-to="' + i + '" class="active"></li>'
        //}
        
        if (image.length > 1) {
            for (var i = 1; i < image.length; i++) {
                allThumbNails +='<div class="carousel-item">' + image[i] + '</div>'
            }
        }
        thumbnailImageBag.innerHTML = '<div class="carousel-inner"><div class="carousel-item active">' + image[0] + '</div>' + allThumbNails+ '</div><a class="carousel-control-prev" href="#imageBag" role="button" data-slide="prev"><span class="carousel-control-prev-icon" aria-hidden="true"></span><span class="sr-only">Previous</span></a><a class="carousel-control-next" href="#imageBag" role="button" data-slide="next"><span class="carousel-control-next-icon" aria-hidden="true"></span><span class="sr-only" >Next</span ></a></div>'
    }
    //document.getElementById("imageBag").innerHTML = '<img width="350" height="196" src=https://mwebimagestor.blob.core.windows.net/images/' + LatLngCollection[0].photoPath + '>';
    //function clickThroughImages(images) {
    //    images.onclick = changeImage()
    //}


    //clickThroughImages(imagesInDistance);

    //var testMarker = new google.maps.Marker({
    //    position: { lat: 32, lng: -118 },
    //    map:map
    //})
    //var testWindow = new google.maps.InfoWindow({
    //    content: 'this'
    //})
    //testMarker.addListener('click', function () {
    //    testWindow.open(map, testMarker)
    //})
    //console.log(testMarker);

    //check for geolocation(user's current location)
    //infoWindow = new google.maps.InfoWindow; 
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
