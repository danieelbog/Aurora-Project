let OrderController = function (orderService) {

    let packageButton;
    let ButtonId;
    let ButtonText;

    // PURCHASE
    let initial = function (container) {

        $(container).on("click", ".js-button-click", function (event) {
            ButtonId = event.target.id;
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

            e.preventDefault(e.target.firstChild);

            packageButton = $(e.target.children);

            let viewModel = {};
            viewModel.BasicPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.ID = packageButton.attr("data-gig-id")

            BootBoxDialog(packageButton, viewModel, packageName)
        });
    }

    // ADVANCED PACKAGE PURCHASE
    let advancedPurchase = function (packageName) {
        $('#purchace-gig-advanced').off('submit').on("submit", function (e) {

            e.preventDefault(e.target.firstChild);

            packageButton = $(e.target.children);

            let viewModel = {};
            viewModel.AdvancedPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.ID = packageButton.attr("data-gig-id")

            BootBoxDialog(packageButton, viewModel, packageName)
        });
    }

    // PREMIUM PACKAGE PURCHASE
    let premiumPurchase = function (packageName) {
        $('#purchace-gig-premium').off('submit').on("submit", function (e) {

            e.preventDefault(e.target.firstChild);

            packageButton = $(e.target.children);

            let viewModel = {};
            viewModel.PremiumPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.ID = packageButton.attr("data-gig-id")

            BootBoxDialog(packageButton, viewModel, packageName)
        });
    }

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
        console.log("OK")

        NotificationController.getNotifications();

        toastr.success("Added " + packageName + " To Cart");
    }

    let fail = function (packageName) {

        console.log("FAIL")

        toastr.error("Failed to Add " + packageName + " To Cart");
    }

    return {
        initial: initial
    }

}(OrderService);