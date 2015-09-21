(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsMutateModalController', ClaimsMutateModalController);

    ClaimsMutateModalController.$inject = ['$scope', '$modalInstance', '$http', 'options', 'ClaimsCommandFactory', 'ClaimsMapper'];

    function ClaimsMutateModalController($scope, $modalInstance, $http, options, claimsCommandFactory, claimsMapper) {

        $scope.model = {};
        $scope.$modalInstance = $modalInstance;

        initialize();

        function initialize() {
            $scope.claim = options.claim;

            $scope.model.vin = $scope.claim.VehicleVin;
            $scope.model.make = $scope.claim.VehicleMake;
            $scope.model.model = $scope.claim.VehicleModel;
            $scope.model.year = $scope.claim.VehicleYear;
            $scope.model.amount = $scope.claim.Payout;

            console.log('ClaimsMutateModalController Initialized');
        }

        $scope.cancel = function () {
            $modalInstance.dismiss({ result: 'cancel', data: undefined });
        };

        $scope.execute = function (commandType) {
            console.log('sending commandType', commandType);
            console.log('$scope.model.amount', $scope.model.amount);
            console.log('claim', $scope.claim);
            console.log('claim id', $scope.claim.Id);

            $scope.model.id = $scope.claim.Id;
            console.log("model", $scope.model);
            var command = claimsCommandFactory.create(commandType, $scope.model);
            console.log("command", command);

            $http.post('/api/commands/execute', command).then(function (response) {

                if (response && response.data) {
                    claimsMapper.mapResponse($scope.claim, response);
                }

                $modalInstance.close({ result: 'ok', data: $scope.claim });
            }, function (error) {
                console.log('ERROR', error);
                $modalInstance.close({ result: 'error', data: error });
            });
        }
    }

})();