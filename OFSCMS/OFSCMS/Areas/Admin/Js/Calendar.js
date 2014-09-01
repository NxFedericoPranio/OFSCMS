$(function () {
    $('#Time').timepicker({
        stepMinute: 15,
        hour: 21,
        minute: 0,
        hourMin: 0,
        hourMax: 23
    });

    //$("#Time").attr('disabled', 'disabled');
});


$(function ($) {
    $.datepicker.regional['it'] = {
        closeText: 'Chiudi',
        prevText: '&#x3c;Prec',
        nextText: 'Succ&#x3e;',
        currentText: 'Oggi',
        monthNames: ['Gennaio', 'Febbraio', 'Marzo', 'Aprile', 'Maggio', 'Giugno',
            'Luglio', 'Agosto', 'Settembre', 'Ottobre', 'Novembre', 'Dicembre'],
        monthNamesShort: ['Gen', 'Feb', 'Mar', 'Apr', 'Mag', 'Giu',
            'Lug', 'Ago', 'Set', 'Ott', 'Nov', 'Dic'],
        dayNames: ['Domenica', 'Luned&#236', 'Marted&#236', 'Mercoled&#236', 'Gioved&#236', 'Venerd&#236', 'Sabato'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mer', 'Gio', 'Ven', 'Sab'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Me', 'Gi', 'Ve', 'Sa'],
        weekHeader: 'Sm',
        dateFormat: 'dd-mm-yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['it']);
});

$(function () {
    $("#Date").datepicker();
    $("#Date").datepicker("option",
            $.datepicker.regional['it']);
    $("#Date").datepicker("option", "DateFormat", 'yy/mm/dd');
    //$("#Date").attr('disabled', 'disabled');

});





function checkData() {


    if ($("#Date").val() == '') {
        //alert('Inserire la data');
        //$("#Date").focus();
        //return false;
    } else {
        var fld = $("#Date").val().split('/');
        var d = new Date(fld[0], fld[1] - 1, fld[2]);

        var curr_day = new Date();
        if (!(
            (d.getFullYear() == curr_day.getFullYear() && d.getDay() == curr_day.getDay() && d.getMonth() == curr_day.getMonth())
            || d > curr_day)) {
            alert('Non puoi usare una data antecedente a quella odierna');
            $("#Date").focus();
            return false;
        }
    }

    //if ($("#Time").val() == '') {
    //    alert('Inserire l\'ora');
    //    $("#Time").focus();
    //    return false;
    //}

    return true;

}
