(function(){
    'use strict';

     var app = angular.module('app');

     app.factory('ClaimsCommandFactory', ClaimsCommandFactory);

     ClaimsCommandFactory.$inject = [];

     function ClaimsCommandFactory() {

         var service = {
             create: create
         };

         return service;

         function create(commandType, data) {
             switch (commandType) {
                 case 'ApprovePayoutCommand':
                     return BuildApprovePayoutCommand(data);
                     break;
                 case 'AssignVehicleCommand':
                     return BuildAssignVehicleCommand(data);
                     break;
                 case 'CloseClaimCommand':
                     return BuildCloseClaimCommand(data);
                     break;
                 case 'CreateClaimCommand':
                     return BuildCreateClaimCommand(data);
                     break;
                 case 'RejectPayoutCommand':
                     return BuildRejectPayoutCommand(data);
                     break;
                 case 'ReopenClaimCommand':
                     return BuildReopenClaimCommand(data);
                     break;
                 default:
                     return undefined;
             }
         }

         function BuildApprovePayoutCommand(data) {
             var approvePayoutCommand = {
                 '$type': 'Application.Messaging.Commands.ApprovePayoutCommand, Application',
                 Id: '',
                 Amount: ''
             };

             approvePayoutCommand.Id = data.id;
             approvePayoutCommand.Amount = data.amount;
             return approvePayoutCommand;
         }

         function BuildAssignVehicleCommand(data) {
             var assignVehicleCommand = {
                 '$type': 'Application.Messaging.Commands.AssignVehicleCommand, Application',
                 Id: '',
                 Vehicle: {
                     Make: '',
                     Model: '',
                     Year: '',
                     VIN: ''
                 }
             };

             assignVehicleCommand.Id = data.id;
             assignVehicleCommand.Make = data.make;
             assignVehicleCommand.Model = data.model;
             assignVehicleCommand.Year = data.year;
             assignVehicleCommand.Vin = data.vin;
             return assignVehicleCommand;
         }

         function BuildCloseClaimCommand(data) {
             var closeClaimCommand = {
                 '$type': 'Application.Messaging.Commands.CloseClaimCommand, Application',
                 Id: ''
             };

             closeClaimCommand.Id = data.id;
             return closeClaimCommand;
         }

         function BuildCreateClaimCommand(data) {
             var createClaimCommand = {
                 '$type': 'Application.Messaging.Commands.CreateClaimCommand, Application',
                 Id: '',
                 PolicyNo: ''
             };

             createClaimCommand.Id = data.id;
             createClaimCommand.PolicyNo = data.policyNo;
             return createClaimCommand;
         }

         function BuildRejectPayoutCommand(data) {
             var rejectPayoutCommand = {
                 '$type': 'Application.Messaging.Commands.RejectPayoutCommand, Application',
                 Id: ''
             };

             rejectPayoutCommand.Id = data.id;
             return rejectPayoutCommand;
         }

         function BuildReopenClaimCommand(data) {
             var reopenClaimCommand = {
                 '$type': 'Application.Messaging.Commands.ReopenClaimCommand, Application',
                 Id: ''
             };

             reopenClaimCommand.Id = data.id;
             return reopenClaimCommand;
         }
    }
})();