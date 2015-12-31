(function () {
    var controllerId = 'app.views.channels.index';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;

            vm.data = [{
                tId: "1",
                first: "奔波儿灞",
                sex: "男",
                score: "50"
            }, {
                tId: "2",
                first: "灞波儿奔",
                sex: "男",
                score: "94"
            }, {
                tId: "3",
                first: "作家崔成浩",
                sex: "男",
                score: "80"
            }, {
                tId: "4",
                first: "韩寒",
                sex: "男",
                score: "67"
            }, {
                tId: "5",
                first: "郭敬明",
                sex: "男",
                score: "100"
            }, {
                tId: "6",
                first: "马云",
                sex: "男",
                score: "77"
            }, {
                tId: "7",
                first: "范爷",
                sex: "女",
                score: "87"
            }, {
                tId: "8",
                first: "范爷",
                sex: "女",
                score: "87"
            }, {
                tId: "9",
                first: "范爷",
                sex: "女",
                score: "87"
            }, {
                tId: "10",
                first: "范爷",
                sex: "女",
                score: "87"
            }, {
                tId: "11",
                first: "范爷",
                sex: "女",
                score: "87"
            }, {
                tId: "12",
                first: "范爷",
                sex: "女",
                score: "87"
            }, {
                tId: "13",
                first: "范爷",
                sex: "女",
                score: "87"
            }, {
                tId: "14",
                first: "范爷",
                sex: "女",
                score: "87"
            }, {
                tId: "15",
                first: "范爷",
                sex: "女",
                score: "87"
            }, {
                tId: "16",
                first: "范爷",
                sex: "女",
                score: "87"
            }];

            vm.init = function () {
                $("#contentTable").bootstrapTable({
                    data: this.data,
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
            };
            vm.init();
        }
    ]);
})();