(function (o) {
    var controllerId = 'app.views.channels.index';
    angular.module('app').controller(controllerId, [
        'abp.services.app.node', '$scope', function (nodeService, $scope) {
            var vm = this;

            vm.nodes = [];
            vm.sorting = "taxis asc";

            vm.loadNodes = function (append) {
                var skipCount = append ? vm.nodes.length : 0;
                abp.ui.setBusy(
                    null,
                    nodeService.getNodes({
                        publishmentSystemId: 1,
                        offeset: skipCount,
                        sorting: vm.sorting
                    }).success(function (data) {
                        if (append) {
                            for (var i = 0; i < data.nodes.length; i++) {
                                vm.nodes.push(data.nodes[i]);
                            }
                        }
                        else {
                            vm.nodes = data.nodes;
                        }
                        $("#contentTable").bootstrapTable({
                            data: vm.nodes,
                            search: !0,
                            showRefresh: !0,
                            showToggle: !0,
                            showColumns: !0,
                            toolbar: "#contentTableToolbar",
                            iconSize: "outline",
                            icons: {
                                refresh: "glyphicon-repeat",
                                toggle: "glyphicon-list-alt",
                                columns: "glyphicon-list"
                            }
                        });
                    }));
            }

            vm.loadNodes();

            //初始化数据
            vm.init = function () {
                var e = o("#examplebtTableEventsResult");
                o("#exampleTableEvents").on("all.bs.table", function (e, t, o) {
                    console.log("Event:", t, ", data:", o)
                }).on("click-row.bs.table", function () {
                    e.text("Event: click-row.bs.table")
                }).on("dbl-click-row.bs.table", function () {
                    e.text("Event: dbl-click-row.bs.table")
                }).on("sort.bs.table", function () {
                    e.text("Event: sort.bs.table")
                }).on("check.bs.table", function () {
                    e.text("Event: check.bs.table")
                }).on("uncheck.bs.table", function () {
                    e.text("Event: uncheck.bs.table")
                }).on("check-all.bs.table", function () {
                    e.text("Event: check-all.bs.table")
                }).on("uncheck-all.bs.table", function () {
                    e.text("Event: uncheck-all.bs.table")
                }).on("load-success.bs.table", function () {
                    e.text("Event: load-success.bs.table")
                }).on("load-error.bs.table", function () {
                    e.text("Event: load-error.bs.table")
                }).on("column-switch.bs.table", function () {
                    e.text("Event: column-switch.bs.table")
                }).on("page-change.bs.table", function () {
                    e.text("Event: page-change.bs.table")
                }).on("search.bs.table", function () {
                    e.text("Event: search.bs.table")
                })
            };
        }
    ]);
})(jQuery);