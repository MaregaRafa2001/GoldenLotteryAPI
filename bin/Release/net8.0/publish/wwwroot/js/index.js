app.controller('IndexController', function ($scope, $routeParams, $location, $rootScope) {

    $scope.auth = $rootScope.auth;

    $scope.login = function () {
        $rootScope.http('Customer/Login', 'POST', $scope.user)
            .then(function (response) {
                $rootScope.setAuthInfo(true, response.data.token, response.data.customer);
                $location.path($routeParams.returnPath ?? '');
            })
            .catch(function (error) {
                alert('Usuário ou senha incorretos. Tente novamente.');
            });
    };
});