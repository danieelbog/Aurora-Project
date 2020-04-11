let ReadNotificationController = function (readNotificationService) {

    let button;
    let newText;

    let initial = function () {

        $(".js-read-notification").click(function (e) {
            toggleNotification(e);
        });
    }

    let toggleNotification = function (e) {

        button = $(e.target);
        newText = button.parent().find("span");

        let notificationId = button.attr("data-notification-id")

        readNotificationService.readNotification(notificationId, done, fail)
    }

    let done = function () {
        newText.addClass("d-none");
        button.addClass("d-none");
        toastr.success("Notification Read");

        NotificationController.initial();
    }

    let fail = function () {
        newText.hasClass("d-none") ? toastr.error("Notification is Already Read") : toastr.error("Failed to Read Notification");
    }

    return {
        initial: initial
    }
}(ReadNotificationService);
