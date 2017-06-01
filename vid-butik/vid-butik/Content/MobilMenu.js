$(document).ready(function () {

    $("[data-toggle]").click(function () {

        var toggle_el = $(this).data("toggle");

        $(toggle_el).toggleClass("open-sidebar");

    });

});

$(".swipe-area").swipe({

    swipeStatus: function (event, phase, direction, distance, duration, fingers) {

        if (phase == "move" && direction == "right") {

            $(".nav_container").addClass("open-sidebar");

            return false;

        }

        if (phase == "move" && direction == "left") {

            $(".nav_container").removeClass("open-sidebar");

            return false;

        }

    }

});

