let InfluencerController = function (influencerService) {

    let button;
    let initial = function () {
        $(".js-toggle-favourite-influencer").click(toggleFavourite);
    }

    let toggleFavourite = function () {

        button = $(e.target);
        let influencerId = button.attr("data-influencer-id");

        if (button.hasClass("fa-heart-o"))
            influencerService.favouriteInfluencer(influencerId, done, fail);
        else
            influencerService.unfavouriteInfluencer(influencerId, done, fail);
    }

    let done = function () {

        button.hasClass("fa-heart-o") ? toastr.success("Influencer Added To Favourites") : toastr.success("Influencer Removed from Favourites");
        button.toggleClass("fa-heart-o").toggleClass("fa-heart");
    }

    let fail = function () {
        button.hasClass("fa-heart-o") ? toastr.error("Failed Adding to Favourites") : toastr.error("Failed Removing from Favourites");
    }

    return {
        initial: initial
    }
}(InfluencerService);
