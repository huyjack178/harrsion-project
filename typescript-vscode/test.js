var Test;
(function (Test) {
    var Startup = (function () {
        function Startup() {
        }
        Startup.main = function () {
            console.log('hello world');
            return 0;
        };
        return Startup;
    })();
})(Test || (Test = {}));
//# sourceMappingURL=test.js.map