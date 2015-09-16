(function() {
    var app = angular.module('app');

    app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/claims/list');

        $stateProvider
            .state('claims.new', {
                url: '/claims/create',
                templateUrl: '/app/ui/claim/create.html'
            })
            .state('claims', {
                url: '/claims/list',
                templateUrl: '/app/ui/claim/list.html',
                controller: 'ClaimsControllerList',
                controllerAs: 'vm'
            })
            .state('claims.mutate', { 
                url: '/claims/mutate',
                templateUrl: '/app/ui/claim/mutate.html'
            });
    }]);
})();