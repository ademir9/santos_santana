$(document).ready(function () {
    $("input").attr('autocomplete', 'off');

    $("#formAcesso").submit(function (e) {
        e.preventDefault();

        if ($('#NumConta').val() == "" || $('#NumAgencia').val() == "" || $('#Senha').val() == "") {
            ModalDialog("Aviso", "Campos obrigatórios.");
            return false;
        }

        var data = {
            grant_type: 'password',
            username: $('#NumConta').val() + ';' + $('#NumAgencia').val(),
            password: $('#Senha').val()
        };

        $.ajax({
            url: 'http://localhost:50173/api/security/token',
            type: 'post',
            contentType: 'x-www-form-urlencoded',
            data: data,
            error:
            function (r) {
                ModalDialog("Erro", "Usuário ou senha inválidos.");
            },
            success:
            function (data) {
                localStorage.setItem('jtoken', data.access_token);
                buscarUsuario(data.access_token, $('#NumConta').val(), $('#NumAgencia').val());
            }
        })



    });


});

function buscarUsuario(token, conta, agencia) {
    $.ajax({
        url: 'http://localhost:50173/api/user/BuscarUsuario',
        type: 'get',
        contentType: 'application/json',
        data: {
            conta: conta,
            agencia: agencia
        },
        headers: {
            "Authorization": "Bearer " + token
        },
        error:
        function (r) {
            ModalDialog("Erro", "Falha ao buscar usuário.");
        },
        success:
        function (data) {
            localStorage.setItem('LSUsuario', JSON.stringify(data));
            window.location.href = 'Home/Principal';
        }
    });

}