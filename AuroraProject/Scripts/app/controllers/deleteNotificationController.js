let DeleteNotificationController = function (deleteNotificationService) {

    let button;
    let newText;

    let initial = function () {
        $(".js-delete-notification").click(function (e) {
            deleteFunction(e);
        })
    }

    let deleteFunction = function (e) {

        button = $(e.target);
        newText = button.parent();
        let notificationId = button.attr("data-notification-id");

        deleteNotificationService.deleteNotification(notificationId, done, fail)
    }

    let done = function () {
        newText.addClass("d-none");
        NotificationController.initial();
        toastr.success("Notification Deleted");
    }

    let fail = function () {
        toastr.error("Faled to Delete");
    }

    return {
        initial: initial
    }
}(DeleteNotificationService);