(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsControllerMutate', ClaimsControllerMutate);

    ClaimsControllerMutate.$inject = ['$http', '$scope', 'ClaimsCommandFactory', 'ClaimsMapper'];

    function ClaimsControllerMutate($http, $scope, claimsCommandFactory, claimsMapper) {
        
        $scope.model = { };

        initialize();

        function initialize() {

            $scope.model.vin = $scope.$parent.claim.VehicleVin;
            $scope.model.make = $scope.$parent.claim.VehicleMake;
            $scope.model.model = $scope.$parent.claim.VehicleModel;
            $scope.model.year = $scope.$parent.claim.VehicleYear;

            console.log('ClaimsControllerMutate Initialized');
        }

        $scope.execute = function (commandType) {
            console.log('sending commandType', commandType);
            console.log('$scope.model.amount', $scope.model.amount);
            console.log('claim', $scope.$parent.claim);
            console.log('claim id', $scope.$parent.claim.Id);

            $scope.model.id = $scope.$parent.claim.Id;
            console.log("model", $scope.model);
            var command = claimsCommandFactory.create(commandType, $scope.model);
            console.log("command", command);

            $http.post('/api/commands/execute', command).then(function (response) {
                
                if (response && response.data) {
                    claimsMapper.mapResponse($scope.$parent.claim, response);
                }

                $scope.$parent.$modalInstance.close('ok');
            }, function (error) {
                console.log('ERROR', error);
                $scope.$parent.$modalInstance.close('ok');
            });
        }
    }
})();