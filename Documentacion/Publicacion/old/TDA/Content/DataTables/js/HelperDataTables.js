/*
    Uso de DataTables - http://www.datatables.net

        Para usar las funcionalidades de DataTables se debe de respetar la estructura de carpetas
        incluida en Content/DataTables.

        Un ejemplo de uso de esto se presenta en el listado de personas.

        Esta clase facilita el uso de las funcionalidades más comunes.
*/

// Se modifican los mensajes usados en las grillas
var gridResource = {
    "sProcessing": "Procesando...",
    "sLengthMenu": 'Mostrar ' +
                   '<select>' +
                   '    <option value="10">10</option>' +
                   '    <option value="25">25</option>' +
                   '    <option value="50">50</option>' +
                   '    <option value="100">100</option>' +
                   '    <option value="500">500</option>' +
                   '    <option value="1000">1000</option>' +
                   '    <option value="-1">Todos</option>' +
                   '</select> registros',
    "sZeroRecords": "No se encontraron resultados",
    "sInfo": "Mostrando desde _START_ hasta _END_ de _TOTAL_ registros",
    "sInfoEmpty": "Mostrando desde 0 hasta 0 de 0 registros",
    "sInfoFiltered": "(filtrado de _MAX_ registros en total)",
    "sInfoPostFix": "",
    "sSearch": "Buscar:",
    "sUrl": "",
    "oPaginate": {
        "sFirst": "Primero",
        "sPrevious": "Anterior",
        "sNext": "Siguiente",
        "sLast": "Último"
    }
}

//Script que aplica filtro, ordenado y exportaciones a la tabla incluida en el tag referenciado
function ApplyDataTables(objectID) {
    var cellCount = $('#' + objectID + ' > table >tbody >tr >td').length;
    if (cellCount > 1) {
        $('#' + objectID + ' > table').dataTable({
            'oLanguage': gridResource,
            'sDom': 'T<"clear">lfrtip',
            'oTableTools': {
                'sSwfPath': '../../Content/DataTables/swf/copy_csv_xls_pdf.swf',
                'aButtons':
                 [{
                     'sExtends': 'copy',
                     'sButtonText': 'Portapapeles'
                 },
                {
                    'sExtends': 'print',
                    'sButtonText': 'Imprimir',
                    'sInfo': '<p>Use la funcionalidad de imprimir de su navegador.<p /><p>Para volver presiones Esc.<p />'
                },
                {
                    'sExtends': 'xls',
                    'sButtonText': 'Excel',
                    'sFileName': '*.xls'
                },
                {
                    'sExtends': 'pdf',
                    'sButtonText': 'PDF',
                    'sPdfOrientation': 'landscape'
                }]
            }
        });
    } else {
        $('#' + objectID + ' > table').dataTable({
            'oLanguage': gridResource,

            'sDom': 'T<"clear">lfrtip',
            'oTableTools': {
                'sSwfPath': '../../Content/DataTables/swf/copy_csv_xls_pdf.swf',
                'aButtons':
                 [{
                     'sExtends': 'copy',
                     'sButtonText': 'Portapapeles'
                 },
                {
                    'sExtends': 'print',
                    'sButtonText': 'Imprimir'
                },
                {
                    'sExtends': 'xls',
                    'sButtonText': 'Excel',
                    'sFileName': '*.xls'
                },
                {
                    'sExtends': 'pdf',
                    'sButtonText': 'PDF',
                    'sPdfOrientation': 'landscape'
                }]
            }
        });
    }
}


function ApplyDataTablesOrderAndFilter(objectID, notSorteableColumns) {
    var cellCount = $('#' + objectID + ' > table >tbody >tr >td').length;
    if (cellCount > 1) {
        $('#' + objectID + ' > table').dataTable({
            'oLanguage': gridResource,
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': notSorteableColumns }]
        });
    } else {
        $('#' + objectID + ' > table').dataTable({
            'oLanguage': gridResource
        });
    }
}

function ApplyDataTablesExport(objectID) {
    $('#' + objectID + ' > table').dataTable({
        'oLanguage': gridResource,
        'sDom': 'T<"clear">lfrtip',
        'oTableTools': {
            'sSwfPath': '/Content/DataTables/swf/copy_csv_xls_pdf.swf',
            'aButtons':
             [{
                 'sExtends': 'copy',
                 'sButtonText': 'Portapapeles'
             },
            {
                'sExtends': 'print',
                'sButtonText': 'Imprimir'
            },
            {
                'sExtends': 'xls',
                'sButtonText': 'Excel',
                'sFileName': '*.xls'
            },
            {
                'sExtends': 'pdf',
                'sButtonText': 'PDF',
                'sPdfOrientation': 'landscape'
            }]
        }
    });
}

