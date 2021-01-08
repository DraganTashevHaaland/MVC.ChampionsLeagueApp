$(document).ready(function () {

    //navbar active links
    $(".navbar-nav").find('[href="' + window.location.pathname + '"]').parent().addClass("active");

    //carousel options - bootstrap
    $('.carousel').carousel({
        interval: 3000
    })
})

