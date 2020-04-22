let GigController = function (gigService) {

    let button;

    //DISABLE GIG
    let disableGig = function () {
        $(".js-disable-gig").click(toggleVisibility);
    }
    //TOGGEL VISIBILITY
    let toggleVisibility = function (e) {
        //GET THE BUTTON TARGET
        button = $(e.target);
        //GET THE GIGI ID
        let gigId = button.attr("data-gig-id");
        //CHECK WHAT CLASS THE BUTTON HAS AND ACT ACORDINGLY
        if (button.hasClass("fa-eye-slash"))
            gigService.disableGig(gigId, doneDisableGig, failDisableGig);
        else
            gigService.enableGig(gigId, doneDisableGig, failDisableGig);
    }
    //DONE DISABLE GIG
    let doneDisableGig = function () {
        //CHOSE THE COREECT MESSAGE OF THE TOASTR
        button.hasClass("fa-eye-slash") ? toastr.success("Gig Hidden") : toastr.success("Gig Visible");
        //TOGGLE THE CLASS
        button.toggleClass("fa-eye-slash").toggleClass("fa-eye");
    }
    //FAIL DISABLE GIG
    let failDisableGig = function () {
        button.hasClass("fa-eye-slash") ? toastr.error("Faled to Hide Gig") : toastr.error("Faled to Hide Gig");
    }
    //FAVOURITE GIG
    let favouriteGig = function () {
        $(".js-toggle-favourite-gig").click(toggleFavourite);
    }
    //TOGGLE FAVOURITE
    let toggleFavourite = function (e) {
        //GET THE BUTTON TARGET
        button = $(e.target);
        //GET THE GIG ID
        let gigId = button.attr("data-gig-id");
        //CHECK THE BUTTON CLASS
        if (button.hasClass("fa-heart-o"))
            gigService.favouriteGig(gigId, doneFavouriteGig, failFavouriteGig)
        else
            gigService.unfavouriteGig(gigId, doneFavouriteGig, failFavouriteGig)
    }
    //DONE FAVOURITE
    let doneFavouriteGig = function () {
        //CHOSE THE COREECT MESSAGE OF THE TOASTR
        button.hasClass("fa-heart-o") ? toastr.success("Added To Favourites") : toastr.success("Removed from Favourites");
        //TOGGLE THE CLASS
        button.toggleClass("fa-heart-o").toggleClass("fa-heart");
    }
    //FAIL FAVOURITE
    let failFavouriteGig = function () {
        button.hasClass("fa-heart-o") ? toastr.error("Failed Adding to Favourites") : toastr.error("Failed Removing from Favourites");
    }

    return {
        disableGig: disableGig,
        favouriteGig: favouriteGig
    }

}(GigService);




