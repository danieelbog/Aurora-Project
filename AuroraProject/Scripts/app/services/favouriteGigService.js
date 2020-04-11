let FavouriteGigService = function () {
    let favouriteGig = function (gigId, done, fail) {
        $.post("/api/favouriteGigs", { GigID: gigId })
            .done(done)
            .fail(fail)
    }

    let unfavouriteGig = function (gigId, done, fail) {
        $.delete("/api/favouriteGigs", { GigID: gigId })
            .done(done)
            .fail(fail)
    }

    return {
        favouriteGig: favouriteGig,
        unfavouriteGig: unfavouriteGig
    }

}();