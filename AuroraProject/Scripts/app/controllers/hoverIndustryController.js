let HoverIndustryController = function () {

    let initial = function (container) {

        $(container).on("mouseenter", ".li-industry", hoverOpen);
        $(container).on("mouseleave", ".li-industry", hoverClose);
    }

    let hoverOpen = function () {

        $(this).find('.dropdown-menu').stop(true, true).delay(0).fadeIn(0);
        console.log("LOL")
    }

    let hoverClose = function () {
        $(this).find('.dropdown-menu').stop(true, true).delay(0).fadeOut(0);
        console.log("out")

    }

    return {
        initial: initial
    }
}();