(function(){
    'use strict';

    var app = angular.module('app');

    app.factory('CommonGuidFactory', CommonGuidFactory);

    CommonGuidFactory.$inject = [];

    function CommonGuidFactory() {
        var service = {
            create: create,
            createEmpty: createEmpty
        };

        return service;

        function create(empty) {
            return guid(empty);
        }

        function createEmpty() {
            return guid('empty');
        }

        function guid(empty) {
            if (empty) {
                return '00000000-0000-0000-0000-000000000000';
            }

            return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
                s4() + '-' + s4() + s4() + s4();
        }

        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
                .toString(16)
                .substring(1);
        }
    }
})();