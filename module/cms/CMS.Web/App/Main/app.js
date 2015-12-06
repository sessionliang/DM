(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in CMSNavigationProvider
                })
                .state('channel', {
                    url: '/channel',
                    templateUrl: '/App/Main/views/channel/channel.cshtml',
                    menu: 'Channel' //Matches to name of 'Channel' menu in CMSNavigationProvider
                })
                .state('content', {
                    url: '/content',
                    templateUrl: '/App/Main/views/content/content.cshtml',
                    menu: 'Content'
                })
                .state('template', {
                    url: '/template',
                    templateUrl: '/App/Main/views/template/template.cshtml',
                    menu: 'Template'
                })
                .state('create', {
                    url: 'create',
                    templateUrl: '/App/Main/views/create/create.cshtml',
                    menu: 'Create'
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in CMSNavigationProvider
                });
        }
    ]);
})();