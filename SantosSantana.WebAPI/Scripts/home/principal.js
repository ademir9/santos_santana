var objUsuario;

$(document).ready(function () {
    $("input").attr('autocomplete', 'off');

    if (localStorage.getItem('jtoken') != 'null' && localStorage.getItem('LSUsuario') != null) {
        objUsuario = JSON.parse(localStorage.getItem('LSUsuario'));

        $("#lblNome").html("Olá, " + objUsuario.Nome);

    }
    else {
        window.location.href = '/Home';
    }

    $("#btnSair").click(function () {
        localStorage.setItem('LSUsuario', null);
        localStorage.setItem('jtoken', null);
        window.location.href = '/Home';
    });

});