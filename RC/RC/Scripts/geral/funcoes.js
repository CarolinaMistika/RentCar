function AcaoRegistro(parametros, url, mensagem, nomeFuncao, parametroFuncao) {
    swal({
        title: "Atenção!",
        text: mensagem,
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Confirmar",
        closeOnConfirm: false,
        cancelButtonText: "Sair",
        showLoaderOnConfirm: true
    }, function (isConfirm) {
        if (!isConfirm) return;
        $.ajax({
            type: "POST",
            data: parametros,
            url: url,
            dataType: "json",
            success: function (data) {
                if (data[0] == "false") {
                    swal("Atenção!", data[1], "error");
                }
                else {
                    swal({
                        title: "Atenção!",
                        text: data[1],
                        type: "success"
                    }, function () {
                        if (data[2] != "" && data[2] != null && data[2] != undefined) {
                            window.location.href = data[2];
                        } else if (nomeFuncao != "" && nomeFuncao != null && nomeFuncao != undefined) {
                            window[nomeFuncao](parametroFuncao);
                        }
                    });
                }
            },
            complete: function (msg) {
                if (msg.status == 601) {
                    location.href = window.location.href;
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                if (errorThrown == "Not Found" || textStatus == "parsererror") {
                    Erro500();
                }
            }
        });
    });
}

function FuncaoAjax(type, parametros, url, nomeFuncao) {
    $.ajax({
        type: type,
        data: parametros,
        url: url,
        dataType: "json",
        success: function (data) {
            window[nomeFuncao](data);
        },
        complete: function (msg) {
            if (msg.status == 601) {
                location.href = window.location.href;
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            if (errorThrown == "Not Found" || textStatus == "parsererror") {
                Erro500();
            }
        }
    });
}

function VerificaData(campo) {
    var retorno = true;
    var data = $(campo).val().replace(/[^0-9]/g, '').toString();
    if (data.length == 8) {
        data = $(campo).val().split("/");
        var dia = parseInt(data[0]);
        var mes = parseInt(data[1]);
        var ano = parseInt(data[2]);
        var anoAtual = new Date().getFullYear();
        if (dia > 31 || dia < 1)
            retorno = false;
        if (mes > 12 || mes < 1)
            retorno = false;
        if (ano > 9999 || ano >= anoAtual || ano < (anoAtual - 150))
            retorno = false;
    }
    else
        retorno = false;

    if (retorno == false) {
        $(campo).val('');
        $(campo).focus();
        swal({ title: "Atenção!", text: "Data de nascimento inválida!", type: "warning" });
    }

    return retorno;
}

function VerificaCPF(campo) {
    var retorno = true;
    var cpf = $(campo).val().replace(/[^0-9]/g, '').toString();

    if (cpf.length == 11) {
        var v = [];

        //Calcula o primeiro dígito de verificação.
        v[0] = 1 * cpf[0] + 2 * cpf[1] + 3 * cpf[2];
        v[0] += 4 * cpf[3] + 5 * cpf[4] + 6 * cpf[5];
        v[0] += 7 * cpf[6] + 8 * cpf[7] + 9 * cpf[8];
        v[0] = v[0] % 11;
        v[0] = v[0] % 10;

        //Calcula o segundo dígito de verificação.
        v[1] = 1 * cpf[1] + 2 * cpf[2] + 3 * cpf[3];
        v[1] += 4 * cpf[4] + 5 * cpf[5] + 6 * cpf[6];
        v[1] += 7 * cpf[7] + 8 * cpf[8] + 9 * v[0];
        v[1] = v[1] % 11;
        v[1] = v[1] % 10;

        //Retorna Verdadeiro se os dígitos de verificação são os esperados.
        if ((v[0] != cpf[9]) || (v[1] != cpf[10]))
            retorno = false;

        if (cpf == "00000000000")
            retorno = false;
        else if (cpf == "11111111111")
            retorno = false;
        else if (cpf == "22222222222")
            retorno = false;
        else if (cpf == "33333333333")
            retorno = false;
        else if (cpf == "44444444444")
            retorno = false;
        else if (cpf == "55555555555")
            retorno = false;
        else if (cpf == "66666666666")
            retorno = false;
        else if (cpf == "77777777777")
            retorno = false;
        else if (cpf == "88888888888")
            retorno = false;
        else if (cpf == "99999999999")
            retorno = false;
    }
    else
        retorno = false;

    if (retorno == false) {
        $(campo).val('');
        $(campo).focus();
        swal({ title: "Atenção!", text: "Cpf inválido!", type: "warning" });
    }

    return retorno;
}

function MascarasFormulario() {
    $('.telefone').mask('(99) 9999-99999');
    $('.cpf').mask('999.999.999-99');
    $('.data').mask('99/99/9999');
    $('.idade').mask('999');

}

function MarcaCheck() {
    $(".checkbox").iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green'
    });
}


function ValidaForm() {
    var retorno = true;
    var campos = $("[required]");
    for (var i = 0; i < campos.length; i++) {
        if (campos[i].value == "")
            retorno = false;
    }
    return retorno;
}

function FomataDataGrid(data) {
    if (data != null && data != undefined) {
        var html = eval(data.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
        var dia = "" + html.getDate();
        var mes = "" + parseInt(html.getMonth() + 1);
        var ano = "" + html.getFullYear();
        if (parseInt(dia.length) < 2) {
            dia = "0" + dia;
        }
        if (mes.length < 2) {
            mes = "0" + mes;
        }
        html = dia + "/" + mes + "/" + ano;
        return html;
    } else
        return "";
}