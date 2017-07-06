var weatherApp = angular.module('weatherApp', []);
weatherApp.controller("cityController",
    function($scope) {
        $scope.cities = [
            "Dnipropetrovsk", //Сервис не определяет Dnipro правильно, поэтому так
            "Kiev",
            "Lviv",
            "Kharkiv",
            "Odessa"
        ];
        $scope.SelectCity = function($index) {
            $scope.selectedCity = $scope.cities[$index];
        }
    });
weatherApp.controller("daysController", function ($scope) {
    $scope.days = [1, 3, 5];
})