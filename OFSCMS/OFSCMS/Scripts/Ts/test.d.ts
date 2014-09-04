/// <reference path="jquery/jquery.d.ts" />
/// <reference path="jquery.ui.datetimepicker/jquery.ui.datetimepicker.d.ts" />
declare class Greeter {
    public greeting: string;
    constructor(greeting: string);
    public greet(): string;
    public greet2(message: any): string;
    public alertMessage(): void;
}
declare var greeter: Greeter;
declare var str: string;
