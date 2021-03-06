/* <remarks>*/
/* Author: Team P1-3*/
/* </remarks>*/

/*
* Scripts for View Device DataTable, Add/Edit/Delete Device Modal
*/

$(document).ready(function () {
    var table = $("#table_id").DataTable({
        dom: "<'ui stackable grid'" +
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
        columnDefs: [{
            targets: "_all",
            className: "dt-center",
        },
            {
                targets: -2,
                data: null,
                defaultContent: '<button class=\'hover:bg-sunset-400 font-large rounded-lg text-sm px-5 py-2.5 editBtn\'><svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor"> <path d="M13.586 3.586a2 2 0 112.828 2.828l-.793.793-2.828-2.828.793-.793zM11.379 5.793L3 14.172V17h2.828l8.38-8.379-2.83-2.828z" /> </svg></button>',
            },
            {
                targets: -1,
                data: null,
                defaultContent: '<button class=\'hover:bg-red-300 font-large rounded-lg text-sm px-5 py-2.5 \'><svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">\n' +
                    '  <path fill-rule="evenodd" d="M9 2a1 1 0 00-.894.553L7.382 4H4a1 1 0 000 2v10a2 2 0 002 2h8a2 2 0 002-2V6a1 1 0 100-2h-3.382l-.724-1.447A1 1 0 0011 2H9zM7 8a1 1 0 012 0v6a1 1 0 11-2 0V8zm5-1a1 1 0 00-1 1v6a1 1 0 102 0V8a1 1 0 00-1-1z" clip-rule="evenodd" />\n' +
                    "</svg></button>",
            },
        ],
        bInfo: false,
    });

    // Add Overlay
    const addOverlay = document.querySelector("#addOverlay");
    const toggleAddModal = () => {
        addOverlay.classList.toggle("hidden");
        addOverlay.classList.toggle("flex");
    };

    $("#addDeviceModalBtn").click(function () {
        fillAddModal(this);
        toggleAddModal();
    });
    $(".closeAddModal").click(function () {
        toggleAddModal();
    });

    /***
     * Display new type input when user choose others
     */
    $("#addDeviceType").change(function () {
        var selectedValue = jQuery(this).val();
        if (selectedValue === "Others") {
            $("#newDeviceType").removeClass("hidden");
        } else {
            $("#newDeviceType").addClass("hidden");
        }
    });

    // Edit Overlay
    const editOverlay = document.querySelector("#editOverlay");
    const toggleEditModal = () => {
        editOverlay.classList.toggle("hidden");
        editOverlay.classList.toggle("flex");
    };
    $(".editDeviceBtn").click(function () {
        fillEditModal(this);
        toggleEditModal();
    });
    $(".closeEditModal").click(function () {
        toggleEditModal();
    });

    // Delete Overlay
    const deleteOverlay = document.querySelector("#deleteOverlay");
    const toggleDeleteModal = () => {
        deleteOverlay.classList.toggle("hidden");
        deleteOverlay.classList.toggle("flex");
    };
    $(".deleteDeviceBtn").click(function () {
        fillDeleteModal(this);
        toggleDeleteModal();
    });
    $(".closeDeleteModal").click(function () {
        toggleDeleteModal();
    });

    $("#del-cfm").on("input", function () {
        if (this.value === $("#deviceName").text()) {
            $("#delBtn").removeClass("disabled");
        } else {
            $("#delBtn").addClass("disabled");
        }
    });

    // Misc Alerts
    $("#addForm").submit(function () {
        alert("Device added successfully and is pending approval!");
    });

    $("#editForm").submit(function () {
        alert("Device edited successfully!");
    });

    $("#delForm").submit(function () {
        alert("Device deleted successfully!");
    });

});

function fillAddModal(e) {
    $.get("/Device/ViewAddDetails", function (data) {
        console.log(data);
        console.log("Last row Id: " + data.device.id);
        document.getElementById("add-device-id").value = data.device.id + 1;
        var deviceTypeDDL = document.getElementById("addDeviceType")
        if (deviceTypeDDL.length === 0) {
            for (var i = 0; i < data.deviceTypes.length; i++) {
                var element = document.createElement("option")
                element.textContent = data.deviceTypes[i]
                element.value = data.deviceTypes[i]
                deviceTypeDDL.appendChild(element)
            }
            var last = document.createElement("option");
            last.textContent = "Others";
            last.value = "Others";
            deviceTypeDDL.appendChild(last);
        }
    });
}

function fillEditModal(e) {
    $.get(
        "/Device/View/" + e.getAttribute("data-id"), // url
        function (data, textStatus, jqXHR) {
            // success callback
            console.log("Device data returned: ", data);
            document.getElementById("edit-device-id").value = data.id;
            document.getElementById("edit-serialnum").value = data.serialNo;
            document.getElementById("edit-name").value = data.name;
            document.getElementById("edit-device-type").value = data.type;
            document.getElementById("edit-desc").value = data.description;
            document.getElementById("edit-status").value = data.status;
            document.getElementById("edit-threshold").value = data.threshold;
            document.getElementById("editLabLocation").value = data.lab.labLocation;
            console.log(document.getElementById("editLabLocation").value)
        }
    );
}

function fillDeleteModal(e) {
    $.get(
        "/Device/View/" + e.getAttribute("data-id"), // url
        function (data, textStatus, jqXHR) {
            // success callbackdelete
            document.getElementById("del-device-id").value = data.id;
            document.getElementById("deviceName").innerHTML = data.name;
            document.getElementById("del-device-name").value = data.name;
            document.getElementById("deleteDeviceType").value = data.type;
            document.getElementById("deleteLabLocation").value = data.lab.labLocation;
        }
    );
}
