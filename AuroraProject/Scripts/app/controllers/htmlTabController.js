let HtmlTabController = new function () {
    let homeIndex = function () {
        $("#industry-tab").click(function () {
            $("#home-tab").removeClass("active");
        })

        $("#home-tab").click(function () {
            $("#industry-tab").removeClass("active");
        })
    }

    let mineInfluencer = function () {
        $("#favAudienceInfo-tab").click(function () {
            $("#favInfluencerInfo-tab").removeClass("active");
        })

        $("#favInfluencerInfo-tab").click(function () {
            $("#favAudienceInfo-tab").removeClass("active");
        })
    }

    return {
        homeIndex: homeIndex,
        mineInfluencer: mineInfluencer
    }

}();