'use strict'

var guestModule = angular.module('myApp.guest', ['ngRoute'])
.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/guest', {
    templateUrl: 'guest/guest.html',
    controller: 'GuestCtrl'
  });
}])

guestModule.controller("GuestCtrl", ["$scope", ($scope)
	=> new Application.Guest.GuestController($scope)]);
