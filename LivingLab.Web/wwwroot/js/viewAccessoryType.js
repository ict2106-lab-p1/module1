/* <remarks>*/
/* Author: Team P1-3*/
/* </remarks>*/
$(document).ready(function () {

    var table = $('#table_id').DataTable({
        "dom": "<'ui stackable grid'"+
            "<'row'"+
            "<'myfilter'f>"+
            ">"+
            "<'row dt-table'"+
            "<'sixteen wide column'tr>"+
            ">"+
            "<'row'"+
            "<'seven wide column'i>"+
            "<'eight wide column'l>"+
            "<'left aligned nine wide column'p>"+
            ">"+
            ">",
        "columnDefs": [
            {
                "targets" : "_all", 
                "className" : "dt-center"
            },
            {
            "targets": -1,
            "data": null,
            // "defaultContent": "<button class='hover:bg-sunset-400 font-large rounded-lg text-sm px-5 py-2.5'><i class='bi bi-pencil'></i></button>"
            "defaultContent": "<button class='btnViewMore text-white bg-gradient-to-br from-purple-600 to-blue-500 hover:bg-gradient-to-bl focus:ring-4 focus:ring-blue-300 dark:focus:ring-blue-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center mr-2 mb-2'>View More</i></button>"
        }],
        "bInfo": false
    });

    $('.btnViewMore').each(function() {
        $(this).on('click', function(evt){
            $this = $(this);
            var dtRow = $this.parents('tr');
            console.log(dtRow[0].cells[0].innerHTML)
            document.postAccessoryType.accessoryType.value = dtRow[0].cells[0].innerHTML;
            document.postAccessoryType.submit();
        })
    })
});