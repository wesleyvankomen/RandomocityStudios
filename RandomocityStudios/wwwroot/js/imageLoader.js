$(function () {
    var images = $('.lazy-load').find('img[data-src]');
    images.each(function () {
        var $this = $(this);
        $this.attr('src', $this.attr('data-src'));
        $this.removeAttr('data-src');
    });
});