app.controller('OrderController', function ($scope, $routeParams, $rootScope, $sce, $route) {

    $rootScope.http('Order/Detail/' + $routeParams.id, 'GET')
        .then(function (response) {
            $scope.order = response.data.order;
            switch ($scope.order.orderStatusId) {
                case 1:
                    response.paymentHtml = response.data.paymentHtml.replace("class=\"copy-value\"", "class=\"copy-value\" onclick=\"copyValue()\"")
                    $scope.paymentHtml = $sce.trustAsHtml(response.paymentHtml);
                    break;
                case 2: $scope.numbers = response.data.numbers;
            }
        })
        .catch(function (error) {
            console.error('Erro ao obter detalhes do pedido:', error);
        });

    $scope.padNumber = function (num) {
        return num.toString().padStart(6, '0');
    };

    $scope.reload = $route.reload;
});