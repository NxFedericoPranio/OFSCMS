angular.module('myServices', [])

.service('photoAlbum', function () {
    var minIndex = 0;

    

    var refreshIntervalId;
    //chiusura al click sulla parte scura
    $("#thumbnails img").click(function () {
        ShowPic(__this);
    });

    function ShowPic(__this) {
        //$("#PopupImage").html("<img src='" + this.href + "'>");
        $("#ImgGallery")[0].src = __this.href;
        $("#ImageDescription").text(__this.attributes["desc"].value);
        $("#selectedImage").val(__this.attributes["index"].value);
        $("#PopupImageWrapper").show();
        $("#ImgGallery").hide();
        $("#WaitPanel").show();
        $("#PopupImage").attr('disabled', 'disabled');
        return false;
    }

    $("#ImgGallery").load(function () {
        if ($("#ImgGallery")[0].src != "#") {
            $('#PopupImage').removeAttr('disabled');
            $("#WaitPanel").hide();
            //alert('pippo');
            $("#ImgGallery").show();
        }

    });

    $("#arrowLeft").click(function () {
        var elem = getPreviousImage(selectedImage);
        if (elem != null) {
            $("#ImgGallery").fadeTo("slow", 0, function () {
                $("#ImgGallery")[0].src = elem.attributes["href"].value;
                $("#ImageDescription").text(elem.attributes["desc"].value);
                $("#PopupImageWrapper").show();
                $("#ImgGallery").hide();
                $("#WaitPanel").show();
                $("#PopupImage").attr('disabled', 'disabled');

                $("#ImgGallery").load(function () {
                    if ($("#ImgGallery")[0].src != "#") {
                        $('#PopupImage').removeAttr('disabled');
                        $("#WaitPanel").hide();
                        //alert('pippo');
                        //$("#ImgGallery").show();
                        $("#ImgGallery").fadeTo("slow", 1);
                    }

                });

            });
        }
    });


    $('#chkSlideShow').click(function () {
        setSlideShow();
    });

    $("#arrowRight").click(function () {
        var elem = getNextImage(selectedImage);
        if (elem != null) {
            $("#ImgGallery").fadeTo("slow", 0, function () {

                $("#ImgGallery")[0].src = elem.attributes["href"].value;
                $("#ImageDescription").text(elem.attributes["desc"].value);
                $("#PopupImageWrapper").show();
                $("#ImgGallery").hide();
                $("#WaitPanel").show();
                $("#PopupImage").attr('disabled', 'disabled');

                $("#ImgGallery").load(function () {
                    if ($("#ImgGallery")[0].src != "#") {
                        $('#PopupImage').removeAttr('disabled');
                        $("#WaitPanel").hide();
                        //alert('pippo');
                        //$("#ImgGallery").show();
                        $("#ImgGallery").fadeTo("slow", 1);
                    }

                });
            });
        }
    });

    function nextPage() {
        var values = location.hash.split('/');
        var page = values[3];
        var newPage = page + 1;
        var totPages = $("#hdnTotalPages").val();
        if (parseInt(page) >= parseInt(totPages - 1)) {
            window.location = window.location.href.replace('/' + page + '/', '/0/');
            return;
        }
        window.location = window.location.href.replace('/' + page + '/', '/' + (page + 1) + '/');
    }

    function prevPage() {
        var values = location.hash.split('/');
        var page = values[3];
        var newPage = page - 1;
        if (newPage >= 0)           
            window.location = window.location.href.replace('/' + page + '/', '/' + (page + 1) + '/');
    }

    function getNextImage(actualIndex) {
        if (actualIndex.value >= $("#thumbnails img").length - 1) {
            nextPage();
        }
        for (i = 0; i < $("#thumbnails img").length ; i++) {
            if ($("#thumbnails img")[i].attributes["index"].value == actualIndex.value) {
                if ($("#thumbnails img")[i + 1] != null)
                    $("#selectedImage").val(i + 1);
                return $("#thumbnails img")[i + 1];
            }
        }
        $("#selectedImage").val(i + 1);
    }

    function getPreviousImage(actualIndex) {
        if (actualIndex.value < 0) {
            return null;
        }
        for (i = 0; i < $("#thumbnails img").length; i++) {
            if ($("#thumbnails img")[i].attributes["index"].value == actualIndex.value) {
                if ($("#thumbnails img")[i - 1] != null)
                    $("#selectedImage").val(i - 1);
                return $("#thumbnails img")[i - 1];
            }
        }
        $("#selectedImage").val(i - 1);
    }

    function setSlideShow() {
        if ($('#chkSlideShow').attr('checked') == "checked") {
            refreshIntervalId = setInterval(function () {
                slideShow()
            }, 10000);
        } else {
            clearInterval(refreshIntervalId);
        }
    }

    function slideShow() {
        var elem = getNextImage(selectedImage);
        if (elem != null) {
            $("#ImgGallery").fadeTo("slow", 0, function () {
                $("#ImgGallery")[0].src = elem.attributes["href"].value;
                $("#ImageDescription").text(elem.attributes["desc"].value);
                $("#PopupImageWrapper").show();
                $("#ImgGallery").hide();
                $("#WaitPanel").show();
                $("#PopupImage").attr('disabled', 'disabled');

                $("#ImgGallery").load(function () {
                    if ($("#ImgGallery")[0].src != "#") {
                        $('#PopupImage').removeAttr('disabled');
                        $("#WaitPanel").hide();
                        //alert('pippo');
                        //$("#ImgGallery").show();
                        $("#ImgGallery").fadeTo("slow", 1);
                    }

                });
            });

        }
    }



    //chiusura al click sul pulsante
    $("#close").click(function () {
        $("#PopupImageWrapper").hide();

        clearInterval(refreshIntervalId);
    });

    $("#SelectGallery").change(function () {
        window.location = "#gallery/album/" + $("#SelectGallery")[0].selectedOptions[0].innerText + "/0";
    });

    return 'ciao';
});


