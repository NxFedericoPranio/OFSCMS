var modulo = angular.module('ofsApp', ['ngRoute', 'ngResource', 'ui.bootstrap', 'ngAnimate', 'ngSanitize', 'ofsApp.controllers']);


//Registrazione delle rotte
modulo.config(function ($routeProvider) {

    $routeProvider.when('/home/pages/:id',
                      { templateUrl: 'Templates/page.html', controller: "PageController" });

    $routeProvider.when('/home/',
                 { redirectTo: '/home/pages/1' });

    $routeProvider.when('/',
                 { redirectTo: '/home/pages/1' });

    $routeProvider.when('/gallery/album/:id/:page',
                      { templateUrl: 'Templates/photoAlbum.html', controller: "PhotoAlbumController" });

    $routeProvider.when('/gallery/album/:id',
                     { redirectTo: '/gallery/album/:id/0' });

    $routeProvider.when('/gallery/album/',
                     { redirectTo: '/gallery/album/io' });
    
    //$routeProvider.otherwise({ redirectTo: '/home/pages/1' });
});





