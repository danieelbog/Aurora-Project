let InfluencerController = function (influencerService) {

    let button;
    let initial = function () {
        //RUN ON CLICK
        $(".js-toggle-favourite-influencer").click(toggleFavourite);
    }

    //FAVOURITE INFLUENCER
    let toggleFavourite = function (e) {
        //GET BUTTON ELEMENT
        button = $(e.target);
        //GET INFLUENCER ID
        let influencerId = button.attr("data-influencer-id");
        //CHECK IF THE HEART IS EMPTY AND ACT ACORRIDNGLY
        if (button.hasClass("fa-heart-o"))
            influencerService.favouriteInfluencer(influencerId, done, fail);
        else
            influencerService.unfavouriteInfluencer(influencerId, done, fail);
    }
    //DONE
    let done = function () {
        //CHANGE THE BUTTON CLASS BASED ON WHAT WAS IT BEFORE
        button.hasClass("fa-heart-o") ? toastr.success("Influencer Added To Favourites") : toastr.success("Influencer Removed from Favourites");
        button.toggleClass("fa-heart-o").toggleClass("fa-heart");
    }
    // FAIL
    let fail = function () {
        button.hasClass("fa-heart-o") ? toastr.error("Failed Adding to Favourites") : toastr.error("Failed Removing from Favourites");
    }

    return {
        initial: initial
    }
}(InfluencerService);
