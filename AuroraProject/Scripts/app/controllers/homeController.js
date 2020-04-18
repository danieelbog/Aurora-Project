let HomeController = new function () {
    let initial = function () {
        $("#industry-tab").click(function () {
            $("#home-tab").removeClass("active");
        })

        $("#home-tab").click(function () {
            $("#industry-tab").removeClass("active");
        })
    }

    return {
        initial: initial
    }

}();