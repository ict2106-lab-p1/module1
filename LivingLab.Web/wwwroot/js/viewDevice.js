/* <remarks>*/
/* Author: Team P1-3*/
/* </remarks>*/

$(document).ready(function () {
    //$('#table_id').DataTable();
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
        "columnDefs": [
            {
                "targets": "_all",
                "className": "dt-center"
            },
            {
                "targets": -2,
                "data": null,
                "defaultContent": "<button class='hover:bg-sunset-400 font-large rounded-lg text-sm px-5 py-2.5'><svg xmlns=\"http://www.w3.org/2000/svg\" class=\"h-5 w-5\" viewBox=\"0 0 20 20\" fill=\"currentColor\">\n" +
                "  <path d=\"M13.586 3.586a2 2 0 112.828 2.828l-.793.793-2.828-2.828.793-.793zM11.379 5.793L3 14.172V17h2.828l8.38-8.379-2.83-2.828z\" />\n" +
                "</svg></button>"
                //"defaultContent": "<button class='text-white bg-gradient-to-br from-purple-600 to-blue-500 hover:bg-gradient-to-bl focus:ring-4 focus:ring-blue-300 dark:focus:ring-blue-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center mr-2 mb-2'>Edit</i></button>"
            },
            {
                "targets": -1,
                "data": null,
                "defaultContent": "<button class='hover:bg-red-300 font-large rounded-lg text-sm px-5 py-2.5 '><svg xmlns=\"http://www.w3.org/2000/svg\" class=\"h-5 w-5\" viewBox=\"0 0 20 20\" fill=\"currentColor\">\n" +
                "  <path fill-rule=\"evenodd\" d=\"M9 2a1 1 0 00-.894.553L7.382 4H4a1 1 0 000 2v10a2 2 0 002 2h8a2 2 0 002-2V6a1 1 0 100-2h-3.382l-.724-1.447A1 1 0 0011 2H9zM7 8a1 1 0 012 0v6a1 1 0 11-2 0V8zm5-1a1 1 0 00-1 1v6a1 1 0 102 0V8a1 1 0 00-1-1z\" clip-rule=\"evenodd\" />\n" +
                "</svg></button>"
                //"defaultContent": "<button class='text-white bg-gradient-to-br from-pink-500 to-orange-400 hover:bg-gradient-to-bl focus:ring-4 focus:ring-pink-200 dark:focus:ring-pink-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center mr-2 mb-2'>Delete</i></button>"
            }],
        "bInfo": false
    });
});