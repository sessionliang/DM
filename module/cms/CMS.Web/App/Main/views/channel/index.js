(function () {
    var controllerId = 'app.views.channel.index';
    angular.module('app').controller(controllerId, [
        'abp.services.app.node', '$scope', '$uibModal', function (nodeService, $scope, $uibModal) {
            var vm = this;

            vm.nodes = [];
            vm.sorting = "taxis asc";

            vm.responseHandler = function (data) {
                abp.ui.clearBusy("#contentTable");
                if (data.success) {
                    return {
                        "rows": data.result.nodes,
                        "total": data.result.totalCount
                    };
                } else {
                    return {
                        "rows": [],
                        "total": 0
                    };
                };
            }

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
                abp.ui.setBusy("#contentTable");
                //$("#contentTable").bootstrapTable({
                //    url: "/api/services/app/node/getNodes",//
                //    sidePagination: "server",
                //    method: "post",
                //    queryParams: function (params) {
                //        params["publishmentSystemId"] = 1;
                //        return params;
                //    },//
                //    queryParamsType: "limit",
                //    pageSize: 3,
                //    pageNumber: 1,
                //    pagination: true,
                //    clickToSelect: true,
                //    sortName: vm.sorting,//
                //    idField: "id",
                //    search: !0,
                //    showRefresh: !0,
                //    showToggle: !0,
                //    showColumns: !0,
                //    toolbar: "#contentTableToolbar",//
                //    iconSize: "outline",
                //    icons: {
                //        refresh: "glyphicon-repeat",
                //        toggle: "glyphicon-list-alt",
                //        columns: "glyphicon-list"
                //    },
                //    responseHandler: vm.responseHandler//
                //});

                abp.ui.createTable(
                    $("#contentTable"),
                    {
                        url: "/api/services/app/node/getNodes",
                        sortName: vm.sorting,
                        toolbar: "#contentTableToolbar"
                    },
                    {
                        publishmentSystemId: 1
                    },
                    vm.responseHandler);

            }
        }
    ]);
})();