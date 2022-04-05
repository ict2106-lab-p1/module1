/* <remarks>*/
/* Author: Team P1-3*/
/* </remarks>*/

$(document).ready(function() {
    const viewMoreBtns = document.querySelectorAll('#viewMoreBtn')
    
    const viewwMoreEventHandler = () => {
        console.log("View More Device");
        var deviceType = event.target.parentElement.parentElement.firstElementChild.textContent;
        console.log(deviceType)
        document.postDeviceType.deviceType.value = deviceType
        document.postDeviceType.submit();
    }

    viewMoreBtns.forEach(btn => btn.addEventListener('click', viewwMoreEventHandler))

    $('.btnViewMore').each(function() {
        $(this).on('click', function(evt) {
            $this = $(this);
            var dtRow = $this.parents('tr');
            document.postDeviceType.deviceType.value = dtRow[0].cells[0].innerHTML;
            console.log(document.postDeviceType.deviceType.value)
            document.postDeviceType.submit();
        })
    })


    // Add Overlay
    const addOverlay = document.querySelector("#addOverlay");
    const toggleAddModal = () => {
        addOverlay.classList.toggle("hidden");
        addOverlay.classList.toggle("flex");
    };

    $("#addDeviceModalBtn").click(function() {
        fillAddModal(this);
        toggleAddModal();
    });
    $(".closeAddModal").click(function() {
        toggleAddModal();
    });

    /***
     * Display new type input when user choose others
     */
    $("#addDeviceType").change(function() {
        var selectedValue = jQuery(this).val();
        if (selectedValue === "Others") {
            $("#newDeviceType").removeClass("hidden");
        } else {
            $("#newDeviceType").addClass("hidden");
        }
    });

    // Misc Alerts
    $("#addForm").submit(function() {
        alert("Device added successfully and is pending approval!");
    });
});

function fillAddModal(e) {
    $.get("/Device/ViewAddDetails", function(data) {
        console.log(data);
        console.log("Last row Id: " + data.device.id);
        document.getElementById("add-device-id").value = data.device.id + 1;
        // document.getElementById("add-labId").value = data.device.lab.labId
        // document.getElementById("add-labLocation").value = data.device.lab.labLocation
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