(function () {
    var controllerId = 'app.views.channel.createNode';
    angular.module('app').controller(controllerId, [
        'abp.services.app.node', '$uibModalInstance',
        function (nodeService, $uibModalInstance) {
            var vm = this;

            vm.node = {
                nodeName: '',
                nodeIndexName: ''
            };

            vm.save = function () {
                nodeService
                    .createNode(vm.node)
                    .success(function () {
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };
        }
    ]);
})();