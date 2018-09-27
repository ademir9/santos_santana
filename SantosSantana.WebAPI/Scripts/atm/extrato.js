$(document).ready(function () {

    $("#btnExtrato").click(function () {
               
        var data = {
            username: $('#NumConta').val() + ';' + $('#NumAgencia').val(),
            password: $('#Senha').val()
        };

        $.ajax({
            url: 'http://localhost:50173/api/atm/efetuarextrato',
            type: 'get',
            contentType: 'application/json',
            data: {
                "cpf": objUsuario.CPF
            },
            headers: {
                "Authorization": "Bearer " + localStorage.getItem('jtoken')
            },
            error:
            function (data) {
                $('#modalExtrato').modal('hide');
                ModalDialog("Erro", data.Msg);
            },
            success:
            function (data) {
                console.log(data)
                populaExtrato(data);
              //  ModalDialog("Aviso", data.Msg);
               
            }
        });


    });

       


});

function populaExtrato(trans) {
    $('#tbExtrato tr').remove();

    var texto = "<tr style='font-weight:bold;height:35px;'><td>Data</td><td>Lançamento</td><td style='text-align:right;'>Valor</td><td style='text-align:right;'>Saldo</td></tr>";
    var saldo;
    var limite;
    $.each(trans, function (index, value) {

        var dataSplit = value.Data.split("-");
        var ano = dataSplit[0]; 
        var mes = dataSplit[1];
        var dia = (dataSplit[2].split("T"))[0];

        saldo = value.Conta.Saldo.toFixed(2);
        limite = value.Conta.Limite.toFixed(2);

        texto += '<tr> ' +
            '<td>' + dia + "/" + mes+'</td>' +
            '<td>' + value.TipoTransacao.Descricao + '</td>' +
            '<td style="text-align:right;">' + value.Valor.toFixed(2) + '</td>' +
            '<td></td>' +
            '</tr > ';
    });

    texto += "<tr style='font-weight:bold; height:35px;vertical-align:bottom;'><td></td><td>Limite</td><td style='text-align:right;'>"+limite+"</td><td style='text-align:right;'>"+saldo+"</td></tr>";

    $('#tbExtrato').append(texto);
}