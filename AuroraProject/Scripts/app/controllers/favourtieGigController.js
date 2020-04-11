let FavouriteGigController = function (favouriteGigService) {

    let button;
    let initial = function () {
        $(".js-toggle-favourite-gig").click(toggleFavourite);
    }

    let toggleFavourite = function () {
        button = $(e.target);
        let gigId = button.attr("data-gig-id");

        if (button.hasClass("fa-heart-o"))
            favouriteGigService.favouriteGig(gigId, done, fail)
        else
            favouriteGigService.unfavouriteGig(gigId, done, fail)
    }

    let done = function () {
        button.hasClass("fa-heart-o") ? toastr.success("Added To Favourites") : toastr.success("Removed from Favourites");
        button.toggleClass("fa-heart-o").toggleClass("fa-heart");
    }

    let fail = function () {
        button.hasClass("fa-heart-o") ? toastr.error("Failed Adding to Favourites") : toastr.error("Failed Removing from Favourites");
    }

    return {
        initial: initial
    }

}(FavouriteGigService);