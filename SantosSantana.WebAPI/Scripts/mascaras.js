
$().ready(function () {
    mascaras();
});

function mascaras(){
    $(".maskTel").mask("(99) 9999?9-9999").focusout(function () {
        var phone, element;
        element = $(this);
        element.unmask();
        phone = element.val().replace(/\D/g, '');
        if (phone.length > 10) {
            element.mask("(99) 99999-999?9");
        } else {
            element.mask("(99) 9999-9999?9");
        }
    }).trigger('focusout');



    $('.maskCPF').mask("999.999.999-99");
    $('.maskCEP').mask("99999-999");
    $('.maskData').mask("99/99/9999");
    $('.maskConta').mask("9999-9");
    $('.maskInt').mask("99999999");
    $(".valor").maskMoney({ allowNegative: true, thousands: '', decimal: ',', affixesStay: false });

}

function CPFValido(strCPF) {
    strCPF = strCPF.replace(".", "").replace(".", "");
    strCPF = strCPF.replace("-", "");
    
if (strCPF.indexOf("0000") !== -1 || strCPF.indexOf("1111") !== -1 || strCPF.indexOf("2222") !== -1
        || strCPF.indexOf("3333") !== -1 || strCPF.indexOf("4444") !== -1 || strCPF.indexOf("5555") !== -1
        || strCPF.indexOf("6666") !== -1 || strCPF.indexOf("7777") !== -1
        || strCPF.indexOf("8888") !== -1 || strCPF.indexOf("9999") !== -1)
        return false;

    var Soma;
    var Resto;
    Soma = 0;
    var sNum = "";
    for (var i = 0; i < 11; i++) {
        for (var j = 0; j < 11; j++) {
            sNum += i;
        }
        if (strCPF == sNum) return false;
        sNum = "";
    }



    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) return false;

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) return false;
    return true;
}


function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');
    var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
        '        <div class="modal-dialog">                                                                                 ' +
        '            <div class="modal-content">                                                                            ' +
        '                <div class="modal-header">                                                                         ' +
        '                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
        '                    <h4 class="modal-title">' + titulo + '</h4>                                                    ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-body">                                                                           ' +
        '                    <p>' + texto + '</p>                                                                           ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-footer">                                                                         ' +
        '                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
        '                                                                                                                   ' +
        '                </div>                                                                                             ' +
        '            </div><!-- /.modal-content -->                                                                         ' +
        '  </div><!-- /.modal-dialog -->                                                                                    ' +
        '</div> <!-- /.modal -->                                                                                        ';

    $('body').append(texto);
    $('#' + random).modal('show');
}



