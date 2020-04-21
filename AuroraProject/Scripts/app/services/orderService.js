let OrderService = function () {

    let addOrder = function (viewModel, done, fail, packageName) {
        $.ajax({
            url: '/api/orders',
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

    let deleteOrder = function (viewModel, done, fail) {
        $.ajax({
            url: '/api/orders',
            method: 'delete',
            data: viewModel
        })
            .done(function () {
                done(null)
            })
            .fail(function () {
                fail(null)
            })
    }

    return {
        addOrder: addOrder,
        deleteOrder: deleteOrder
    }
}();