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
            }],
        "bInfo": false
    });

<<<<<<< HEAD
});
=======
    

});
  
>>>>>>> 5b141044963b93d42f188e3562dc8090c95eea28
