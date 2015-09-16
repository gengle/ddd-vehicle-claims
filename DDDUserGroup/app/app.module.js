(function () {
    'use strict';

    var app = angular.module('app', [
        'ui.router',
        'ui.bootstrap'
    ]);

    app.run(['$state', function ($state) {
        //initialize state
        //$state.transitionTo('home');
    }]);
})();