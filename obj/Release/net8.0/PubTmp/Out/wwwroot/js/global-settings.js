app.run(function ($rootScope, $http, $location) {

    //$rootScope.login = function () {
    //    $rootScope.http('Customer/Login', 'POST', $scope.user)
    //        .then(function (response) {
    //            $rootScope.setAuthInfo(true, response.data.token, response.data.customer);
    //            $location.path($routeParams.returnPath ?? '');
    //        })
    //        .catch(function (error) {
    //            alert('Usuário ou senha incorretos. Tente novamente.');
    //        });
    //};

    var history = [];
    $rootScope.$on('$routeChangeSuccess', function () {
        history.push($location.$$path);
    });

    $rootScope.lastPage = function () {
        var prevUrl = history.length > 1 ? history.splice(-2)[0] : "/";
        $location.path(prevUrl);
    };

    $rootScope.goTo = function (url) {
        $location.path(url);
    };


    $rootScope.auth = {
        isAuthenticated: false,
        authToken: '',
        customer: {}
    };

    //if (document.cookie) {
    //    var cookie = JSON.parse(document.cookie);
    //    if (cookie.dataExpiracao > new Date()) {
    //        $rootScope.auth = cookie.auth;
    //    }
    //}


    $rootScope.setAuthInfo = function (isAuthenticated, authToken, customer) {
        $rootScope.auth.isAuthenticated = isAuthenticated;
        $rootScope.auth.authToken = authToken;
        $rootScope.auth.customer = customer;

        document.cookie = `auth=${JSON.stringify($rootScope.auth)}; expires=${new Date(new Date().getTime() + 1000).toUTCString()}; path=/`;


        //var dataExpiracao = new Date();
        //dataExpiracao.setTime(dataExpiracao.getTime() + (30 * 60 * 1000));

        //document.cookie = JSON.stringify({
        //    auth: $rootScope.auth,
        //    dataExpiracao
        //});
    };

    $rootScope.clearAuthInfo = function () {
        $rootScope.auth.isAuthenticated = false;
        $rootScope.auth.authToken = '';
    };

    $rootScope.http = function (url, method = "GET", params = {}, data = {}, headers = {}) {
        headers = {
            'Authorization': $rootScope.auth.authToken,
            ...headers
        };

        //var apiUrl = 'http://localhost:5299/' + url;
        var apiUrl = 'https://bubupremios.jelastic.saveincloud.net/' + url;

        return $http({
            method: method,
            params: params,
            url: apiUrl,
            data: data
        });
    };
});

app.config(function ($routeProvider, $locationProvider) {
    $routeProvider.
        when('/', { templateUrl: 'home.html', controller: 'HomeController' }).
        when('/login', { templateUrl: 'login.html', controller: 'LoginController' }).
        when('/order/:id', { templateUrl: 'order.html', controller: 'OrderController' }).
        when('/raffle/:id', { templateUrl: 'raffle.html', controller: 'RaffleController' }).
        when('/register', { templateUrl: 'register.html', controller: 'RegisterController' }).
        otherwise({ redirectTo: '/' });
});

app.filter('brCurrency', function () {
    return function (input) {
        // Verifica se o input é válido
        if (!input && input !== 0) return '';

        // Converte o número para uma string
        var value = input.toString();

        // Separa a parte inteira da parte decimal
        var parts = value.split('.');
        var integerPart = parts[0];
        var decimalPart = parts.length > 1 ? parts[1] : '00';

        // Adiciona zeros à parte decimal se necessário
        if (decimalPart.length === 1) {
            decimalPart += '0';
        }

        // Formata o valor como moeda brasileira
        return 'R$ ' + integerPart + ',' + decimalPart;
    };
});
