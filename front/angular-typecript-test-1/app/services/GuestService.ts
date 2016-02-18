module Application.Services {
    export class GuestService implements Application.Interfaces.IUserService {
        httpService: ng.IHttpService
        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.httpService = $http;
        }

        GetUserPromise = () => {
            var getPromise = this.httpService.get("http://localhost:8001/guests")
                .then((result: any) => result = result.data.message);
            return getPromise;
        }
    }

    angular.module("Application").service("Application.Services.GuestService", GuestService);
}