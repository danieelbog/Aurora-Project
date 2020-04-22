let OrderService = function () {
    //GET ORDERS AND SEND THEM TO COUNTORDERS
    let getOrders = function (countOrders) {
        $.getJSON("/api/orders", function (orders) {
            if (orders.length == 0)
                return;
            countOrders(orders);
        });
    }
    // ADD ORDER, SEND VIEMODEL-ORDERDTO
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
    // DELETE ORDER, SEND VIEMODEL-ORDERDTO
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