/* <remarks>*/
/* Author: Team P1-3*/
/* </remarks>*/
$(document).ready(function() {

    //Add Overlay
    const viewMoreBtns = document.querySelectorAll('#viewMoreBtn')

    const addOverlay = document.querySelector("#addOverlay");
    const toggleAddModal = () => {
        addOverlay.classList.toggle("hidden");
        addOverlay.classList.toggle("flex");
    };

    $("#addAccessoryModalBtn").click(function() {
        fillAddModal(this);
        toggleAddModal();
    });
    $(".closeAddModal").click(function() {
        toggleAddModal();
    });

    /***
     * Display new type input when user choose others
     */
    $("#addAccessoryType").change(function() {
        const selectedValue = jQuery(this).val();
        if (selectedValue === "Others") {
            $("#forNewType").removeClass("hidden");
        } else {
            $("#forNewType").addClass("hidden");
        }
    });

    const viewwMoreEventHandler = () => {
        console.log("View More Accessory");
        var accessoryType = event.target.parentElement.parentElement.firstElementChild.textContent;
        console.log(accessoryType);
        document.postAccessoryType.accessoryType.value = accessoryType
        document.postAccessoryType.labLocation.value =
            document.postAccessoryType.submit();
    }
    viewMoreBtns.forEach(btn => btn.addEventListener('click', viewwMoreEventHandler))

    // Misc Alerts
    $("#addForm").submit(function() {
        alert("Accessory added successfully and is pending approval!");
    });
});

function fillAddModal(e) {
    $.get("/Accessory/AddAccessoryDetails", function(data) {
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
        document.getElementById("labId").value = data.accessory.labId
        document.getElementById("labLocation").value = data.accessory.lab.labLocation
    });
}