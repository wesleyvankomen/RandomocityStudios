function stopVideo() {
    this.contentWindow.postMessage('{"event":"command","func":"stopVideo","args":""}', '*');
}

$('#musicLeft').add('#musicRight').add(".carousel-selector-pull-down").click(function () {
    $('.yt_player_iframe').each(stopVideo);
});