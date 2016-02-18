var Application;
(function (Application) {
    var Controllers;
    (function (Controllers) {
        var GuestController = (function () {
            function GuestController(guestService) {
                var _this = this;
                this.initialize = function () {
                    _this._guestService.GetUserPromise().then(function (result) {
                    });
                };
                this._guestService = guestService;
            }
            GuestController.$inject = ["Application.Services.GuestService"];
            return GuestController;
        })();
        Controllers.GuestController = GuestController;
        angular.module("Application").controller("Application.Controllers.GuestController", GuestController);
    })(Controllers = Application.Controllers || (Application.Controllers = {}));
})(Application || (Application = {}));
