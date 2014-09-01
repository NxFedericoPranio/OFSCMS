'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('ofsApp.controllers', ['myServices'])


.controller('PageController', ['$scope', '$rootScope', '$routeParams', '$http', function ($scope, $rootScope, $routeParams, $http) {
    var getPage = function (id) {
        $http.get('Home/PageAjax/' + id).success(function (data) {
            $scope.Title = data.Title;
            $scope.Content = data.Content;
        }).
        error(function (data, status) {
            alert((data || 'Request failed') + '\r\n' + status);
        });
    }

    getPage($routeParams.id);
}])

.controller('PhotoAlbumController', ['$scope', '$rootScope', '$routeParams', '$http', 'photoAlbum', function ($scope, $rootScope, $routeParams, $http, photoAlbum) {
    var getAlbum = function (id, page) {
        $scope.photoAlbum = photoAlbum;
        
        $http.get('Photo/GalleryAjax?Name=' + id + '&Page=' + page).success(function (data) {
            $scope.data = data;
            var pageSize = 12;
            var range = [];
            for (var i = 0; i < data.TotalCount/pageSize; i++) {
                range.push(i);
            }
            $scope.range = range;
        }).
        
        error(function (data, status) {
            alert((data || 'Request failed') + '\r\n' + status);
        });

        $scope.setImage = function (img) {
            ShowPic(img);
        }


        function ShowPic(pic) {
            $("#ImgGallery")[0].src = 'Public/Gallery/' + pic.GalleryName + '/' + pic.FileName;
            $("#ImageDescription").text(pic.Description);
            $("#selectedImage").val(pic.Index);
            $("#PopupImageWrapper").show();
            $("#ImgGallery").hide();
            $("#WaitPanel").show();
            $("#PopupImage").attr('disabled', 'disabled');
            return false;
        }

        
    }

    var getGalleries = function () {
        $http.get('Photo/GalleryListAjax').success(function (data) {
            $scope.galleries = data;
        }).
        error(function (data, status) {
            alert((data || 'Request failed') + '\r\n' + status);
        });
    }


    var qStrinSlideShow = 'isSlideshow';

    function checkSlideShow() {
        if (getParameterByName(qStrinSlideShow) == "true") {
            $("#ImgGallery")[0].src = $("#thumbnails img")[0].href;
            $("#ImageDescription").text($("#thumbnails img")[0].attributes["desc"].value);
            $("#selectedImage").val(0);
            $("#PopupImageWrapper").show();
            $("#ImgGallery").hide();
            $("#WaitPanel").show();
            $("#PopupImage").attr('disabled', 'disabled');
            $('#chkSlideShow').prop('checked', true);
            $('#chkSlideShow').attr('checked', true);
            //maxIndex $("#thumbnails img")[0]
            setSlideShow();

        } else {
            $("#PopupImageWrapper").hide();
        }
    }
    
    getGalleries();
    getAlbum($routeParams.id, $routeParams.page);
    checkSlideShow();
}])


//// Gets executed after the injector is created and are used to kickstart the application. Only instances and constants
//// can be injected here. This is to prevent further system configuration during application run time.
//.run(['$templateCache', '$rootScope', '$state', '$stateParams', function ($templateCache, $rootScope, $state, $stateParams) {

//    // <ui-view> contains a pre-rendered template for the current view
//    // caching it will prevent a round-trip to a server at the first page load
//    var view = angular.element('#ui-view');
//    $templateCache.put(view.data('tmpl-url'), view.html());

//    // Allows to retrieve UI Router state information from inside templates
//    $rootScope.$state = $state;
//    $rootScope.$stateParams = $stateParams;

//    $rootScope.$on('$stateChangeSuccess', function (event, toState) {

//        // Sets the layout name, which can be used to display different layouts (header, footer etc.)
//        // based on which page the user is located
//        $rootScope.layout = toState.layout;
//    });
//}])
;