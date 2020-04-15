﻿let InfluencerService = function () {
    let favouriteInfluencer = function (influencerId, done, fail) {
        $.post("/api/favouriteInfluencers", { InfluencerID: influencerId })
            .done(done)
            .fail(fail)
    }

    let unfavouriteInfluencer = function (influencerId, done, fail) {
        $.post("/api/favouriteInfluencers", { InfluencerID: influencerId })
            .done(done)
            .fail(fail)
    }

    return {
        favouriteInfluencer: favouriteInfluencer,
        unfavouriteInfluencer: unfavouriteInfluencer
    }
}();