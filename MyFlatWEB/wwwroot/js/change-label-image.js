$(document).ready(function () {
    $('#Image').change(function () {
        var i = $(this).prev('label').clone();
        var file = $('#Image')[0].files[0].name;
        $(this).prev('label').text(file);
        $(this).next('label').removeClass('label-not-choose-image');
        $(this).next('label').addClass('label-choose-image');
        $(this).next('label').text("Image choosed");
    });
});