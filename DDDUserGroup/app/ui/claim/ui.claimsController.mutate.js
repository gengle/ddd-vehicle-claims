(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsControllerMutate', ClaimsControllerMutate);

    app.$inject = ['$scope', '$modalInstance', 'options', '$http'];

    function ClaimsControllerMutate($scope, $modalInstance, options) {

        initialize();

        function initialize() {
           
        }

        $scope.claim = options.claim;

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        $scope.sendCommand = function (command) {
            console.log('sending command', command);
            //$http.post()
            $modalInstance.close('ok');
        };
    }

})();