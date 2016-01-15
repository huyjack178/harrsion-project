module Application.Services {
    export class GuestService implements Application.Interfaces.IUserService {
        httpService: ng.IHttpService
        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.httpService = $http;
        }

        getUser = () => {
            var guests: Array<Application.Interfaces.IUser> =
                [
                    { name: "harrison" },
                    { name: "henry" },
                    { name: "jason" },
                    { name: "anders" }
                ]
            return guests;
        }
    }

    angular.module("Application").service("Application.Services.GuestService", GuestService);
}