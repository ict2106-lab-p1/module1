/* <remarks>*/
/* Author: Team P1-3*/
/* </remarks>*/

/*
* Scripts for View Accessory DataTable, Add/Edit/Delete Accessory Modal
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
                defaultContent: '<button class=\'hover:bg-sunset-400 font-large rounded-lg text-sm px-5 py-2.5\'><svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor"><path d="M13.586 3.586a2 2 0 112.828 2.828l-.793.793-2.828-2.828.793-.793zM11.379 5.793L3 14.172V17h2.828l8.38-8.379-2.83-2.828z" /></svg></button>',
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

    //Add Overlay
    const addOverlay = document.querySelector("#addOverlay");
    const toggleAddModal = () => {
        addOverlay.classList.toggle("hidden");
        addOverlay.classList.toggle("flex");
    };

    $("#addAccessoryModalBtn").click(function () {
        fillAddModal(this);
        toggleAddModal();
    });
    $(".closeAddModal").click(function () {
        toggleAddModal();
    });

    /***
     * Display new type input when user choose others
     */
    $("#addAccessoryType").change(function () {
        const selectedValue = jQuery(this).val();
        if (selectedValue === "Others") {
            $("#forNewType").removeClass("hidden");
        } else {
            $("#forNewType").addClass("hidden");
        }
    });

    // Edit Overlay
    const editOverlay = document.querySelector("#editOverlay");
    const toggleEditModal = () => {
        editOverlay.classList.toggle("hidden");
        editOverlay.classList.toggle("flex");
    };
    $(".editAccessoryBtn").click(function () {
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
    $(".deleteAccessoryBtn").click(function () {
        fillDeleteModal(this);
        toggleDeleteModal();
    });
    $(".closeDeleteModal").click(function () {
        toggleDeleteModal();
    });

    $("#del-cfm").on("input", function () {
        if (this.value === $("#accessory-name").text()) {
            $("#delBtn").removeClass("disabled");
        } else {
            $("#delBtn").addClass("disabled");
        }
    });

    // Misc Alerts
    $("#addForm").submit(function () {
        alert("Accessory added successfully and is pending approval!");
    });

    $("#editForm").submit(function () {
        alert("Accessory edited successfully!");
    });

    $("#delForm").submit(function () {
        alert("Accessory deleted successfully!");
    });

});

function fillAddModal(e) {
    $.get("/Accessory/AddAccessoryDetails", function (data) {
        document.getElementById("accessoryId").value = data.accessory.id + 1;
        var accessoryTypeDDL = document.getElementById("addAccessoryType");
        if (accessoryTypeDDL.length === 0) {
            for (var i = 0; i < data.accessoryTypes.length; i++) {
                var element = document.createElement("option");
                element.textContent = data.accessoryTypes[i].type;
                element.value = data.accessoryTypes[i].id;
                accessoryTypeDDL.appendChild(element);
            }
            var last = document.createElement("option");
            last.textContent = "Others";
            last.value = "Others";
            accessoryTypeDDL.appendChild(last);
        }
    });
}

function fillEditModal(e) {
    $.get(
        "/Accessory/GetEditDetails/" + e.getAttribute("data-id"), // url
        function (data, textStatus, jqXHR) {
            // success callback
            console.log("Device data returned: ", data);
            document.getElementById("editAccessoryId").value = data.accessory.id;
            document.getElementById("AccessoryId").value = data.accessory.id;
            var accessoryTypeDDL = document.getElementById("editAccessoryType");
            // populate accessoryType ddl
            if (accessoryTypeDDL.length === 0) {
                // populate the dropdown list
                for (var i = 0; i < data.accessoryTypes.length; i++) {
                    var element = document.createElement("option");
                    element.textContent = data.accessoryTypes[i].type;
                    element.value = data.accessoryTypes[i].id;
                    accessoryTypeDDL.appendChild(element);
                }
            }
            // set the selected value to specific type
            for (var option of accessoryTypeDDL.options) {
                console.log(data.accessory.accessoryTypeId);
                if (option.value == data.accessory.accessoryTypeId) {
                    option.selected = true;
                }
            }
            //populate borrowers ddl
            var borrowerDDL = document.getElementById("editLabUser");
            if (borrowerDDL.length === 0) {
                // populate the dropdown list
                for (var i = 0; i < data.userList.length; i++) {
                    var element = document.createElement("option");
                    element.textContent = data.userList[i].firstName + " " + data.userList[i].lastName;
                    element.value = data.userList[i].id;
                    borrowerDDL.appendChild(element);
                }
            }
            document.getElementById("AccessoryType").value =
                accessoryTypeDDL.options[accessoryTypeDDL.selectedIndex].textContent;
            document.getElementById("editAccessoryName").value =
                data.accessory.name;
            document.getElementById("editDescription").value =
                data.accessory.accessoryType.description;
            document.getElementById("editStatus").value = data.accessory.status;
            document.getElementById("editDueDate").value = data.accessory.dueDate;
            document.getElementById("editLabUser").value = data.accessory.labUserId;
            document.getElementById("editLabLocation").value = data.accessory.lab.labLocation
            if (data.accessory.accessoryType.borrowable == false) {
                document.getElementById("editDueDate").disabled = true;
                document.getElementById("editLabUser").disabled = true;
                document.getElementById("editDueDate").classList.add("bg-gray-100");
                document.getElementById("editLabUser").classList.add("bg-gray-100");
            } else {
                document.getElementById("editDueDate").disabled = false;
                document.getElementById("editLabUser").disabled = false;
                document.getElementById("editDueDate").classList.remove("bg-gray-100");
                document.getElementById("editLabUser").classList.remove("bg-gray-100");
            }
        }
    );
}

function fillDeleteModal(e) {
    $.get(
        "/Accessory/GetDeleteDetails/" + e.getAttribute("data-id"), // url
        function (data, textStatus, jqXHR) {
            // success callback
            console.log(data);
            document.getElementById("del-accessory-id").value = data.id;
            document.getElementById("accessory-name").innerHTML =
                data.name;
            document.getElementById("del-accessory-name").value =
                data.name;
            document.getElementById("del-accessory-type").value =
                data.accessoryType.type;
            document.getElementById("deleteLabLocation").value = data.lab.labLocation;
            console.log(document.getElementById("deleteLabLocation").value);
            console.log(document.getElementById("del-accessory-type").value);
        }
    );
}