//myapp.js
(function (app) {
    app.isDebug = true;

    app.log(msg) = function () {
        if (app.isDebug) {
            console.log(msg);
        }
    };
})(window.app = window.app | {});