var app = angular.module("app", ["ngRoute", "app.controllers", "app.directives"]);


app.config(function ($routeProvider) {
    $routeProvider
	.when("/", {
	    templateUrl: "index.html"
	})
	.when("/list", {
	    templateUrl: "/views/list.html"
	})
	.when("/404", {
	    templateUrl: "/views/404.html"
	})
	.otherwise({
	    redirectTo: "/404"
	});
});