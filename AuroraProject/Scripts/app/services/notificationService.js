let NotificationService = function () {

    let getNotifications = function (countNotifications) {

        $.getJSON("/api/notifications", function (notifications) {
            if (notifications.length == 0)
                return;

            countNotifications(notifications);

        });
    }

    return {
        getNotifications: getNotifications
    }
}();