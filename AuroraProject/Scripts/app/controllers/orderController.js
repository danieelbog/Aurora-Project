let OrderController = function (orderService) {

    let packageButton;
    let ButtonId;
    let ButtonText;
    let rowElement;

    // GET ORDER
    let getOrders = function () {
        orderService.getOrders(countOrders);
    }

    let countOrders = function (notifications) {
        //DISPLAY THE COUNT OF THE ORDER
        $(".js-orders-count")
            .text(notifications.length)
            .removeClass("hide")
            .addClass("animated bounceInDown");
    }


    //DELETE ORDER
    let deleteOrder = function () {
        deleteOrderFromCart();
    }

    let deleteOrderFromCart = function () {
        // ON CLICK EVENT
        $(".fa-trash").on("click", function (e) {
            // GET THE BUTTON ID (BASIC, ADVANCED, PREMIUM)
            packageButton = $(e.target);
            // GET THE ELEMENT DIV IN ORDER TO HIDE IT WHEN DONE
            rowElement = $(this).parent().closest("tr");
            // GET VIEW MODEL FOR ORDERDTO
            let viewModel = {};
            viewModel.OrderID = packageButton.attr("data-order-id");
            // GO TO DELETEORDER
            orderService.deleteOrder(viewModel, done, fail);
        })
    }

    // PURCHASE
    let initial = function (container) {
        // ON CLICK EVENT
        $(container).on("click", ".js-button-click", function (event) {
            // GET THE BUTTON ID (BASIC, ADVANCED, PREMIUM)
            ButtonId = event.target.id;
            // GET THE BUTTON TEXT TO DISPLAY IT AS A NAME IN TOASTR LATER
            ButtonText = ($(`#${event.target.id}`).text());

            if (ButtonId == "basic") {
                basicPurchase(ButtonText);
            }
            else if (ButtonId == "advanced") {
                advancedPurchase(ButtonText);
            }
            else if (ButtonId == "premium") {
                premiumPurchase(ButtonText);
            }
        })
    }

    // BASIC PACKAGE PURCHASE
    let basicPurchase = function (packageName) {

        $('#purchace-gig-basic').off('submit').on("submit", function (e) {
            //PREVENT DEFAULT
            e.preventDefault(e.target.firstChild);
            // GET THE BUTTON THAT WAS PRESSED
            packageButton = $(e.target.children);
            // CREATE VIEWMODEL TO SEND IT TO DTO
            let viewModel = {};
            viewModel.BasicPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.GigID = packageButton.attr("data-gig-id")
            viewModel.Count = 1;
            viewModel.SellerInstructions = "Nothing for now";
            viewModel.Coupon = "No Coupon";
            // GO TO BOOTBOX DIALOG TO CONTRINUE THE PROCESS
            BootBoxDialog(packageButton, viewModel, packageName)
        });
    }

    // ADVANCED PACKAGE PURCHASE
    let advancedPurchase = function (packageName) {
        $('#purchace-gig-advanced').off('submit').on("submit", function (e) {
            //PREVENT DEFAULT
            e.preventDefault(e.target.firstChild);
            // GET THE BUTTON THAT WAS PRESSED
            packageButton = $(e.target.children);
            // CREATE VIEWMODEL TO SEND IT TO DTO
            let viewModel = {};
            viewModel.AdvancedPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.GigID = packageButton.attr("data-gig-id")
            viewModel.Count = 1;
            viewModel.SellerInstructions = "Nothing for now";
            viewModel.Coupon = "No Coupon";
            // GO TO BOOTBOX DIALOG TO CONTRINUE THE PROCESS
            BootBoxDialog(packageButton, viewModel, packageName)
        });
    }

    // PREMIUM PACKAGE PURCHASE
    let premiumPurchase = function (packageName) {
        $('#purchace-gig-premium').off('submit').on("submit", function (e) {

            //PREVENT DEFAULT
            e.preventDefault(e.target.firstChild);
            // GET THE BUTTON THAT WAS PRESSED
            packageButton = $(e.target.children);
            // CREATE VIEWMODEL TO SEND IT TO DTO
            let viewModel = {};
            viewModel.PremiumPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.GigID = packageButton.attr("data-gig-id")
            viewModel.Count = 1;
            viewModel.SellerInstructions = "Nothing for now";
            viewModel.Coupon = "No Coupon";
            // GO TO BOOTBOX DIALOG TO CONTRINUE THE PROCESS
            BootBoxDialog(packageButton, viewModel, packageName)
        });
    }

    //BOOTBOX FOR CONFIRMING ADDING TO CART
    let BootBoxDialog = function (packageName, viewModel, packageName) {

        bootbox.dialog({
            title: 'Confirm Purchase',
            message: '<p>Are you sure you want to add the Selected Service to your Cart?</p>',
            size: 'large',
            onEscape: true,
            backdrop: true,
            buttons: {
                no: {
                    label: 'Cancel',
                    className: 'btn bootbox-cancel-btn shadow-none',
                    callback: function () {
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: 'Continue',
                    className: 'btn bootbox-confirm-btn shadow-none',
                    callback: function () {
                        callback: orderService.addOrder(viewModel, done, fail, packageName)
                    }
                }
            }
        })
    }

    let done = function (packageName) {
        // PACKAGE NULL == SHOPPING CART DELETING ORDER
        if (packageName == null) {
            rowElement.addClass("d-none");
        }
        // COUNTING ORDERS TO DISPLAY IN NAV BAR
        OrderController.getOrders();
        // TOASTR TO DISPLAY THE CORRECT MESSAGE
        packageName != null ? toastr.success("Added " + packageName + " To Cart") : toastr.success("Order Deleted");
    }

    let fail = function (packageName) {
        // PACKAGE NULL == SHOPPING CART DELETING ORDER
        packageName != null ? toastr.success("Failed to Add " + packageName) : toastr.success("Failed to Delete");
    }

    return {
        initial: initial,
        deleteOrder: deleteOrder,
        getOrders: getOrders
    }

}(OrderService);