$(document).ready(function (e) {

    var atualizarApostas = function () {
        $.ajax({
            url: "Aposta/ListarApostas",
            method: "get",
            enctype: "application/json",
            dataType: "json",
        }).done(function (result) {
            $('#apostasRealizadas').html(result);
            console.log(result);
        });
    };

    atualizarApostas();

    /**
     * Submete o formulário com os números selecionados
     */
    $("#formApostar").submit(function (event) {
        event.preventDefault();
        var contarApostas = $('input.dezenas:checked').length;

        if ((contarApostas < maximo) && (!$("#surpresinha").is(":checked"))) {
            swal("Calmaê, Champs!", "Parece que você não entendeu como funciona os paranauê do game. Você precisa selecionar ao menos <strong>seis dezenas</strong> ou marca a <strong>surpresinha</strong> e deixa o sistema jogar por você. Tenta de novo aê!", "error");
        } else {
            var dezenas = $(this).serializeFormJSON();
            $.ajax({
                url: "Aposta/FazerAposta",
                method: "post",
                enctype: "application/json",
                dataType: "json",
                data: dezenas
            }).done(function (result) {
                swal("Você está quase lá!", result, "success")
                console.log(result);
                atualizarApostas();
            });
        }
    });

    /**
     * Conta a quantidade de dezenas selecionadas e avisa quando chegar no limite 6
     */
    var maximo = 6;
    var tituloMensagem = "Vamos com calma, filhote!";
    var mensagem = "Entendi que você quer ficar rico, mas, por enquanto, você só pode fazer jogos de <strong>seis dezenas</strong>!<br>Sabe como é... é a crise!";

    $(".dezenas").change(function (e) {
        $(".surpresinha").prop('checked', false);
        var contarApostas = $('input.dezenas:checked').length;
        
        if (contarApostas > maximo) {
            $(this).prop('checked', false);
            swal(tituloMensagem, mensagem, 'error');
        }
    });

    $(".surpresinha").change(function (e) {
        if ($(this).is(":checked")) {
            $('input.dezenas').prop('checked', false);
        }
    });

});

/* Plugin para serializar os checkboxes do formulário */
(function ($) {
    $.fn.serializeFormJSON = function () {

        var objeto = {};
        var data = this.serializeArray();


        $.each(data, function () {
            if (objeto[this.name]) {
                if (!objeto[this.name].push) {
                    objeto[this.name] = [objeto[this.name]];
                }
                objeto[this.name].push(this.value || "");
            } else {
                objeto[this.name] = this.value || "";
            }
        });
        return objeto;
    };
})(jQuery);
