This is one of my prototype for the MSSA project.  This project mainly serves as my playground for View page using Google Maps API.

### CSS
```
#map {
    height: 100%;
    width: 100%;
    position: absolute;
    z-index: 1;
}

html, body {
    height: 100%;
    width: 100%;
    margin: 0;
    padding: 0;
}

googleLogo {
    width: 66px;
    height: 26px;
    cursor: pointer;
    position: absolute;
    z-index: 1000000;
}
/* -----Buttons --------------------------------------------------------------------------------*/
#Log-in_Button {
    position: absolute;
    z-index: 8;
    border-radius: 50%;
    background-color: rgb(85, 142, 250);
    text-align: center;
    cursor: pointer;
    right: 0.5em;
    top: 0.5em;
    display: inline-block;
    width: 45px;
    height: 45px;
    vertical-align: middle;
    padding-right: 10px;
    padding-top: 5px;
    border-width: 0;
}

#Hamburger_button {
    position: absolute;
    z-index: 8;
    border-radius: 50%;
    background-color: white;
    text-align: center;
    cursor: pointer;
    right: 0.5em;
    top: 5em;
    padding: 8px;
    width: 45px;
    height: 45px;
    display: inline-block;
    vertical-align: middle;
    align-items: center;
    align-content: center;
    border-width: 0;
}

#leftHamburger {
    position: absolute;
    z-index: 8;
    background-color: white;
    vertical-align: middle;
    border-width: 0;
    margin-top: 8px;
    margin-left: 3px;
}

/* -----Side Panel----------------------------------------------------------------------------------*/
.sidepanel {
    height: 92%; /* Specify a height */
    width: 0; /* 0 width - change this with JavaScript */
    position: fixed; /* Stay in place */
    z-index: 8; /* Stay on top */
    border-radius: 8px;
    box-shadow: 0 2px 6px rgba(0,0,0,.3);
    top: 0;
    right: 0;
    background-color: white;
    overflow-x: hidden; /* Disable horizontal scroll */
    /* padding-top: 20px; /* Place content 60px from the top */
    transition: 0.5s; /* 0.5 second transition effect to slide in the sidepanel */
}

.leftSidepanel {
    height: 92%; /* Specify a height, make sure the panel doesn't cover up Google logo */
    width: 0; /* 0 width - change this with JavaScript */
    position: fixed; /* Stay in place */
    z-index: 5; /* Stay on top */
    border-radius: 8px;
    box-shadow: 0 2px 6px rgba(0,0,0,.3);
    top: 0;
    left: 0;
    background-color: white;
    overflow-x: hidden; /* Disable horizontal scroll */
    /*padding: 8% 0 0 0;*/
    transition: 0.5s; /* 0.5 second transition effect to slide in the sidepanel */
}

/* Set a style for all buttons */
logInFormButton {
    background-color: #4d90fe;
    border-color: #3079ed;
    color: white;
    font-weight: bold;
    margin: 10px 0 0 0;
    border: none;
    cursor: pointer;
    width: 100%;
}

/* -----Login container-------------------------------------------------------------------------------------------*/
LoginContainer {
    padding: 16px 20% 16px 16px;
    
}
/* -----Search box------------------------------------------------------------------------------------------------*/
.pac-card {
    margin: 5px 0 0 5px;
    border-radius: 10px;
    /*box-sizing: border-box;*/
    -moz-box-sizing: border-box;
    outline: none;
    box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
    background-color: #fff;
    font-family: Roboto;
    position: absolute;
    z-index: 7;
    width: 60%;
}

#pac-input {
    background-color: transparent;
    font-family: Roboto;
    font-size: 15px;
    font-weight: 300;
    padding: 5px;
    text-overflow: ellipsis;
    width: 100%;
    left: 7%;
    z-index: 4;
    border-width: 0;
}

/* #pac-input:focus {
            border-color: white;
        } */

#pac-container {
    padding: 5px;
    padding-left: 35px;
    z-index: 4;
}

/* full-width input fields */
input[type=text], input[type=password] {
    width: 100%;
    /* padding: 15px;
            /* margin: 5px 20px 0 20px;
            /* padding-left: 20px;
            /* display: inline-block; */
    /* border: 1px solid #ccc; */
    box-sizing: border-box;
    z-index: 4;
}
```

