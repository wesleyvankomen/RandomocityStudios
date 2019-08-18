// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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

