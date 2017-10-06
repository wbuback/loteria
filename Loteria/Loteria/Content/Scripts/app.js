$(document).ready(function (e) {

    var caminho = window.location.href;
    var split = caminho.split("/");
    var urlPadrao = split[0] + "//" + split[2];


    $("#sortear").click(function (e) {
        
        var pagina = $(this).data("pagina");
        $.ajax({
            url: urlPadrao + "/sorteio/sortear",
            method: "get",
            dataType: "json"
        }).done(function (result) {
            swal("Números sorteados!", "Cruze os dedos, reze cinco ave-marias, dê três pulinhos e vá conferir suas apostas!", "success")
                .then(function() {
                    if (pagina === 1) {
                        window.location.reload();
                    } else {
                        return null;
                    }
                });
        });
           
    });


    $(".btn-eliminar").click(function (e) {
        $.ajax({
            url: urlPadrao + "/aposta/reiniciar",
            method: "get",
            dataType: "json"
        }).done(function(result) {
            swal("Vai na fé, champz!", result, "success");
            $("#tabela").html("");
        });
    });

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
                swal("Você está quase lá!", result, "success");
                $("input").prop('checked', false);
                atualizarApostas();
            });
        }
    });

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

    var atualizarApostas = function () {
        $.ajax({
            url: urlPadrao + "/aposta/ListarApostas",
            method: "get",
            dataType: "json"
        }).done(function (result) {

            //debugger;
            var jogos = JSON.parse(result);

            if (jogos.length === 0) {
                $("#sortear").hide();
            } else {
                $("#sortear").show();
            }

            var html = "";
            for (var x = 0; x < jogos.length; x++) {
                var dezenas = jogos[x].Dezenas.length;
                html += "<ul class='listaDezenas'>";

                for (var i = 0; i < dezenas; i++) {
                    var numero = jogos[x].Dezenas[i] < 10 ? "0" + jogos[x].Dezenas[i] : jogos[x].Dezenas[i];
                    html += "<li>" + numero + "</li>";
                }

                html += "</ul>";
            }

            html += '<a href="aposta/conferir" class="btn-sortear btn-conferir"><i class="fa fa-check-square-o"></i> Conferir jogos</a>';

            $("#apostasRealizadas").html(html);

        });
    }
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