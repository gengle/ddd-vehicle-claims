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
            controller: ['$scope', '$http', '$modal', 'ClaimsCommandFactory', 'CommonGuidFactory', 'ClaimsMapper', 
                function ($scope, $http, $modal, claimsCommandFactory, commonGuidFactory, claimsMapper) {
                    

                    $scope.createClaim = function () {
                        var claim = {
                            ClaimState: 'Domain.States.NewClaim',
                            Id: commonGuidFactory.create(),
                            Routes: [
                                'CreateClaimCommand'
                            ]
                        };

                        console.log(claim);

                        var modalOptions = {
                            templateUrl: '/app/ui/claim/mutate.html',
                            controller: 'ClaimsMutateModalController',
                            size: 'lg',
                            backdrop: 'static',
                            keyboard: true,
                            resolve: {
                                options: function () {
                                    return {
                                        claim: claim
                                    };
                                }
                            }
                        };

                        $modal.open(modalOptions).result.then(function (response) {
                            if(response && response.result === 'ok')
                                $scope.claims.unshift(response.data);

                            console.log('Modal Result', response);
                        }, function (error) {
                            console.log('Modal Error', error);
                        });
                }
            }]
        }
    }

})();