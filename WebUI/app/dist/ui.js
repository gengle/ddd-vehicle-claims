(function () {
    'use strict';

    var app = angular.module('app', [
        'ui.router',
        'ui.bootstrap'
    ]);
})();;(function(){
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
})();;(function(){
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
            claim.VehicleVin = response.data.VehicleVin;

        }
    }
})();;(function(){
    'use strict';

    var app = angular.module('app');

    app.directive('createClaim', createClaim);

    createClaim.$inject = [];

    function createClaim() {
        return {
            templateUrl: '/app/ui/claim/directives/create.html',
            restrict: 'E',
            scope: {
                claims: "="
            },
            controller: ['$scope', '$http', '$modal', 'ClaimsCommandFactory', 'CommonGuidFactory', 'ClaimsMapper', 
                function ($scope, $http, $modal, claimsCommandFactory, commonGuidFactory, claimsMapper) {
                    

                    $scope.createClaim = function () {
                        var claim = {
                            ClaimState: 'NewClaim',
                            Id: commonGuidFactory.create(),
                            Routes: [
                                'CreateClaimCommand'
                            ]
                        };

                        console.log(claim);

                        var modalOptions = {
                            templateUrl: '/app/ui/claim/mutate.html',
                            controller: 'ClaimsMutateModalController',
                            size: 'lg',
                            backdrop: 'static',
                            keyboard: true,
                            resolve: {
                                options: function () {
                                    return {
                                        claim: claim
                                    };
                                }
                            }
                        };

                        $modal.open(modalOptions).result.then(function (response) {
                            if(response && response.result === 'ok')
                                $scope.claims.unshift(response.data);

                            console.log('Modal Result', response);
                        }, function (error) {
                            console.log('Modal Error', error);
                        });
                }
            }]
        }
    }

})();;(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsControllerList', ClaimsController);

    ClaimsController.$inject = ['$http', '$modal'];

    function ClaimsController($http, $modal) {
        var vm = this;

        initialize();

        function initialize() {
            $http.get('api/claims').then(function (response) {
                console.log('Claims response', response);
                vm.claims = response.data;
            });
        }

        vm.mutate = function (claim) {
            console.log(claim);

            var modalOptions = {
                templateUrl: '/app/ui/claim/mutate.html',
                controller: 'ClaimsMutateModalController',
                size: 'lg',
                backdrop: 'static',
                keyboard: true,
                resolve: {
                    options: function () {
                        return {
                            claim: claim
                        };
                    }
                }
            };

            return $modal.open(modalOptions);
        };
    }

})();;(function(){
    'use strict';

    var app = angular.module('app');

    app.controller('ClaimsMutateModalController', ClaimsMutateModalController);

    ClaimsMutateModalController.$inject = ['$scope', '$modalInstance', '$http', 'options', 'ClaimsCommandFactory', 'ClaimsMapper'];

    function ClaimsMutateModalController($scope, $modalInstance, $http, options, claimsCommandFactory, claimsMapper) {

        $scope.model = {};
        $scope.$modalInstance = $modalInstance;

        initialize();

        function initialize() {
            $scope.claim = options.claim;

            $scope.model.vin = $scope.claim.VehicleVin;
            $scope.model.make = $scope.claim.VehicleMake;
            $scope.model.model = $scope.claim.VehicleModel;
            $scope.model.year = $scope.claim.VehicleYear;
            $scope.model.amount = $scope.claim.Payout;

            console.log('ClaimsMutateModalController Initialized');
        }

        $scope.cancel = function () {
            $modalInstance.dismiss({ result: 'cancel', data: undefined });
        };

        $scope.execute = function (commandType) {
            console.log('sending commandType', commandType);
            console.log('$scope.model.amount', $scope.model.amount);
            console.log('claim', $scope.claim);
            console.log('claim id', $scope.claim.Id);

            $scope.model.id = $scope.claim.Id;
            console.log("model", $scope.model);
            var command = claimsCommandFactory.create(commandType, $scope.model);
            console.log("command", command);

            $http.post('/api/commands/execute', command).then(function (response) {

                if (response && response.data) {
                    claimsMapper.mapResponse($scope.claim, response);
                }

                $modalInstance.close({ result: 'ok', data: $scope.claim });
            }, function (error) {
                console.log('ERROR', error);
                $modalInstance.close({ result: 'error', data: error });
            });
        }
    }

})();;(function(){
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
})();;(function() {
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
//# sourceMappingURL=ui.js.map