(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsMutateModalController', ClaimsMutateModalController);

    ClaimsMutateModalController.$inject = ['$scope', '$modalInstance', 'options', '$http'];

    function ClaimsMutateModalController($scope, $modalInstance, options) {

        $scope.$modalInstance = $modalInstance;

        initialize();

        function initialize() {
           
        }

        $scope.claim = options.claim;

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }

})();