### HTML
```

@{
    Layout = "";
}

<!DOCTYPE html>
<html>
<link rel="stylesheet" type="text/css" href="~/css/StyleSheet.css">
<head>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <title>Play with google map api</title>

</head>
<body>
    <div>
        <div id="map"></div>
        <div id="LoginSidePanel" class="sidepanel">
            <div style="padding: 50px 20% 0 2%">
                <form action="" method="post">
                    <div id="LoginContainer">
                        <label for="uname"><b>Username</b></label>
                        <input type="text" placeholder="Enter Username" name="uname" required>

                        <label for="psw"><b>Password</b></label>
                        <input type="password" placeholder="Enter Password" name="psw" required>

                        <button type="submit">Login</button>
                        <label>
                            <input type="checkbox" checked="checked" name="remember"> Remember me
                        </label>
                    </div>
                    <div id="LoginContainer" style="background-color:#f1f1f1">
                        <span class="psw">Forgot <a href="#">password?</a></span>
                    </div>
                </form>
            </div>
        </div>

        <div id="OptionPanel" class="sidepanel">
            <div style="padding: 50px 5% 0 2%">
                Here comes Option page
            </div>
        </div>

        <div id="LeftHamburger" class="leftSidepanel">
            <div style="padding: 50px 0 0 2%">
                Here comes my search box, photo share and comments share
            </div>
        </div>

        <div class="pac-card" id="pac-card">
            <button id="leftHamburger" title="details" onclick="toggleLeftHamburger()">
                <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px"
                     width="20" height="20"
                     viewBox="0 0 172 172"
                     style=" fill:#000000;">
                    <g fill="none" fill-rule="nonzero" stroke="none" stroke-width="1" stroke-linecap="butt" stroke-linejoin="miter" stroke-miterlimit="10" stroke-dasharray="" stroke-dashoffset="0" font-family="none" font-size="none" style="mix-blend-mode: normal"><path d="M0,172v-172h172v172z" fill="none"></path><g fill="#3498db"><path d="M21.5,78.83333h129v14.33333h-129zM21.5,35.83333h129v14.33333h-129zM21.5,121.83333h129v14.33333h-129z"></path></g></g>
                </svg>
            </button>
            <div id="pac-container">
                <input id="pac-input" type="text" placeholder="Enter a location">
            </div>
        </div>

        <button id="Log-in_Button" title="Sign in" onclick="toggleLoginSidePanel()">
            <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px"
                 width="25" height="25"
                 viewBox="0 0 172 172"
                 style=" fill:#000000;">
                <g fill="none" fill-rule="nonzero" stroke="none" stroke-width="1" stroke-linecap="butt" stroke-linejoin="miter" stroke-miterlimit="10" stroke-dasharray="" stroke-dashoffset="0" font-family="none" font-size="none" style="mix-blend-mode: normal; margin:20px 0px;"><path d="M0,172v-172h172v172z" fill="none"></path><g fill="#ffffff"><path d="M44.72,0c-5.65694,0 -10.32,4.65923 -10.32,10.32v65.36h6.88v-65.36c0,-1.94163 1.50142,-3.44 3.44,-3.44h116.96c1.93858,0 3.44,1.49837 3.44,3.44v151.36c0,1.9365 -1.5035,3.44 -3.44,3.44h-116.96c-1.9365,0 -3.44,-1.5035 -3.44,-3.44v-65.36h-6.88v65.36c0,5.65902 4.66098,10.32 10.32,10.32h116.96c5.65902,0 10.32,-4.66098 10.32,-10.32v-151.36c0,-5.66077 -4.66306,-10.32 -10.32,-10.32zM75.82781,45.06265c-1.39859,0.00309 -2.65612,0.85256 -3.18113,2.14887c-0.52501,1.29631 -0.21302,2.78145 0.78926,3.75691l31.58485,31.59156h-101.58078c-1.24059,-0.01754 -2.39452,0.63425 -3.01993,1.7058c-0.62541,1.07155 -0.62541,2.39684 0,3.46839c0.62541,1.07155 1.77935,1.72335 3.01993,1.7058h101.58078l-31.59156,31.59156c-0.89864,0.86282 -1.26063,2.14403 -0.94636,3.34954c0.31427,1.2055 1.25569,2.14693 2.4612,2.4612c1.20551,0.31427 2.48672,-0.04772 3.34954,-0.94636l39.89594,-39.89594l-39.88922,-39.89594c-0.64928,-0.66743 -1.54136,-1.04317 -2.4725,-1.04141z"></path></g></g>
            </svg>
        </button>
        <button id="Hamburger_button" title="Options" onclick="toggleOptionSidePanel()">
            <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px"
                 width="27" height="27"
                 viewBox="0 0 172 172"
                 style=" fill:#000000;">
                <g fill="none" fill-rule="nonzero" stroke="none" stroke-width="1" stroke-linecap="butt" stroke-linejoin="miter" stroke-miterlimit="10" stroke-dasharray="" stroke-dashoffset="0" font-family="none" font-size="none" style="mix-blend-mode: normal"><path d="M0,172v-172h172v172z" fill="none"></path><g fill="#3498db"><path d="M21.5,78.83333h129v14.33333h-129zM21.5,35.83333h129v14.33333h-129zM21.5,121.83333h129v14.33333h-129z"></path></g></g>
            </svg>
        </button>
        <div id="googleLogo">
            <img src="https://maps.gstatic.com/mapfiles/api-3/images/google4_hdpi.png" style="z-index:100">
        </div>
    </div>
```

