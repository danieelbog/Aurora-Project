let NotificationService = function () {

    let getNotifications = function (countNotifications) {

        $.getJSON("/api/notifications", function (notifications) {
            if (notifications.length == 0)
                return;

            countNotifications(notifications);

        });
    }

    let readNotification = function (notificationId, done, fail) {
        $.post("/api/notifications", { NotificationID: notificationId })
            .done(done)
            .fail(fail)
    }

    let deleteNotification = function (notificationId, done, fail) {
        $.ajax({
            url: "/api/notifications/" + notificationId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail)
    }

    return {
        getNotifications: getNotifications,
        readNotification: readNotification,
        deleteNotification: deleteNotification,
    }
}();