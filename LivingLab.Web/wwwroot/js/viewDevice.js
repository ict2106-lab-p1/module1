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
                // onclick="window.location.href='/Device/View/'+parentElement.getAttribute('data-id');"
                "defaultContent": "<button class='hover:bg-sunset-400 font-large rounded-lg text-sm px-5 py-2.5 editBtn'><i class='bi bi-pencil'></i></button>"
                //"defaultContent": "<button class='text-white bg-gradient-to-br from-purple-600 to-blue-500 hover:bg-gradient-to-bl focus:ring-4 focus:ring-blue-300 dark:focus:ring-blue-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center mr-2 mb-2'>Edit</i></button>"
            },
            {
                "targets": -1,
                "data": null,
                "defaultContent": "<button class='hover:bg-red-300 font-large rounded-lg text-sm px-5 py-2.5 '><i class='bi bi-trash'></i></button>"
                //"defaultContent": "<button class='text-white bg-gradient-to-br from-pink-500 to-orange-400 hover:bg-gradient-to-bl focus:ring-4 focus:ring-pink-200 dark:focus:ring-pink-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center mr-2 mb-2'>Delete</i></button>"
            }],
        "bInfo": false
    });
    
    const addOverlay = document.querySelector('#addOverlay')
    const addBtn = document.querySelector('#addDeviceBtn')
    const closeAddBtn = document.querySelector('.closeAddModal')
    const toggleAddModal = () => {
        addOverlay.classList.toggle('hidden')
        addOverlay.classList.toggle('flex')
    }
    addBtn.addEventListener('click', toggleAddModal)
    closeAddBtn.addEventListener('click', toggleAddModal)

    const editOverlay = document.querySelector('#editOverlay')
    const editBtn = document.querySelector('.editDeviceBtn')
    const closeEditBtn = document.querySelector('.closeEditModal')
    const toggleEditModal = () => {
        editOverlay.classList.toggle('hidden')
        editOverlay.classList.toggle('flex')
    }
    editBtn.addEventListener('click', toggleEditModal)
    closeEditBtn.addEventListener('click', toggleEditModal)
    
    editBtn.addEventListener('click', clickEdit)

});

function clickEdit() {
    $.get('/Device/View/'+this.getAttribute('data-id'),  // url
    function (data, textStatus, jqXHR) {  // success callback
        document.getElementById("grid-device-id").value = data.id
        document.getElementById("grid-serialnum").value = data.serialNo
        document.getElementById("grid-name").value = data.name
        document.getElementById("grid-device-type").value = data.type
        document.getElementById("grid-desc").value = data.description
        document.getElementById("grid-status").value = data.status
        document.getElementById("grid-threshold").value = data.threshold
    });
}