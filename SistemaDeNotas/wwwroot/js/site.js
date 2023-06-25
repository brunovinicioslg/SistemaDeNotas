// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    listaravisos();
    getDatatable('#table-notas');
    getDatatable('#table-usuarios');
    getDatatable('#table-avisos');
    $('.btn-total-notas').click(function () {
        var usuarioID = $(this).attr('usuario-id');
        console.log(usuarioID);
        $.ajax({
            type: 'GET',
            url: '/Usuario/ListarNotasPorUsuarioId/' + usuarioID,
            success: function (result) {
                $("#listaNotasUsuario").html(result);
                $('#modalNotasUsuario').modal();
                getDatatable('#table-notas-usuario');

            }
        });

    });


});
function listaravisos() {
    $.ajax({
        type: 'GET',
        url: '/ExibirAviso/ListarAvisos',
        success: function (result) {
            $("#listaAvisos").html(result);
        }
    });
}


function getDatatable(id) {
    $(id).DataTable({
        "responsive": true,
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}

    

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});


const toggle = document.getElementById("toggle");
const refresh = document.getElementById("refresh");
const theme = window.localStorage.getItem("theme");

/* verifica se o tema armazenado no localStorage é escuro
se sim aplica o tema escuro ao body */
if (theme === "dark") document.body.classList.add("dark");

// event listener para quando o botão de alterar o tema for clicado
toggle.addEventListener("click", () => {
    document.body.classList.toggle("dark");
    if (theme === "dark") {
        window.localStorage.setItem("theme", "light");
    } else window.localStorage.setItem("theme", "dark");
});

refresh.addEventListener("click", () => {
    window.location.reload();
});

