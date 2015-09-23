(function() {
    var app = angular.module('app');

    app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/claims/list');

        $stateProvider
            .state('claims', {
                url: '/claims/list',
                templateUrl: '/app/ui/claim/list.html',
                controller: 'ClaimsControllerList',
                controllerAs: 'vm'
            });
    }]);
})();