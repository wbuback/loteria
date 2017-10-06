$(document).ready(function (e) {


    var caminho = window.location.href;
    var split = caminho.split("/");
    var urlPadrao = split[0] + "//" + split[2];


    var atualizarApostas = function () {
        $.ajax({
            url: urlPadrao+ "/aposta/ListarApostas",
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

    atualizarApostas();
});