### Javascript
```
    <script>
        var map, infoWindow;
        var sandiego = { lat: 32.8227269, lng: -117.1496352 };
        var oceanside = { lat: 33.306769, lng: -117.308317 };
        var gmarker2, gmarker3;
        //var whereAmI = <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px"
        //    width="22" height="22"
        //    viewBox="0 0 172 172"
        //    style=" fill:#000000;"><g fill="none" fill-rule="nonzero" stroke="none" stroke-width="1" stroke-linecap="butt" stroke-linejoin="miter" stroke-miterlimit="10" stroke-dasharray="" stroke-dashoffset="0" font-family="none" font-weight="none" font-size="none" text-anchor="none" style="mix-blend-mode: normal"><path d="M0,172v-172h172v172z" fill="none"></path><g><path d="M86,165.55c-43.8643,0 -79.55,-35.6857 -79.55,-79.55c0,-43.8643 35.6857,-79.55 79.55,-79.55c43.8643,0 79.55,35.6857 79.55,79.55c0,43.8643 -35.6857,79.55 -79.55,79.55z" fill="#ffffff"></path><path d="M86,8.6c42.6775,0 77.4,34.7225 77.4,77.4c0,42.6775 -34.7225,77.4 -77.4,77.4c-42.6775,0 -77.4,-34.7225 -77.4,-77.4c0,-42.6775 34.7225,-77.4 77.4,-77.4M86,4.3c-45.1199,0 -81.7,36.5801 -81.7,81.7c0,45.1199 36.5801,81.7 81.7,81.7c45.1199,0 81.7,-36.5801 81.7,-81.7c0,-45.1199 -36.5801,-81.7 -81.7,-81.7z" fill="#3498db"></path><g fill="#3498db"><path d="M86,64.5c-11.87412,0 -21.5,9.62588 -21.5,21.5c0,11.87412 9.62588,21.5 21.5,21.5c11.87412,0 21.5,-9.62588 21.5,-21.5c0,-11.87412 -9.62588,-21.5 -21.5,-21.5z"></path></g></g></g></svg>;
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
            google.maps.event.addListener(map, 'click', function (event) {
                placeMarker(event.latLng);
            });
            google.maps.event.addListener(map, 'click', function (event) {
                //dummy points near my school/library so I can check if the function works
                var sandiegoLatLng = new google.maps.LatLng(sandiego.lat, sandiego.lng);
                var oceansideLatLng = new google.maps.LatLng(oceanside.lat, oceanside.lng);
                var distance = google.maps.geometry.spherical.computeDistanceBetween(event.latLng, sandiegoLatLng);
                console.log((distance).toFixed(2));
                if (distance > circle.radius) {
                    marker2.setVisible(false);
                }
                else {
                    marker2.setVisible(true);
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
            marker2 = new google.maps.Marker({
                position: sandiego,
                map: map
            });
            marker3 = new google.maps.Marker({
                position: oceanside,
                map: map,
            });
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
    @*</script>

    <script>*@
        //search box-----------------------------------------------------------------------------
        var card = document.getElementById('pac-card');
        var input = document.getElementById('pac-input');
        map.controls[google.maps.ControlPosition.LEFT_TOP].push(card);
        var autocomplete = new google.maps.places.Autocomplete(input);
        // Bind the map's bounds (viewport) property to the autocomplete object,
        // so that the autocomplete requests use the current map bounds for the
        // bounds option in the request.
        autocomplete.bindTo('bounds', map);
        // Set the data fields to return when the user selects a place.
        autocomplete.setFields(
            ['address_components', 'geometry', 'icon', 'name']);
        autocomplete.addListener('place_changed', function() {
          infowindow.close();
          marker.setVisible(false);
          var place = autocomplete.getPlace();
            if (!place.geometry) {
                // User entered the name of a Place that was not suggested and
                // pressed the Enter key, or the Place Details request failed.
                window.alert("No details available for input: '" + place.name + "'");
                return;
            }
        // If the place has a geometry, then present it on a map.
          if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
          } else {
            map.setCenter(place.geometry.location);
            map.setZoom(15);  // Why 15? Because it looks good.
          }
          marker.setPosition(place.geometry.location);
          marker.setVisible(true);
          var address = '';
          if (place.address_components) {
            address = [
              (place.address_components[0] && place.address_components[0].short_name || ''),
              (place.address_components[1] && place.address_components[1].short_name || ''),
              (place.address_components[2] && place.address_components[2].short_name || '')
            ].join(' ');
          }
          infowindowContent.children['place-icon'].src = place.icon;
          infowindowContent.children['place-name'].textContent = place.name;
          infowindowContent.children['place-address'].textContent = address;
          infowindow.open(map, marker);
        });
        document.getElementById('use-strict-bounds')
            .addEventListener('click', function() {
              console.log('Checkbox clicked! New state=' + this.checked);
              autocomplete.setOptions({strictBounds: this.checked});
            });
    @*</script>
    <script>*@
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
                    radius: 500
                });
            }
        }
    @*</script>
    <script>*@
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
    </script>
    <script>
            //I found out that I needed to implement library myself after dealing with source code for 4 weeks. wonderful.
    </script>
    <script async defer
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBbjx5U78SGpevXKDEYCrcYT02y-81KG3Q&libraries=geometry,places&callback=initMap">
    </script>
    @*<script src="https://maps.googleapis.com/maps/api/js?v=3&sensor=false&libraries=geometry"></script>*@

</body>
</html>
```
