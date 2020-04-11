let FormInputCheckController = function () {
    let initial = function () {
        let inputText = $("input[type=text]");
        let buttonSubmit = $(".btn-submit-form");

        if (buttonSubmit.text() !== "UpdateUpdate") {
            buttonSubmit.css("display", "none");
        }

        inputText.change(function () {
            var fields = $(".form-group")
                .find("select, textarea, input").serializeArray();

            $.each(fields, function (i, field) {
                if (fields.every(f => f.value != '')) {
                    buttonSubmit.css("display", "block");
                }
                else {
                    buttonSubmit.css("display", "none");
                }
            });
        })
    }

    return {
        initial: initial
    }

}();






