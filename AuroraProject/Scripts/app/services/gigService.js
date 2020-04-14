let GigService = function () {
    let disableGig = function (gigId, done, fail) {
        $.ajax({
            url: "/api/gigs/" + gigId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail)
    }

    let enableGig = function (gigId, done, fail) {
        $.ajax({
            url: "/api/gigs/" + gigId,
            method: "POST"
        })
            .done(done)
            .fail(fail)
    }

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
        enableGig: enableGig,
        disableGig: disableGig,
        favouriteGig: favouriteGig,
        unfavouriteGig: unfavouriteGig
    }

}();