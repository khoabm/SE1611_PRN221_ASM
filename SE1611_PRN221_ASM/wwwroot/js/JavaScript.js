
////const connection = new signalR.HubConnectionBuilder()
////    .withUrl("/notificationHub")
////    .build();

////try {
////    connection.on("NotifyOrderStatusChanged", function (orderId) {
////        console.log(orderId);
////        // Update the user interface to reflect the new order status
////    });
////} catch (err) {
////    console.error("Error adding event listener:", err.toString());
////}

////try {
////    connection.start().then(function () {
////        console.log("Connected to SignalR hub.");
////    }).catch(function (err) {
////        console.error("Error connecting to SignalR hub:", err.toString());
////    });
////} catch (err) {
////    console.error("Error starting SignalR connection:", err.toString());
////}


//const connection = new signalR.HubConnectionBuilder()
//    .withUrl("/notificationHub")
//    .build();

//try {
//    connection.on("Receive Message", function (orderId) {
//        console.log(orderId);
//        // Update the user interface to reflect the new order status
//    });
//} catch (err) {
//    console.error("Error adding event listener:", err.toString());
//}

//try {
//    connection.start().then(function () {
//        console.log("Connected to SignalR hub.");
//    }).catch(function (err) {
//        console.error("Error connecting to SignalR hub:", err.toString());
//    });
//} catch (err) {
//    console.error("Error starting SignalR connection:", err.toString());
//}