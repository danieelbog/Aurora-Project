let GigController = function (gigService) {

    let button;

    //DISABLE GIG
    let disableGig = function () {
        $(".js-disable-gig").click(toggleVisibility);
    }

    let toggleVisibility = function (e) {

        button = $(e.target);
        let gigId = button.attr("data-gig-id");

        if (button.hasClass("fa-eye-slash"))
            gigService.disableGig(gigId, doneDisableGig, failDisableGig);
        else
            gigService.enableGig(gigId, doneDisableGig, failDisableGig);
    }

    let doneDisableGig = function () {
        button.hasClass("fa-eye-slash") ? toastr.success("Gig Hidden") : toastr.success("Gig Visible");
        // THIS MAY NOT WORK
        button.toggleClass("fa-eye-slash").toggleClass("fa-eye");
    }

    let failDisableGig = function () {
        button.hasClass("fa-eye-slash") ? toastr.error("Faled to Hide Gig") : toastr.error("Faled to Hide Gig");
    }

    //FAVOURITE GIG
    let favouriteGig = function () {
        $(".js-toggle-favourite-gig").click(toggleFavourite);
    }

    let toggleFavourite = function (e) {
        button = $(e.target);
        let gigId = button.attr("data-gig-id");

        if (button.hasClass("fa-heart-o"))
            gigService.favouriteGig(gigId, doneFavouriteGig, failFavouriteGig)
        else
            gigService.unfavouriteGig(gigId, doneFavouriteGig, failFavouriteGig)
    }

    let doneFavouriteGig = function () {
        button.hasClass("fa-heart-o") ? toastr.success("Added To Favourites") : toastr.success("Removed from Favourites");
        button.toggleClass("fa-heart-o").toggleClass("fa-heart");
    }

    let failFavouriteGig = function () {
        button.hasClass("fa-heart-o") ? toastr.error("Failed Adding to Favourites") : toastr.error("Failed Removing from Favourites");
    }

    return {
        disableGig: disableGig,
        favouriteGig: favouriteGig
    }

}(GigService);




