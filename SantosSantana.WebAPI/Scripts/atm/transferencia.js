$(document).ready(function () {


    $("#btnConfirmaTransferencia").click(function () {

            if ($("#NumContaTrans").val() == "" || $("#NumAgenciaTrans").val() == "" || $("#ValorTrans").val() == "") {
                ModalDialog("Aviso", "Campos obrigatórios.");
                return false;
            }
            

            $.ajax({
                url: 'http://localhost:50173/api/atm/efetuartransacao',
                type: 'get',
                contentType: 'application/json',
                data: {
                    "cpf": objUsuario.CPF,
                    "contaDestino": $("#NumContaTrans").val(),
                    "agenciaDestino": $("#NumAgenciaTrans").val(),
                    "valor": $("#ValorTrans").val().replace(",", "."),
                    "tipo":'3' //3- Transferência
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
                        $('#modalTransferencia').modal('hide');
                        $("#NumContaTrans").val("");
                        $("#NumAgenciaTrans").val("");
                        $("#ValorTrans").val("");
                    }
                }
            });


        });


});