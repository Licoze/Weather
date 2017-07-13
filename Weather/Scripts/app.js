
    var weatherApp = angular.module('weatherApp', []);
    weatherApp.controller("searchController",
        function($scope) {
            var citiesManager = new CitiesManager();
            $scope.days = [1, 3, 5];
            $scope.cities = citiesManager.get();
            $scope.SelectCity = function($index) {
                $scope.selectedCity = $scope.cities[$index];
            }
            $scope.DeleteCity=function($index) {
                $scope.cities.splice($index, 1);
                citiesManager.set($scope.cities);
            }
            $scope.SubmitSearch = function () {
                if ($scope.selectedCity !== undefined) {
                    $("form").submit();
                    if ($.inArray($scope.selectedCity, $scope.cities) === -1) {
                        $scope.cities.push($scope.selectedCity);
                        citiesManager.set($scope.cities);
                    }
                }
                
            }

        });

        function CitiesManager() {
            this.get = function() {
                var cookies = Cookies.getJSON("cities");
                if (cookies !== undefined)
                    return cookies;
                cookies = Cookies.set("cities",
                    [
                        "Dnipropetrovsk",
                        "Kiev",
                        "Lviv",
                        "Kharkiv",
                        "Odessa"
                    ], { expires: 365 });
                return cookies;
            }
            this.set = function(value) {
                Cookies.set("cities", value, { expires: 365 });
            }

        }

    

