$(document).ready(function () {

    $("#btnConfirmaSaque").click(function () {

        if ($("#ValorSaque").val() == "") {
            ModalDialog("Aviso", "Valor obrigatório.");
            return false;
        }
            
        $.ajax({
            url: 'http://localhost:50173/api/atm/efetuarsaque',
            type: 'get',
            contentType: 'application/json',
            data: {
                "cpf": objUsuario.CPF,
                "valor": $("#ValorSaque").val().replace(",", ".")
            },
            headers: {
                "Authorization": "Bearer " + localStorage.getItem('jtoken')
            },
            error:
            function (data) {
                ModalDialog("Erro", data.Msg);
            },
            success:
            function (data) {
                ModalDialog("Aviso", data.Msg);
                if (data.Status == "true") {
                    $('#modalSaque').modal('hide');
                    $("#ValorSaque").val("");
                }
            }
        });

    
    });



});