/// <reference path="jquery/jquery.d.ts"/>
/// <reference path="jquery.ui.datetimepicker/jquery.ui.datetimepicker.d.ts"/>
var Greeter = (function () {
    function Greeter(greeting) {
        this.greeting = greeting;
        $('#datetimepicker').datetimepicker({
            dateFormat: "yy-mm-dd",
            timeFormat: 'HH:mm',
            nextText: "",
            prevText: ""
        });
    }
    Greeter.prototype.greet = function () {
        return "<h1>" + this.greeting + "</h1>";
    };

    Greeter.prototype.greet2 = function (message) {
        return "<h1>" + message + "<br/>" + this.greeting + "</h1>";
    };

    Greeter.prototype.alertMessage = function () {
        alert("<h1>" + this.greeting + "</h1>");
    };
    return Greeter;
})();
;
var greeter = new Greeter("Hello, world!");
var str = greeter.greet();
document.body.innerHTML = str;
