module Application.Guest {
	export class GuestController {
		scope: any;
		data: any;
		

		constructor($scope: ng.IScope){
			this.scope = $scope;
		}

		GetData(){
			return this.data;
		}
	}
}