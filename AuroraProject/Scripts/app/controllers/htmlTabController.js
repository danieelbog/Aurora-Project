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
        $("#audienceInfo-tab").click(function () {
            $("#influencerInfo-tab").removeClass("active");
        })

        $("#influencerInfo-tab").click(function () {
            $("#audienceInfo-tab").removeClass("active");
        })
    }

    return {
        homeIndex: homeIndex,
        mineInfluencer: mineInfluencer
    }

}();