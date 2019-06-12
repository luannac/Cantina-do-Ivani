function PressKeyCpCodigo() {
    if (event.keyCode === 13) {
        // Cancel the default action, if needed
        event.preventDefault();
        $("#cpQuant").focus();
    }
}


function PressKeyCpQuant() {
    if (event.keyCode === 13) {
        // Cancel the default action, if needed
        event.preventDefault();
        addProduto();
        $("#cpQuant") = "";
        $("#cpCodigo") = "";
        $("#cpCodigo").focus();
    }
}

function addProduto() {
    //Gravar
    var url = "/Vendas/addProduto";

    $.ajax({
        url: url,
        type: "post",
        datatype: "json",
        data: { id: $("#cpCodigo").val(), quant: $("#cpQuant").val() },
        success: function (data) {
            var html = 
                        "<tr>"
                            +"<td>"
                            +data.id
                            +"</td>"
                            +"<td>"
                            +data.nome
                            + "</td>"
                            +"<td>"
                            +data.valor
                            +" </td>"
                            +"<td>"
                            +data.quant
                            +" </td>"
                        +" </tr>"
            $("#areaLancamentos").prepend(html);
            $("#cpCodigo").empty();
            $("#cpQuant").empty();

            atualizaTotal();
        }
    });
}

function atualizaTotal() {
    //Gravar
    var url = "/Vendas/PegaValorVenda";

    $.ajax({
        url: url,
        type: "post",
        datatype: "json",
        success: function (data) {
            var campo = $("#ValorTotal");
            campo.empty();
            campo.html("Preço Total: R$" + data.resultado);
            //mostrarProduto();
        }
    });
}















//$(document).ready(function () {
//    let Itens = [];//Variavel para adicionar os itens retornado do backend
//    let divItens = document.getElementById("divItens");//Selecionando a div que irá receber o conteúdo gerado automaticamente
//    //Chamada do Ajax para trazer os detalhes da ordem
//    $.ajax({
//        url: '/secured/vagas/', //selecionando o endereço que iremos acessar no backend
//        type: 'GET', //selecionando o tipo de requesição, PUT,GET,POST,DELETE
//        sucess: function () { },//Em caso de sucesso
//        error: function (err) {//Em caso de erro
//            console.log(err);//Exibir o erro no console JS do navegador
//        }
//    }).done(function (resultados) {
//        //Armazenando os dados retornado do backend para a variável Itens
//        Itens = resultados;
//        //Efetuando um loop para cada que esteja no JSON retornado
//        Itens.forEach(function (item) {
//            //Concatenando o conteúdo ao elemento HTML
//            divItens.innerHTML = divVagas.innerHTML +
//              "<div class='card'>" +
//                 "<h5 class='card-title'><a href='/vaga/" + item.id + "'>" + item.nome + "</a></h5>" +
//                 "<p class='card-text'>" + item.texto + "</p>" +
//              "</div>";
//        });//Fim forEach
//    });//Fim chamada Ajax
//});