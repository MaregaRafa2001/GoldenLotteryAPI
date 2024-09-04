app.controller('HomeController', function ($scope, $rootScope, $filter) {

    $scope.goTo = $rootScope.goTo;

    $scope.getRaffles = function () {
        $scope.Raffles = [];

        $rootScope.http('Raffle').then(function (response) {
            $scope.Raffles = response.data;
            if ($scope.Raffles.length == 1) {
                $rootScope.goTo('raffle/' + $scope.Raffles[0].raffleId)
            }
        });
    }

    $scope.getRaffles();
})