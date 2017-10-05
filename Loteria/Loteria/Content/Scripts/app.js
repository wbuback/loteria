$(document).ready(function (e) {

    /**
     * Submete o formulário com os números selecionados
     */
    $("#formApostar").submit(function (event) {
        event.preventDefault();
        var data = $(this).serializeFormJSON();

        $.ajax({
            url: "Aposta/FazerAposta",
            method: "post",
            enctype: "application/json",
            type: "json",
            data: data
        }).done(function (result) {
            alert("foi");
        });

        console.log(data);
    });

    /**
     * Conta a quantidade de dezenas selecionadas e avisa quando chegar no limite 6
     */
    var maximo = 6;
    var tituloMensagem = "Vamos com calma, filhote!";
    var mensagem = "Entendi que você quer ficar rico, mas, por enquanto, você só pode fazer jogos de <strong>seis dezenas</strong>!<br>Sabe como é... é a crise!";

    $(".checkbox").change(function (e) {
        var contaJogo1 = $('input[data-jogo=1]:checked').length;
        var contaJogo2 = $('input[data-jogo=2]:checked').length;
        
        if (contaJogo1 > maximo) {
            $(this).prop('checked', false);
            swal(tituloMensagem, mensagem, 'error');
        }
         
        if (contaJogo2 > maximo) {
            $(this).prop('checked', false);
            swal(tituloMensagem, mensagem, 'error');
        }

        console.log(contaJogo1 + " - " + contaJogo2);
    });

    $(".radio").change(function (e) {
        if (this.value !== maximo) {
            $(this).prop('checked', false);
            swal(tituloMensagem, mensagem, 'error');
        }
        $(this).uncheckableRadio();
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

/* Plugin para dechecar RadioButton */
(function ($) {
    $.fn.uncheckableRadio = function () {

        return this.each(function () {
            var radio = this;
            $('label[for="' + radio.id + '"]').add(radio).mousedown(function () {
                $(radio).data('wasChecked', radio.checked);
            });

            $('label[for="' + radio.id + '"]').add(radio).click(function () {
                if ($(radio).data('wasChecked'))
                    radio.checked = false;
            });
        });
    };
})(jQuery);