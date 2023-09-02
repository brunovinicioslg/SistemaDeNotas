// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {


    $('#turmavalidate').on('change', function () {
        validarSelect();
    });

    var urlEspecifica = window.location.pathname == "/UsuarioGeral/Criar";
    if (urlEspecifica) {
        form.addEventListener('submit', (event) => {
            nameValidate();
            emailValidate();
            mainPasswordValidate();
            comparePassword();
            validarSelect();
        });

    }

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
    $(function () {
        $(document).on('scroll', function () {
            if ($(window).scrollTop() > 100) {
                $('.smoothscroll-top').addClass('show');
            } else {
                $('.smoothscroll-top').removeClass('show');
            }
        });
        $('.smoothscroll-top').on('click', scrollToTop);
    });

    function scrollToTop() {
        verticalOffset = typeof (verticalOffset) != 'undefined' ? verticalOffset : 0;
        element = $('body');
        offset = element.offset();
        offsetTop = offset.top;
        $('html, body').animate({ scrollTop: offsetTop }, 600, 'linear').animate({ scrollTop: 25 }, 200).animate({ scrollTop: 0 }, 150).animate({ scrollTop: 0 }, 50);
    }
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
        "stateSave": true,
        "bDestroy": true,
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


const form = document.getElementById('form');
const campos = document.querySelectorAll('.required');
const spans = document.querySelectorAll('.span-required');
const spans2 = document.querySelectorAll('.span-valida');

var emailRegex = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;




function setError(index) {
    campos[index].style.border = '2px solid #e63636'
    spans[index].style.display = 'block';
    spans2[index].style.display = 'none';
    
}
function removeError(index) {
    campos[index].style.border = ''
    spans[index].style.display = 'none';
    spans2[index].style.display = 'none';
}

function userValidate() {
    if (campos[0].value.length < 3) {
        setError(0);
    }
    else {
        removeError(0);
    }

}


function nameValidate() {
    if (campos[1].value.length < 3) {
        setError(1);
    }
    else {
        removeError(1);
    }

}

function emailValidate() {
    if (!emailRegex.test(campos[2].value)) {
        setError(2);
    }

    else {
        removeError(2);

    }

}

function mainPasswordValidate() {
    if (campos[3].value.length < 8) {
        setError(3);
    }
    else {
        removeError(3);
        comparePassword();
    }
}
function comparePassword() {
    if (campos[3].value == campos[4].value && campos[4].value.length >= 8) {
        removeError(4);
    }
    else {
        setError(4);
    }
}

function validarSelect() {
    if (!$('#turmavalidate').val()) {
       setError(5);
    }
    else {
        removeError(5);
    }
}

//menu mobile

let btnMenu = document.getElementById('btn-menu')
let menu = document.getElementById('menu-mobile')
let overlay = document.getElementById('overlay-menu')

btnMenu.addEventListener('click', () => {
    menu.classList.add('abrir-menu')
})

menu.addEventListener('click', () => {
    menu.classList.remove('abrir-menu')
})

overlay.addEventListener('click', () => {
    menu.classList.remove('abrir-menu')
})
