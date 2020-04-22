let HoverIndustryController = function () {

    //HOVER FUNCTION ON NAV BAR INDUSTRIES
    let initial = function (container) {
        $(container).on("mouseenter", ".li-industry", hoverOpen);
        $(container).on("mouseleave", ".li-industry", hoverClose);
    }

    //OPEN HOVER ON MOUSENTER
    let hoverOpen = function () {

        $(this).find('.dropdown-menu').stop(true, true).delay(.3).fadeIn(.3);
        console.log("LOL")
    }
    //CLOSE HOVER ON MOUSELEAVE
    let hoverClose = function () {
        $(this).find('.dropdown-menu').stop(true, true).delay(.3).fadeOut(.3);
        console.log("out")
    }

    return {
        initial: initial
    }
}();