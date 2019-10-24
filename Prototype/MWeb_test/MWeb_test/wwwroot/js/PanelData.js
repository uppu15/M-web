function changeImage() {
    // exit if no images, or step = number of items in array (4)
    var step = 0;
    if (typeof images == "undefined" || step == images.length) return;

    //imagesInDistance[step];
    //document.getElementById('imgClickAndChange').src = images[step];
    //step++;
    document.getElementById("insideLeftHamburger").innerHTML = imagesInDistance[step];
    step++;

}


