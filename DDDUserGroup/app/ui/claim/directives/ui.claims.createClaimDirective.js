(function(){
    'use strict';

    var app = angular.module('app');

    app.directive('createClaim', createClaim);

    createClaim.$inject = [];

    function createClaim() {
        return {
            templateUrl: '/app/ui/claim/directives/create.html',
            restrict: 'E',
            scope: {
                claims: "="
            },
            controller: ['$scope', '$http', 'ClaimsCommandFactory', 'CommonGuidFactory', 'ClaimsMapper', 
                function ($scope, $http, claimsCommandFactory, commonGuidFactory, claimsMapper) {

                $scope.createClaim = function () {
                    var command = claimsCommandFactory.create('CreateClaimCommand', {
                        id: commonGuidFactory.create(),
                        policyNo: ''
                    });

                    $http.post('/api/commands/execute', command)
                        .then(function (response) {
                            console.log('SUCCESS', response);
                            var claim = {};

                            if (response && response.data) {
                                claimsMapper.mapResponse(claim, response);
                                $scope.claims.push(claim);
                            }

                        }, function (error) {
                            console.log('ERROR', error);
                        });
                }
            }]
        }
    }

})();