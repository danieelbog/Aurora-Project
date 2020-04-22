let GigService = function () {
    //DISABLE GIG, ID SENDING
    let disableGig = function (gigId, done, fail) {
        $.ajax({
            url: "/api/gigs/" + gigId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail)
    }
    //ENABLE GIG, ID SENDING
    let enableGig = function (gigId, done, fail) {
        $.ajax({
            url: "/api/gigs/" + gigId,
            method: "POST"
        })
            .done(done)
            .fail(fail)
    }
    //FAVOURITE GIG, ID SENDING
    let favouriteGig = function (gigId, done, fail) {
        $.post("/api/favouriteGigs", { GigID: gigId })
            .done(done)
            .fail(fail)
    }
    //UNFAVOURITE GIG, ID SENDING
    let unfavouriteGig = function (gigId, done, fail) {
        $.ajax({
            url: "/api/favouriteGigs/" + gigId,
            method: "delete"
        })
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