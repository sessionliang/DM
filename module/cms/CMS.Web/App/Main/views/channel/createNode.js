(function () {
    var controllerId = 'app.views.channels.createNode';
    angular.module('app').controller(controllerId, [
        'app.services.app.node', '$modalInstance',
        function (nodeService, $modalInstance) {
            var vm = this;

            vm.node = {
                nodeName: '',
                nodeIndexName: ''
            };

            vm.save = function () {
                nodeService
                    .createNode(vm.node)
                    .success(function () {
                        $modalInstance.close();
                    });
            };

            vm.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
        }
    ]);
})();