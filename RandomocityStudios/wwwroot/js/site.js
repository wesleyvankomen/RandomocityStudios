// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/*
const rootPath = '/images/favicon/sun_favicon/sun_favicon_';
const imageCount = 10;
var currentImage = 1;

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

sleep(2000);

setInterval(function () {
    $("link[rel='icon']").remove();
    $("link[rel='shortcut icon']").remove();
    $("head").append('<link rel="icon" href="' + rootPath + currentImage + '.png' + '" type="image/png">');

    // If last image then goto first image
    // Else go to next image    
    if (currentImage == imageCount)
        currentImage = 1;
    else
        currentImage++;
}, 500);

*/

//$(document).ready(function () {
//    var pageName = window.location.pathname;
//    var newPageName = pageName;

//    if (pageName.indexOf('/') == 0) {
//        newPageName = pageName.substring(1, pageName.length);

//        $.each($('#navbar').find('li'), function () {
//            var hrefVal = $(this).find('a').attr('href');

//            if (hrefVal.indexOf(newPageName) >= 0) {
//                $(this).addClass('active').siblings().removeClass('active');
//            }

//        });
//    }
//});





// update active link
$(document).ready(function () {
    var url = window.location;
    $('.navbar .nav').find('.active').removeClass('active');
    $('.navbar .nav li a').each(function () {
        if (this.href == url) {
            $(this).parent().addClass('active');
        }
    });
});