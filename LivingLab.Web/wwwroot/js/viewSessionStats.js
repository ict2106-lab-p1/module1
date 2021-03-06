/* <remarks>*/
/* Author: Team P1-3*/
/* </remarks>*/

/*
* Scripts for View Session Statistics DataTable
*/

$(document).ready(function () {
    var table = $('#table_id').DataTable({
        "dom": "<'ui stackable grid'" +
            "<'row'" +
            "<'myfilter'f>" +
            ">" +
            "<'row dt-table'" +
            "<'sixteen wide column'tr>" +
            ">" +
            "<'row'" +
            "<'seven wide column'i>" +
            "<'eight wide column'l>" +
            "<'left aligned nine wide column'p>" +
            ">" +
            ">",
        "columnDefs": [{
            "targets": "_all",
            "className": "dt-center"
        }],
        "bInfo": false
    });
});