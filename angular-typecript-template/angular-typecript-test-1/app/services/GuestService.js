var Application;
(function (Application) {
    var Services;
    (function (Services) {
        var GuestService = (function () {
            function GuestService($http) {
                this.getUser = function () {
                    var guests = [
                        { name: "harrison" },
                        { name: "henry" },
                        { name: "jason" },
                        { name: "anders" }
                    ];
                    return guests;
                };
                this.httpService = $http;
            }
            GuestService.$inject = ["$http"];
            return GuestService;
        })();
        Services.GuestService = GuestService;
        angular.module("Application").service("Application.Services.GuestService", GuestService);
    })(Services = Application.Services || (Application.Services = {}));
})(Application || (Application = {}));
//# sourceMappingURL=GuestService.js.map