(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsControllerList', ClaimsController);

    ClaimsController.$inject = ['$http', '$modal', 'ClaimsCommandFactory'];

    function ClaimsController($http, $modal, claimsCommandFactory) {
        var vm = this;

        initialize();

        function initialize() {
            $http.get('api/claims').then(function (response) {
                console.log('Claims response', response);
                vm.claims = response.data;
            });
        }

        vm.createClaim = function () {
            var command = claimsCommandFactory.create('CreateClaimCommand', {
                id: '',
                policyNo:  Math.random()
            });

            $http.post('/api/commands/execute', command)
                .then(function (response) {
                    console.log('SUCCESS', response);
                }, function (error) {
                    console.log('ERROR', error);
                });
        };

        vm.mutate = function (claim) {
            console.log(claim);

            var modalOptions = {
                templateUrl: '/app/ui/claim/mutate.html',
                controller: 'ClaimsControllerMutate',
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

            return $modal.open(modalOptions);
        };
    }

})();