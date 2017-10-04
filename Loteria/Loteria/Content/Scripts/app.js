$(document).ready(function (e) {

    /**
     * Submete o formulário com os números selecionados
     */
    $("#formApostar").submit(function(event) {
        event.preventDefault();
        var data = $(this).serializeFormJSON();

        $.ajax()

        console.log(data);
    });

    /**
     * Conta a quantidade de dezenas selecionadas e avisa quando chegar no limite 6
     */

    var maximo = 6;
    var dezenasJogo1 = 0;
    var dezenasJogo2 = 0;
    var tituloMensagem = "Vamos com calma, filhote!";
    var mensagem = "Entendi que você quer ficar rico, mas, por enquanto, você só pode fazer jogos de <strong>seis dezenas</strong>!<br>Sabe como é... é a crise!";

    $(".checkbox").change(function (e) {
        
        $('input[data-jogo=1]:checked').each(function() {
            dezenasJogo1++;
        });
        if (dezenasJogo1 > maximo) {
            $(this).prop('checked', false);
            swal(tituloMensagem, mensagem, 'error');
        }
       
        $('input[data-jogo=2]:checked').each(function () {
            dezenasJogo2++;
        });
        if (dezenasJogo2 > maximo) {
            $(this).prop('checked', false);
            swal(tituloMensagem, mensagem, 'error');
        }
        
    });

    $(".radio").click(function (e) {
        if (this.value != maximo) {
            $(this).prop('checked', false);
            swal(tituloMensagem, mensagem, 'error');
        }
        if (this.checked) {
            $(this).prop('checked', false);
        }
    });

});

/* Serializa os os checkbox do formulário */
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
