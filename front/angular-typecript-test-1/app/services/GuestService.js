var Application;
(function (Application) {
    var Services;
    (function (Services) {
        var GuestService = (function () {
            function GuestService($http) {
                var _this = this;
                this.GetUserPromise = function () {
                    var getPromise = _this.httpService.get("http://localhost:8001/guests")
                        .then(function (result) { return result = result.data.message; });
                    return getPromise;
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
