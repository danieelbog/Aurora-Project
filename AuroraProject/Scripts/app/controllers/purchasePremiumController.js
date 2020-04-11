let PurchasePremiumController = function (purchaseService) {

    let viewModel = {};
    let packageButton;

    let initial = function (packageName) {
        $('#purchace-gig-premium').submit(function (e) {

            e.preventDefault(e.target.firstChild);

            packageButton = $(e.target.children);

            bootBoxDialog(packageButton, viewModel, packageName)

        });
    }

    let bootBoxDialog = function (packageButton, viewModel, packageName) {

        viewModel.BasicPackageID = packageButton.attr("data-sellingPackage-id")
        viewModel.ID = packageButton.attr("data-gig-id")

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
                        callback: purchaseService.purchase(viewModel, done, fail, packageName)
                    }
                }
            }
        })
    }

    let done = function (packageName) {
        toastr.success("Purchased " + packageName);
        console.log("OK")


        $.getJSON("/api/notifications", function (notifications) {
            if (notifications.length == 0)
                return;

            $(".js-notifications-count")
                .text(notifications.length)
                .removeClass("hide")
                .addClass("animated bounceInDown");
        });
    }

    let fail = function (packageName) {

        console.log("FAIL")
        toastr.error("Failed to Purchase " + packageName);
    }

    return {
        initial: initial
    }

}(PurchaseService);


