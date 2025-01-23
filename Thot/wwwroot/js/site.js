// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

new DataTable('#lista', {
    paging: false,
    scrollCollapse: true,
    scrollY: '40vh',
    language: {
        search: 'Procurar',
        url: 'https://cdn.datatables.net/plug-ins/1.11.5/i18n/pt-PT.json',
        "info": "Mostrando os registos _START_ de _TOTAL_"
    }
});

// Função para fechar a mensagem de alerta
$('.close-alert').click(function () {
    $('.alert').hide('hide');
});
