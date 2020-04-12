let SearchController = function () {
    let initial = function () {
        $(".search-icon-navbar").click(function () {

            // INTIALIZE MY ENTITIES
            let searchBox = $(".search-box");
            let closeSearchBox = $(".close-search-icon");
            let inputText = $("input:text,form");
            let searchInput = $(".search-input");

            //TURN AUTOCOMPLETE OFF
            inputText.attr("autocomplete", "off");

            //MAKE SEARCH BOX VISIBLE
            searchBox.css("visibility", "visible");

            //MAKE THE CLOSE BUTTON FUNCTIONAL
            closeSearchBox.click(function () {
                searchBox.css("visibility", "hidden");
            })

            //ACTIVATE THE TEXTBOX WHEN DIV OPENS
            $(function () {
                searchInput.focus();
            });

            //CLOSE SEARCH BOX WHEN ESC IS PRESSED
            $(document).on('keydown', function (e) {
                if (e.keyCode === 27) { // ESC
                    searchBox.css("visibility", "hidden");
                }
            });

            //CLOSE SEARCH BOX WHEN SCROLL DOWN
            $(window).scroll(function () {
                if ($(this).scrollTop() > 0) {
                    searchBox.css("visibility", "hidden");
                } else {
                    //searchBox.css("visibility", "hidden");
                }
            });

        })
    }

    return {
        initial: initial
    }
}();