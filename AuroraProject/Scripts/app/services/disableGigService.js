let DisableGigService = function () {
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

    return {
        enableGig: enableGig,
        disableGig: disableGig
    }

}();