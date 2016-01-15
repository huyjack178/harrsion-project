'use strict';
angular.module('myApp', [
    'ngRoute',
    'myApp.guest'
]).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({ redirectTo: '/guest' });
    }]);
