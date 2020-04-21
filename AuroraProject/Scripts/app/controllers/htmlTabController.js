let HtmlTabController = new function () {
    let homeIndex = function () {
        $("#industry-tab").click(function () {
            $(".home-container-fluid").removeClass("position-absolute")
            $("#home-tab").removeClass("active")
        })

        $("#home-tab").click(function () {
            $(".home-container-fluid").addClass("position-absolute")
            $("#industry-tab").removeClass("active")
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

    let myProfileTabs = function () {

        $("#auction-tab").click(function () {
            $("#position-tab").removeClass("active")
            $("#reviews-tab").removeClass("active")            
        })

        $("#position-tab").click(function () {
            $("#auction-tab").removeClass("active")
            $("#reviews-tab").removeClass("active")
        })

        $("#reviews-tab").click(function () {
            $("#position-tab").removeClass("active")
            $("#auction-tab").removeClass("active")
        })
    }

    return {
        homeIndex: homeIndex,
        mineInfluencer: mineInfluencer,
        myProfileTabs: myProfileTabs
    }

}();