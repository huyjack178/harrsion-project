var Application;
(function (Application) {
    var Guest;
    (function (Guest) {
        var GuestController = (function () {
            function GuestController($scope) {
                this.scope = $scope;
            }
            GuestController.prototype.GetData = function () {
                return this.data;
            };
            return GuestController;
        })();
        Guest.GuestController = GuestController;
    })(Guest = Application.Guest || (Application.Guest = {}));
})(Application || (Application = {}));
