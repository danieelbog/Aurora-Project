let NotificationController = function (notificationService) {

    let button;
    let newText;

    //GET NOTIFICATION
    let getNotifications = function () {

        notificationService.getNotifications(countNotifications);       
    }

    //COUNT NOTIFIACTIONS
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

    //TOGGLE NOTIFICATIONS
    let toggleNotification = function (e) {
        //GET THE BUTTON PRESSED
        button = $(e.target);
        //GET THE DIV ELEMT OF THE CONTENT
        newText = button.parent().find("span");
        //GET THE ID OF THE NOTIFICATION
        let notificationId = button.attr("data-notification-id")
        //GO TO SERVICE TO SEND THE ID
        notificationService.readNotification(notificationId, doneReadNotification, failReadNotification)
    }

    //DONE READING NOTIFICATION
    let doneReadNotification = function () {
        //HIDE THE "NEW"OF THE NOTIFICATIONT HAT WAS READ
        newText.addClass("d-none");
        //HIDE THE BUTTON READ
        button.addClass("d-none");
        //COUNT NOTIFICATIONS FOR THE NAV
        NotificationController.getNotifications();
        //SUCCESS
        toastr.success("Notification Read");
    }

    //FAIL READING NOTIFICATIONS
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
        //GET THE BUTTON THAT WAS PRESSED
        button = $(e.target);
        //GET THE DIV OF THE PARENT ELEMENT TO HIDE IT LATER
        newText = button.parent();
        //GET THE ID
        let notificationId = button.attr("data-notification-id");
        //GO OT SERVICE TO SEND THE ID
        notificationService.deleteNotification(notificationId, doneDeleteNotification, failDeleteNotification)
    }

    //DONE DELETE
    let doneDeleteNotification = function () {
        //HIDE THE PARENT ELEMENT
        newText.addClass("d-none");
        //COUNT THE NOTIFICATIONS IN CASE OF UNREAD WAS DELETED
        NotificationController.getNotifications();
        //SUCCESS
        toastr.success("Notification Deleted");
    }

    //FAIL DELETE NOTIFICATION
    let failDeleteNotification = function () {
        toastr.error("Faled to Delete");
    }

    return {
        getNotifications: getNotifications,
        readNotifications: readNotifications,
        deleteNotification: deleteNotification
    }

}(NotificationService);
