let NotificationController = function (notificationService) {

    let button;
    let newText;

    // GET NOTIFICATION
    let getNotifications = function () {

        notificationService.getNotifications(countNotifications);       
    }

    let countNotifications = function (notifications) {
        $(".js-notifications-count")
            .text(notifications.length)
            .removeClass("hide")
            .addClass("animated bounceInDown");
    }

    //READ NOTIFICATION
    let readNotifications = function () {

        $(".js-read-notification").click(function (e) {
            toggleNotification(e);
        });       
    }

    let toggleNotification = function (e) {

        button = $(e.target);
        newText = button.parent().find("span");

        let notificationId = button.attr("data-notification-id")

        notificationService.readNotification(notificationId, doneReadNotification, failReadNotification)
    }

    let doneReadNotification = function () {
        newText.addClass("d-none");
        button.addClass("d-none");
        NotificationController.getNotifications();
        toastr.success("Notification Read");
    }

    let failReadNotification = function () {
        newText.hasClass("d-none") ? toastr.error("Notification is Already Read") : toastr.error("Failed to Read Notification");
    }

    //DELETE NOTIFICATION
    let deleteNotification = function () {

        $(".js-delete-notification").click(function (e) {
            deleteFunction(e);
        })        
    }

    let deleteFunction = function (e) {

        button = $(e.target);
        newText = button.parent();
        let notificationId = button.attr("data-notification-id");

        notificationService.deleteNotification(notificationId, doneDeleteNotification, failDeleteNotification)
    }

    let doneDeleteNotification = function () {
        newText.addClass("d-none");
        NotificationController.getNotifications();
        toastr.success("Notification Deleted");
    }

    let failDeleteNotification = function () {
        toastr.error("Faled to Delete");
    }

    return {
        getNotifications: getNotifications,
        readNotifications: readNotifications,
        deleteNotification: deleteNotification
    }

}(NotificationService);
