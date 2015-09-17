(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsMapper', ClaimsMapper);

    ClaimsMapper.$inject = [];

    function ClaimsMapper() {

        var service = {
            mapResponse: mapResponse
        };

        return service;
        
        function mapResponse(claim, response) {
             // todo: build this out
        }
    }
})();