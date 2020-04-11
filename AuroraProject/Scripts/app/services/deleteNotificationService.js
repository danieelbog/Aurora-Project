let DeleteNotificationService = function () {
    let deleteNotification = function (notificationId, done, fail) {
        $.ajax({
            url: "/api/notifications/" + notificationId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail)
    }

    return {
        deleteNotification: deleteNotification
    }
}();