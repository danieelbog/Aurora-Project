let DisableGigController = function (disableGigService) {

    let button;

    let initial = function () {
        $(".js-disable-gig").click(toggleVisibility);
        //$(container).on("click", ".js-disable-gig", toggleVisibility);
    }

    let toggleVisibility = function (e) {

        button = $(e.target);
        let gigId = button.attr("data-gig-id");

        if (button.hasClass("fa-eye-slash"))
            disableGigService.disableGig(gigId, done, fail);
        else
            disableGigService.enableGig(gigId, done, fail);
    }

    let done = function () {
        button.hasClass("fa-eye-slash") ? toastr.success("Gig Hidden") : toastr.success("Gig Visible");
        // THIS MAY NOT WORK
        button.toggleClass("fa-eye-slash").toggleClass("fa-eye");
    }

    let fail = function () {
        button.hasClass("fa-eye-slash") ? toastr.error("Faled to Hide Gig") : toastr.error("Faled to Hide Gig");
    }

    return {
        initial: initial
    }

}(DisableGigService);




