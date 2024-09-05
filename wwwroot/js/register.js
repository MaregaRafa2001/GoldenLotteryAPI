app.controller('RegisterController', function ($scope, $rootScope) {
    $scope.submitForm = function () {
        if ($scope.validForm()) {
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
    }

    $scope.validForm = function () {
        $scope.customer.cpf = $scope.customer.cpf?.replace(/\D/g, "");

        const errors = [];

        // Valida��o de nome (pelo menos duas palavras e n�mero m�nimo de caracteres)
        if (!$scope.customer.name || $scope.customer.name.split(' ').length < 2 || $scope.customer.name.length < 5) {
            errors.push("O nome completo deve conter pelo menos duas palavras e ter no m�nimo 5 caracteres.");
        }

        // Valida��o de CPF (b�sica, apenas se est� vazio)
        if (!$scope.customer.cpf || $scope.customer.cpf.length !== 11 || !/^\d+$/.test($scope.customer.cpf) || !validarCPF($scope.customer.cpf)) {
            errors.push("CPF inv�lido. Deve ter 11 d�gitos num�ricos.");
        }

        // Valida��o de email
        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!$scope.customer.email || !emailPattern.test($scope.customer.email)) {
            errors.push("Email inv�lido.");
        }

        // Valida��o de senha (m�nimo de 8 caracteres, pelo menos uma letra e um n�mero)
        const passwordPattern = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
        if (!$scope.customer.password || !passwordPattern.test($scope.customer.password)) {
            errors.push("A senha deve ter no m�nimo 8 caracteres e incluir pelo menos uma letra e um n�mero.");
        }

        // Exibir erros ou prosseguir com o envio
        if (errors.length > 0) {
            alert(errors.join("\n"));
            return false;
        }

        return true;
    }

    function validarCPF(cpf) {
        // Remove caracteres especiais e espa�os
        cpf = cpf.replace(/[^\d]+/g, '');

        // Verifica se o CPF tem 11 d�gitos
        if (cpf.length !== 11) {
            return false;
        }

        // Verifica se todos os d�gitos s�o iguais (ex: 111.111.111-11)
        if (/^(\d)\1{10}$/.test(cpf)) {
            return false;
        }

        // Calcula o primeiro d�gito verificador
        let soma = 0;
        for (let i = 0; i < 9; i++) {
            soma += parseInt(cpf.charAt(i)) * (10 - i);
        }
        let resto = 11 - (soma % 11);
        let primeiroDigitoVerificador = resto >= 10 ? 0 : resto;

        // Calcula o segundo d�gito verificador
        soma = 0;
        for (let i = 0; i < 10; i++) {
            soma += parseInt(cpf.charAt(i)) * (11 - i);
        }
        resto = 11 - (soma % 11);
        let segundoDigitoVerificador = resto >= 10 ? 0 : resto;

        // Verifica se os d�gitos calculados conferem com os do CPF fornecido
        return (
            primeiroDigitoVerificador === parseInt(cpf.charAt(9)) &&
            segundoDigitoVerificador === parseInt(cpf.charAt(10))
        );
    }

})