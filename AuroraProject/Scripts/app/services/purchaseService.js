let PurchaseService = function () {
    //PURCAHSE GIG, VIEWMODEL-GIGDTO
    let purchase = function (viewModel, donePay, failPay, packageName, e) {

        $.ajax({
            url: '/api/sellingPackages',
            method: 'post',
            data: viewModel
        })
            .done(function () {
                donePay(packageName, e)
            })
            .fail(function () {
                failPay(packageName, e)
            })
    }
    //PAY ORDER, VIEWMODEL-ORDERDTO
    let payOrder = function (viewModel, done, fail, packageName) {
        $.ajax({
            url: '/api/orders',
            method: 'put',
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
        purchase: purchase,
        payOrder: payOrder
    }

}();