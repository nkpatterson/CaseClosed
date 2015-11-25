angular.module('caseclosed', [])
    .config(function ($httpProvider) {
        $httpProvider.defaults.useXDomain = true;
        $httpProvider.defaults.withCredentials = true;
        delete $httpProvider.defaults.headers.common["X-Requested-With"];
        $httpProvider.defaults.headers.common["Accept"] = "application/json";
        $httpProvider.defaults.headers.common["Content-Type"] = "application/json";
    })
    .service('appConfig', function ($http, $q) {
        var self = this;
        this.getConfig = function () {
            var deferred = $q.defer();
            $http.get('https://localhost:44301/api/appconfig').then(function (result) {
                var config = result.data;
                config.IsBetaAvailable = config.BetaUrl != null && config.BetaUrl != window.location.host;
                deferred.resolve(config);
            });

            return deferred.promise;
        };
    })
    .controller('layoutController', function ($scope, appConfig) {
        appConfig.getConfig().then(function (config) {
            $scope.config = config;
        });
    });