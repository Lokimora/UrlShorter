angular.module("app.controllers", [])
.controller("reduce-controller", ["$scope", "$http", function($scope, $http){
	$scope.infoBox = '';
	$scope.originalUrl = '';

	$scope.reduceUrl = function(){
		var content = {
			url: $scope.originalUrl
		};


		$http.post("http://localhost:54601/reducer/create", {url: $scope.originalUrl}).success(function (answ) {
                    $scope.response=answ;
                     
                });

	}
}])