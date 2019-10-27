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

//side panels
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
    if (document.getElementById("LeftHamburger").style.width == '350px') {
        document.getElementById("LeftHamburger").style.width = '0px';
    } else {
        document.getElementById("LeftHamburger").style.width = '350px';
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