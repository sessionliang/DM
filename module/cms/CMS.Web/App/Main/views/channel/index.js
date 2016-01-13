(function () {
    var controllerId = 'app.views.channel.index';
    angular.module('app').controller(controllerId, [
        'abp.services.app.node', '$scope', '$uibModal', function (nodeService, $scope, $uibModal) {
            var vm = this;

            vm.nodes = [];
            vm.sorting = "taxis asc";

            vm.addNode = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: abp.appPath + 'dm/channel/createNode',
                    controllerAs: 'app.views.channel.createNode as vm',
                    size: "md"
                });
                modalInstance.result.then(function () {
                    vm.loadNodes();
                });
            };

            vm.deleteNode = function () {
                abp.notify.success("删除node");
            };

            vm.loadNodes = function () {
                abp.ui.createTable($("#contentTable"),
                    {
                        url: "/api/services/app/node/getNodes",
                        queryParams: function (params) {
                            params["publishmentSystemId"] = 1;
                            return params;
                        },
                        sortName: vm.sorting
                    });
            }
        }
    ]);
})();