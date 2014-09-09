var flag = false;

$(document).ready(function () {

    $("#toggle").hide();
    
    $("#show").click(function () {
        if (!flag) {
            flag = true;
            $("#toggle").show("clip", { direction: "vertical" }, 500);
        }
        else {
            flag = false;
            $("#toggle").hide("clip", { direction: "vertical" }, 500);
        }

    });

    $("#dtBox").DateTimePicker();
});


all_images = new Array(
"/Content/image/slide.jpg",
"/Content/image/slide1.jpg",
"/Content/image/slide2.jpg");
var ImgNum = 0;
var ImgLength = all_images.length - 1;
var delay = 4500;
var lock = false;
var run;

function chgImg(direction) {
    if (document.images) {
        ImgNum = ImgNum + direction;
        if (ImgNum > ImgLength) { ImgNum = 0; }
        if (ImgNum < 0) { ImgNum = ImgLength; }
        document.slide_show.src = all_images[ImgNum];
    }
}

function auto() {
    if (lock == true) {
        lock = false;
        window.clearInterval(run);
    }
    else if (lock == false) {
        lock = true;
        run = setInterval("chgImg(1)", delay);
    }
}