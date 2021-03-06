var Application;
(function (Application) {
    var Controllers;
    (function (Controllers) {
        var GuestController = (function () {
            function GuestController(guestService) {
                var _this = this;
                this.initialize = function () {
                    _this.guests = _this._guestService.getUser();
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
//# sourceMappingURL=GuestController.js.map