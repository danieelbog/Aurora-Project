let PurchaseService = function () {
    let purchase = function (viewModel, done, fail, packageName) {

        $.ajax({
            url: '/api/sellingPackages',
            method: 'post',
            data: viewModel
        })
            .done(function () {
                done(packageName)
            })
            .fail(function () {
                fail(packageName)
            })
    }

    return {
        purchase: purchase
    }

}();