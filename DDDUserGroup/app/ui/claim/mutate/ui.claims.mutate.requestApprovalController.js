(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsControllerMutateRequestingApproval', ClaimsControllerMutateRequestingApproval);

    ClaimsControllerMutateRequestingApproval.$inject = ['$http', '$scope', 'ClaimsCommandFactory', 'ClaimsMapper'];

    function ClaimsControllerMutateRequestingApproval($http, $scope, claimsCommandFactory, claimsMapper) {
        
        $scope.model = { };

        initialize();

        function initialize() {
            console.log('ClaimsControllerMutateRequestingApproval');
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