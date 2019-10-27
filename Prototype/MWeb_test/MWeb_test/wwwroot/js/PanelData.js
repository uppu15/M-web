function addCarousel(image) {
    var thumbnailImageBag = document.getElementById("imageBag")
    var allThumbNails = '';
    if (image.length == 0) {
        thumbnailImageBag.innerHTML = '<img width="300" height="168" src="https://i.ytimg.com/vi/uCPA9uXkuco/maxresdefault.jpg" />'
    }
    else {
        if (image.length > 1) {
            for (var i = 1; i < image.length; i++) {
                allThumbNails += '<div class="carousel-item">' + image[i] + '</div>'
            }
        }
        thumbnailImageBag.innerHTML = '<div class="carousel-inner"><div class="carousel-item active">' + image[0] + '</div>' + allThumbNails + '</div><a class="carousel-control-prev" href="#imageBag" role="button" data-slide="prev"><span class="carousel-control-prev-icon" aria-hidden="true"></span><span class="sr-only">Previous</span></a><a class="carousel-control-next" href="#imageBag" role="button" data-slide="next"><span class="carousel-control-next-icon" aria-hidden="true"></span><span class="sr-only" >Next</span ></a></div>'
    }
}