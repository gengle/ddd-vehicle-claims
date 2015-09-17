(function(){
    'use strict';

    var app = angular.module('app');

    app.factory('ClaimsMapper', ClaimsMapper);

    ClaimsMapper.$inject = [];

    function ClaimsMapper() {

        var service = {
            mapResponse: mapResponse
        };

        return service;
        
        function mapResponse(claim, response) {

            claim.ClaimNo = response.data.ClaimNo;
            claim.ClaimState = response.data.ClaimState;
            claim.Id = response.data.Id;
            claim.Payout = response.data.Payout;
            claim.PolicyNo = response.data.PolicyNo;
            claim.Routes = response.data.Routes;
            claim.VehicleMake = response.data.VehicleMake;
            claim.VehicleModel = response.data.VehicleModel;
            claim.VehicleYear = response.data.VehicleYear;
            claim.VehicleVIN = response.data.VehicleVin;

        }
    }
})();