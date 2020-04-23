let PurchaseController = function (purchaseService) {

    let packageButton;
    let ButtonId;
    let packageName;
    let rowElement;

    // PURCHASE
    let initial = function (container) {
        //ON CLICK EVENT
        $(container).on("click", ".js-button-click", function (event) {
            // GET THE BUTTON ID (BASIC, ADVANCED, PREMIUM)
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
            //PREVENT DEFAULT
            e.preventDefault(e.target.firstChild);
            // GET THE BUTTON THAT WAS PRESSED
            packageButton = $(e.target.children);
            // GET THE ELEMENT DIV IN ORDER TO HIDE WHEN DONE
            rowElement = $(this).parent().closest("tr");
            console.log(rowElement);
            // GET THE PACKAGE NAME
            packageName = packageButton.attr("data-sellingPackage-name");
            // CREATE VIEWMODEL TO SEND IT TO DTO
            let viewModel = {};
            viewModel.BasicPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.ID = packageButton.attr("data-gig-id")
            // GO TO BOOTBOX DIALOG TO CONTRINUE THE PROCESS
            BootBoxDialog(packageButton, viewModel, packageName, e)
        });
    }

    // ADVANCED PACKAGE PURCHASE
    let advancedPurchase = function () {
        $('#purchace-gig-advanced').off('submit').on("submit", function (e) {
            //PREVENT DEFAULT
            e.preventDefault(e.target.firstChild);
            // GET THE BUTTON THAT WAS PRESSED
            packageButton = $(e.target.children);
            // GET THE ELEMENT DIV IN ORDER TO HIDE WHEN DONE
            rowElement = $(this).parent().closest("tr");
            // GET THE PACKAGE NAME
            packageName = packageButton.attr("data-sellingPackage-name");
            // CREATE VIEWMODEL TO SEND IT TO DTO
            let viewModel = {};
            viewModel.AdvancedPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.ID = packageButton.attr("data-gig-id")
            // GO TO BOOTBOX DIALOG TO CONTRINUE THE PROCESS
            BootBoxDialog(packageButton, viewModel, packageName, e)
        });
    }

    // PREMIUM PACKAGE PURCHASE
    let premiumPurchase = function () {
        $('#purchace-gig-premium').off('submit').on("submit", function (e) {
            //PREVENT DEFAULT
            e.preventDefault(e.target.firstChild);
            // GET THE BUTTON THAT WAS PRESSED
            packageButton = $(e.target.children);
            // GET THE ELEMENT DIV IN ORDER TO HIDE WHEN DONE
            rowElement = $(this).parent().closest("tr");
            // GET THE PACKAGE NAME
            packageName = packageButton.attr("data-sellingPackage-name");
            // CREATE VIEWMODEL TO SEND IT TO DTO
            let viewModel = {};
            viewModel.PremiumPackageID = packageButton.attr("data-sellingPackage-id")
            viewModel.ID = packageButton.attr("data-gig-id")
            // GO TO BOOTBOX DIALOG TO CONTRINUE THE PROCESS
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
    //DONE PAY == PAYMENT COMPLETE
    let donePay = function (packageName, e) {
        //IF DONE THEN GO TO THE TOGGLE PAYED METHOD
        togglePayed(packageName);
    }
    //FAIL PAY == PAYMENT INCOMPLETE
    let failPay = function (packageName) {
        toastr.error("Failed to Purchase " + packageName);
    }
    // TOGGLE PAY
    let togglePayed = function (packageName) {
        //CREATE VIEWMODEL FOR ORDER DTO
        let viewModel = {};
        viewModel.OrderID = packageButton.attr("data-order-id");
        //GO TO SERVICE AND MAKE ISPAYD TRUE
        purchaseService.payOrder(viewModel, done, fail, packageName);
    }
    // DONE
    let done = function (packageName) {
        //GET NUMBER OF NOTIFICATIONS (PAYMENT NOTIFICATION GOES TO WALLET)
        NotificationController.getNotifications();
        //UPDATE THE ORDERS COUNT
        OrderController.getOrders();
        //HIDE THE ORDER THAT WAS PAYED
        rowElement.addClass("d-none");
        //SUCCESS
        toastr.success("Purchased " + packageName);
    }
    // FAIL
    let fail = function (packageName) {
        console.log("FAIL")
        toastr.error("Failed to Purchase " + packageName);
    }

    return {
        initial: initial
    }

}(PurchaseService);


