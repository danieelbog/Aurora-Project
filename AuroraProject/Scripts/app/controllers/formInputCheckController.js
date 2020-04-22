let FormInputCheckController = function () {
    //CHECK IF ALL THE INPUTS ARE FILLED
    let initial = function () {
        //GET THE INPUT TEXTS
        let inputText = $("input[type=text]");
        //GET THE SUBMIT BUTTON
        let buttonSubmit = $(".btn-submit-form");

        if (buttonSubmit.text() !== "UpdateUpdate") {
            //HIDE THE SUBMIT ON DEFAULT
            buttonSubmit.css("display", "none");
        }
        //WHEN INPUT CHANGE ACT
        inputText.change(function () {
            //GET THE FIELDS WE WANT TO INPUT AND SERIALIZE THEM
            var fields = $(".form-group")
                .find("select, textarea, input").serializeArray();
            //FOR EACH FIELD IF IT IS NOT FILLED DONT SHOW THE BUTTON
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






