//function changeImage() {
//    // exit if no images, or step = number of items in array (4)
//    var step = 0;
//    if (typeof images == "undefined" || step == images.length) return;

//    //imagesInDistance[step];
//    //document.getElementById('imgClickAndChange').src = images[step];
//    //step++;
//    document.getElementById("insideLeftHamburger").innerHTML = imagesInDistance[step];
//    step++;
//}

function addCarousel(image) {
    var thumbnailImageBag = document.getElementById("imageBag")
    var allThumbNails = '';
    if (image.length == 0) {
        thumbnailImageBag.innerHTML = '<img width="350" height="196" src="https://i.ytimg.com/vi/uCPA9uXkuco/maxresdefault.jpg" />'
    }
    if (image.length > 1) {
        for (var i = 1; i < image.length; i++) {
            allThumbNails += '<div class="carousel-item">' + image[i] + '</div>'
        }
    }
    thumbnailImageBag.innerHTML = '<div class="carousel-inner"><div class="carousel-item active">' + image[0] + '</div>' + allThumbNails + '</div><a class="carousel-control-prev" href="#imageBag" role="button" data-slide="prev"><span class="carousel-control-prev-icon" aria-hidden="true"></span><span class="sr-only">Previous</span></a><a class="carousel-control-next" href="#imageBag" role="button" data-slide="next"><span class="carousel-control-next-icon" aria-hidden="true"></span><span class="sr-only" >Next</span ></a></div>'
}


