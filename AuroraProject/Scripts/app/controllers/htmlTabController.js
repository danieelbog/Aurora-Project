let HtmlTabController = new function () {
    //RUN THE HOME INDEX
    let homeIndex = function () {
        //ON LOAD HIDE NAV BAR AT HOME
        $(".navbar").addClass("d-none")
        //ON CLICK TO HOME2 BRING NAV BACK
        $("#industry-tab").click(function () {
            $(".navbar").removeClass("d-none")
            $("#home-tab").removeClass("active")
        })
        //ON CLICK TO HOME1 BRING HIDE NAV
        $("#home-tab").click(function () {
            $(".navbar").addClass("d-none")
            $("#industry-tab").removeClass("active")
        })
    }

    //TABS FOR MY INFLUENCER PAGE
    let mineInfluencer = function () {
        $("#favAudienceInfo-tab").click(function () {
            $("#favInfluencerInfo-tab").removeClass("active");
        })

        $("#favInfluencerInfo-tab").click(function () {
            $("#favAudienceInfo-tab").removeClass("active");
        })
    }
    //TABS FOR MY MY PROFILE PAGE
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