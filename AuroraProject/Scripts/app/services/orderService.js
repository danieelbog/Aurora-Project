let OrderService = function () {

    let getOrders = function (countOrders) {

        $.getJSON("/api/orders", function (orders) {
            if (orders.length == 0)
                return;

            countOrders(orders);
        });
    }

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
        deleteOrder: deleteOrder,
        getOrders: getOrders
    }
}();