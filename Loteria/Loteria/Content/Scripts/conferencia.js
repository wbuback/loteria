$(document).ready(function(event) {

    var caminho = window.location.href;
    var split = caminho.split("/");
    var urlPadrao = split[0]+"//"+split[2];


    $.ajax({
        url: urlPadrao + "/aposta/ConferirApostas",
        method: "get",
        dataType: "json"
    }).done(function (result) {

        if (result.erro === true) {
            swal("Mano do céu!", result.msg, "error");
        } else {

            var conta = result.length;
            var html = "";

            if (conta !== 0) {
                var numerosSorteados = result[0].Sorteio.Dezenas;

                html += "<tr>";
                for (var x = 0; x < numerosSorteados.length; x++) {
                    var sorteado = numerosSorteados[x] < 10 ? "0" + numerosSorteados[x] : numerosSorteados[x];
                    html += "<th>" + sorteado + "</th>";
                }
                html += "<th>Acertos</th>";
                html += "</tr>";

                for (var i = 0; i < conta; i++) {
                    html += "<tr>";
                    var dezenas = result[i].Aposta.Dezenas;
                    var acertos = result[i].acertos;

                    var qtdAcertos = acertos.length;

                    for (var y = 0; y < dezenas.length; y++) {
                        var dezena = dezenas[y];

                        var dezenaFormatada = dezenas[y] < 10 ? "0" + dezenas[y] : dezenas[y];

                        if (jQuery.inArray(dezena, acertos) > -1) {
                            
                            html += "<td><span class='circulo'>" + dezenaFormatada + "</span></td>";
                        } else {
                            html += "<td>" + dezenaFormatada + "</td>";
                        }
                        
                    }
                    html += "<td><b>" + qtdAcertos + "</b></td>";
                    html += "</tr>";
                }

            }
        
            $("#tabela").html(html);
        }
        
    });

});