(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsControllerMutate', ClaimsControllerMutate);

    ClaimsControllerMutate.$inject = ['$scope', '$modalInstance', 'options', '$http'];

    function ClaimsControllerMutate($scope, $modalInstance, options) {

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