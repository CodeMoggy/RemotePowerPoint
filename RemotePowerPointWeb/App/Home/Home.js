/// <reference path="../App.js" />
/// <reference path="C:\Users\ricustan\Source\Repos\SandBox-RC-O365\O365\Contextual\RemotePowerPoint\RemotePowerPointWeb\Scripts/jquery.signalR-2.2.0.js" />

(function () {
    "use strict";

    // The initialize function must be run each time a new page is loaded
    Office.initialize = function (reason) {
        $(document).ready(function () {
            app.initialize();
        });
    };

    var proxy = null;
    var clientId = null;

    initialize();

    function initialize() {

        // connect to hub
        var connection = $.hubConnection();
        proxy = connection.createHubProxy('slider');

        proxy.on('connected', function (connectionId) {
            clientId = connectionId
            $('#message').text("Copy the uid below to your remote app to connect to this slide deck.")
            app.showNotification(connectionId);
        });

        proxy.on('next', goToNextSlide);
        proxy.on('previous', goToPreviousSlide);
        proxy.on('first', goToFirstSlide);
        proxy.on('last', goToLastSlide);

        connection.start()
            .done(function(){ console.log('Now connected, connection ID=' + connection.id); })
            .fail(function(){ console.log('Could not Connect!'); });
    };

    function goToNextSlide() {
        Office.context.document.goToByIdAsync(Office.Index.Next, Office.GoToType.Index, callback);
    }

    function goToPreviousSlide() {
        Office.context.document.goToByIdAsync(Office.Index.Previous, Office.GoToType.Index, callback);
    }

    function goToFirstSlide() {
        Office.context.document.goToByIdAsync(Office.Index.First, Office.GoToType.Index, callback);
    }

    function goToLastSlide() {
        Office.context.document.goToByIdAsync(Office.Index.Last, Office.GoToType.Index, callback);
    }

    function callback(asyncResult) {

        if (asyncResult.status == "failed") {
            app.showNotification("Action failed with error: " + asyncResult.error.message);
        }
        else {
            app.showNotification("Navigation successful");
            $('#message').text("Presenting...");
        }
    }

})();