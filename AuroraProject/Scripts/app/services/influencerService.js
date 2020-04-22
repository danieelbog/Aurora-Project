let InfluencerService = function () {
    //FAVOURITE INFLUENCER, ID SENDING
    let favouriteInfluencer = function (influencerId, done, fail) {
        $.post("/api/favouriteInfluencers", { InfluencerID: influencerId })
            .done(done)
            .fail(fail)
    }
    //UNFAVOURITE INFLUENCER, ID SENDING
    let unfavouriteInfluencer = function (influencerId, done, fail) {
        $.ajax({
            url: "/api/favouriteInfluencers/" + influencerId,
            method: "delete"
        })
            .done(done)
            .fail(fail)
    }

    return {
        favouriteInfluencer: favouriteInfluencer,
        unfavouriteInfluencer: unfavouriteInfluencer
    }
}();
