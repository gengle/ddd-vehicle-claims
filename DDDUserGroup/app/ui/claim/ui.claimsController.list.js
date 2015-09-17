﻿(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsControllerList', ClaimsController);

    ClaimsController.$inject = ['$http', '$modal', 'ClaimsCommandFactory', 'CommonGuidFactory', 'ClaimsMapper'];

    function ClaimsController($http, $modal, claimsCommandFactory, commonGuidFactory, claimsMapper) {
        var vm = this;

        initialize();

        function initialize() {
            $http.get('api/claims').then(function (response) {
                console.log('Claims response', response);
                vm.claims = response.data;
            });
        }

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