let PurchaseController = function (purchaseService) {

    let packageButton;
    let ButtonId;
    let packageName;
    let rowElement;

    // PURCHASE
    let initial = function (container) {

        $(container).on("click", ".js-button-click", function (event) {
            ButtonId = event.target.id;

            if (ButtonId == "basic") {
                basicPurchase();
            }
            else if (ButtonId == "advanced") {
                advancedPurchase();
            }
            else if (ButtonId == "premium") {
                premiumPurchase();
            }
        })
    }

    // BASIC PACKAGE PURCHASE
    let basicPurchase = function () {

        $('#purchace-gig-basic').off('submit').on("submit", function (e) {

            e.preventDefault(e.target.firstChild);

            packageButton = $(e.target.children);

            rowElement = $(this).parent().closest("tr");

            packageName = packageButton.attr("data-sellingPackage-name");

            let viewModel = {};
            viewModel.BasicPackageID = packageButton.attr("data-sellingPackage-id")

            viewModel.ID = packageButton.attr("data-gig-id")

            BootBoxDialog(packageButton, viewModel, packageName, e)
        });
    }

    // ADVANCED PACKAGE PURCHASE
    let advancedPurchase = function () {
        $('#purchace-gig-advanced').off('submit').on("submit", function (e) {

            e.preventDefault(e.target.firstChild);

            packageButton = $(e.target.children);
            rowElement = $(this).parent().closest("tr");

            packageName = packageButton.attr("data-sellingPackage-name");

            let viewModel = {};
            viewModel.AdvancedPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.ID = packageButton.attr("data-gig-id")

            BootBoxDialog(packageButton, viewModel, packageName, e)
        });
    }

    // PREMIUM PACKAGE PURCHASE
    let premiumPurchase = function () {
        $('#purchace-gig-premium').off('submit').on("submit", function (e) {

            e.preventDefault(e.target.firstChild);

            packageButton = $(e.target.children);
            rowElement = $(this).parent().closest("tr");

            packageName = packageButton.attr("data-sellingPackage-name");

            let viewModel = {};
            viewModel.PremiumPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.ID = packageButton.attr("data-gig-id")

            BootBoxDialog(packageButton, viewModel, packageName, e)
        });
    }

    let BootBoxDialog = function (packageName, viewModel, packageName, e) {

        bootbox.dialog({
            title: 'Confirm Purchase',
            message: '<p>Are you sure you want to purchase the Selected Service of the Gig?</p>',
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
                        callback: purchaseService.purchase(viewModel, donePay, failPay, packageName, e)
                    }
                }
            }
        })
    }    

    let donePay = function (packageName, e) {
        console.log("SUCCESFULLY PAYED")
        togglePayed(packageName);
    }

    let failPay = function (packageName) {
        alert("FAILED TO PAY")
        toastr.error("Failed to Purchase " + packageName);
    }

    let togglePayed = function (packageName) {
        let viewModel = {};
        viewModel.OrderID = packageButton.attr("data-order-id");
        purchaseService.payOrder(viewModel, done, fail, packageName);
    }

    let done = function (packageName) {
        console.log("OK")
        NotificationController.getNotifications();
        rowElement.addClass("d-none");
        toastr.success("Purchased " + packageName);
    }

    let fail = function (packageName) {
        console.log("FAIL")
        toastr.error("Failed to Purchase " + packageName);
    }

    return {
        initial: initial
    }

}(PurchaseService);


