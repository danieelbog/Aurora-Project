let ReadNotificationService = function () {

    let readNotification = function (notificationId, done, fail) {
        $.post("/api/notifications", { NotificationID: notificationId })
            .done(done)
            .fail(fail)
    }

    return {
        readNotification: readNotification
    }
}();