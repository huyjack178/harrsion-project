module Application.Interfaces {
    export interface IUserService {
        GetUserPromise: () => ng.IPromise<any>
    }

    export interface IUser {
        name: string;
    }
}