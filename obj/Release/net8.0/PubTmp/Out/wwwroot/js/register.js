app.controller('RegisterController', function ($scope, $rootScope) {
    $scope.submitForm = function () {

        $rootScope.http('Customer', 'POST', {}, $scope.customer)
            .then(function (response) {
                $rootScope.lastPage();
            }, function (error) {
                if (error.status == 409)
                    alert(error.data.error);
                else 
                    alert('Erro ao realizar o cadastro. Entre em contato com o administrador do sistema.');
            });
    }
})