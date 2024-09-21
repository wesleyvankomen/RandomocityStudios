function stopVideo() {
    this.contentWindow.postMessage('{"event":"command","func":"stopVideo","args":""}', '*');
}

$('#musicLeft, #musicRight, .carousel-selector-pull-down').on('click', function () {
    $('.yt_player_iframe').each(stopVideo);
});