/// <reference path="jquery/jquery.d.ts"/>
/// <reference path="jquery.ui.datetimepicker/jquery.ui.datetimepicker.d.ts"/>

class Greeter {
    constructor(public greeting: string) {
        $('#datetimepicker').datetimepicker({
            dateFormat: "yy-mm-dd",
            timeFormat: 'HH:mm',
            nextText: "",
            prevText: ""
        });

    }

    greet() {
        return "<h1>" + this.greeting + "</h1>";
    }
    
    greet2(message) {
        return "<h1>"+ message + "<br/>" + this.greeting + "</h1>";
    }

    alertMessage() {
        alert("<h1>" + this.greeting + "</h1>");
    }


};
var greeter = new Greeter("Hello, world!");
var str = greeter.greet();
document.body.innerHTML = str;