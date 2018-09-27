$(document).ready(function () {
 

    $("#btnConfirmaDeposito").click(function () {

        if ($("#NumContaDep").val() == "" || $("#NumAgenciaDep").val() == "" || $("#ValorDeposito").val() == "") {
            ModalDialog("Aviso", "Campos obrigatórios.");
            return false;
        }

        //cpf, string contaDestino, string agenciaDestino, decimal valor
    
        $.ajax({
            url: 'http://localhost:50173/api/atm/efetuartransacao',
            type: 'get',
            contentType: 'application/json',
            data: {
                "cpf": objUsuario.CPF,
                "contaDestino": $("#NumContaDep").val(),
                "agenciaDestino": $("#NumAgenciaDep").val(),
                "valor": $("#ValorDeposito").val().replace(",", "."),
                "tipo": '1' //1- depósito
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
                    $('#modalDeposito').modal('hide');
                    $("#NumContaDep").val("");
                    $("#NumAgenciaDep").val("");
                    $("#ValorDeposito").val("");
                }
            }
        });


    });
    
});