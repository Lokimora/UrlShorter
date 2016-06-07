angular.module("app.controllers", [])
.controller("reduce-controller", ["$scope", "$location", "$http", function ($scope, $location, $http) {
    $scope.message = '';
    $scope.originalUrl = '';
    $scope.isShowUrl = false;

    $scope.reduceUrl = function () {
        var content = {
            originalUrl: $scope.originalUrl
        };


        $http.post("/reducer/create", content).success(function (response) {
            $scope.message = $location.host() + ":" + $location.port() + "/" + response.ShortRelUrl;

        }).error(function (response) {
            $scope.message = "Url не валиден"
        });

    }
}])
.controller("urlList-controller", ["$scope", "$location", "$http", function ($scope, $location, $http) {
    $scope.links = [];

    $http.get("/reducer/getall").success(function (response) {
      
        $scope.links = response;
        angular.forEach($scope.links, function (value, key) {
            value.ShortRelUrl = $location.host() + ":" + $location.port() + "/" + value.ShortRelUrl
        })
    })
}]);