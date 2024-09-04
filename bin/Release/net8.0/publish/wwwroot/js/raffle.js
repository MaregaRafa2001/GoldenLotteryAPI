app.controller('RaffleController', function ($scope, $routeParams, $location, $rootScope, $sce) {

    $scope.qty = 1;
    $scope.orders = [];
    $scope.isAuthenticated = $rootScope.auth.isAuthenticated;
    $scope.orderFilter = {
        raffleId: $routeParams.id,
        customerId: $rootScope.auth?.customer?.customerId
    }

    $rootScope.http('Raffle/' + $routeParams.id, 'GET')
        .then(function (response) {
            $scope.raffle = response.data;

            $scope.largeDescription = $sce.trustAsHtml($scope.raffle.largeDescription);
            $scope.largeDescriptionShort = $sce.trustAsHtml($scope.raffle.largeDescription.substring(0, 200) + "...");

            $scope.order = {
                raffleId: $scope.raffle.raffleId,
                price: $scope.raffle.price,
                unitPrice: $scope.raffle.price
            };

            $scope.getOrders();
        })
        .catch(function (error) {
            console.error('Erro ao obter detalhes da rifa:', error);
        });

    $scope.UpdateQty = function (qty) {
        if ($scope.qty + qty < 1) {
            alert("O número de bilhetes não pode ser menor do que 1.")
            return;
        }
        $scope.qty += qty;
        $scope.order.price = $scope.order.unitPrice * $scope.qty;
    }

    $scope.getOrders = function () {
        $scope.orders = [];
        if ($scope.isAuthenticated) {
            $rootScope.http('Order', 'GET', $scope.orderFilter).then(function (response) {
                $scope.orders = response.data;
            });
        }
    }
    
    $scope.createOrder = function () {

        if (!$scope.isAuthenticated) {
            alert('Realize o login para criar o pedido.')
            return;
        }

        if ($scope.qty < 1) {
            alert("Selecione a quantidade de bilhetes que deseja comprar.");
        }

        $scope.order.customerId = $rootScope.auth.customer.customerId;
        $scope.order.quantityNumbers = $scope.qty;

        $rootScope.http('Order/Payment', 'POST', {}, $scope.order)
            .then(function (response) {
                $location.path('order/' + response.data.orderId);
            })
            .catch(function (error) {
                alert(error.status == 400 ? error.data.error : "Erro ao criar o pedido");
                console.error(error);
            });
    };
});