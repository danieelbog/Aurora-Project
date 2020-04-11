let NotificationController = function (notificationService) {
    let initial = function () {

        notificationService.getNotifications(countNotifications);
    }

    let countNotifications = function (notifications) {
        $(".js-notifications-count")
            .text(notifications.length)
            .removeClass("hide")
            .addClass("animated bounceInDown");
    }

    return {
        initial: initial
    }

}(NotificationService);
