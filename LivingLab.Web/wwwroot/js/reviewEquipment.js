$(document).ready(function () {
    var deviceTable = $("#deviceTable").DataTable({
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
                targets: -1,
                data: null,
                // defaultContent: '<button class=\'hover:bg-red-300 font-large rounded-lg text-sm px-5 py-2.5 \'><svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">\n' +
                //     '  <path fill-rule="evenodd" d="M9 2a1 1 0 00-.894.553L7.382 4H4a1 1 0 000 2v10a2 2 0 002 2h8a2 2 0 002-2V6a1 1 0 100-2h-3.382l-.724-1.447A1 1 0 0011 2H9zM7 8a1 1 0 012 0v6a1 1 0 11-2 0V8zm5-1a1 1 0 00-1 1v6a1 1 0 102 0V8a1 1 0 00-1-1z" clip-rule="evenodd" />\n' +
                //     "</svg></button>",
                "defaultContent": "<button type='button' class='deviceItem text-white bg-gradient-to-br from-pink-500 to-orange-400 hover:bg-gradient-to-bl focus:ring-4 focus:ring-pink-200 dark:focus:ring-pink-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center mr-2 mb-2'>Review</button>"
            },
        ],
        bInfo: false,
    });
    var accessoryTable = $("#accessoryTable").DataTable({
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
                targets: -1,
                data: null,
                // defaultContent: '<button class=\'hover:bg-red-300 font-large rounded-lg text-sm px-5 py-2.5 \'><svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">\n' +
                //     '  <path fill-rule="evenodd" d="M9 2a1 1 0 00-.894.553L7.382 4H4a1 1 0 000 2v10a2 2 0 002 2h8a2 2 0 002-2V6a1 1 0 100-2h-3.382l-.724-1.447A1 1 0 0011 2H9zM7 8a1 1 0 012 0v6a1 1 0 11-2 0V8zm5-1a1 1 0 00-1 1v6a1 1 0 102 0V8a1 1 0 00-1-1z" clip-rule="evenodd" />\n' +
                //     "</svg></button>",
                "defaultContent": "<button type='button' class='accessoryItem text-white bg-gradient-to-br from-pink-500 to-orange-400 hover:bg-gradient-to-bl focus:ring-4 focus:ring-pink-200 dark:focus:ring-pink-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center mr-2 mb-2'>Review</button>"
            },
        ],
        bInfo: false,
    });

    //Add Overlay
    const overlay = document.querySelector("#equipmentOverlay");
    const closeBtn = document.querySelector(".closeModal");

    const deviceId = document.querySelector("#deviceId")
    const deviceReviewStatus = document.querySelector("#deviceReviewStatus")
    const submitDevice = document.querySelector("#submitDevice")
    

    function toggleModal () {
        console.log("click");
        overlay.classList.toggle("hidden");
        overlay.classList.toggle("flex");
    }
    var deviceItemSelected = false
    var accessoryItemSelected = false
    var itemId
    $(".deviceItem").each(function(){
        $(this).on('click', function(evt){
            accessoryItemSelected = false
            deviceItemSelected = true
            $this = $(this)
            const dtRow = $this.parents('tr');
            itemId = dtRow[0].cells[0].innerHTML
            const serialNo = dtRow[0].cells[4].innerHTML
            const type = dtRow[0].cells[2].innerHTML
            const confirmationMsg = "Do you want to approve or reject this device?"
            const header = "Review Newly Added Device"
            toggleModal()
            // populate model
            populateModel(serialNo, type, confirmationMsg, header)
        })
    })
    $(".accessoryItem").each(function(){
        $(this).on('click', function(evt){
            deviceItemSelected = false
            accessoryItemSelected = true
            $this = $(this)
            const dtRow = $this.parents('tr');
            itemId = dtRow[0].cells[0].innerHTML
            const serialNo = dtRow[0].cells[1].innerHTML  // treat as name for accessory
            const type = dtRow[0].cells[2].innerHTML
            const confirmationMsg = "Do you want to approve or reject this accessory?"
            const header = "Review Newly Added Accessory"
            toggleModal()
            // populate model
            populateModel(serialNo, type, confirmationMsg, header)
        })
    })
    closeBtn.addEventListener("click", function () {
        toggleModal()
    });
    
    const approveBtn = document.querySelector("#approveBtn")
    const rejectBtn = document.querySelector("#rejectBtn")
    approveBtn.addEventListener("click", function() {
        makeDecision(deviceItemSelected, accessoryItemSelected, itemId, "Approved")
        toggleModal()
    })
    rejectBtn.addEventListener("click", function(){
        makeDecision(deviceItemSelected, accessoryItemSelected,  itemId, "Rejected")
        toggleModal()
    })
    
})


function populateModel(serialNo, type, confirmationMsg, header){
    document.getElementById("modalHeader").innerHTML = header
    document.getElementById("serialNo").innerHTML = serialNo
    document.getElementById("type").innerHTML = type
    document.getElementById("confirmationMsg").innerHTML = confirmationMsg
}

function makeDecision(deviceItemSelected, accessoryItemSelected, itemId, reviewStatus){
    if (deviceItemSelected && !accessoryItemSelected){
        document.querySelector("#deviceId").value = itemId
        document.querySelector("#deviceReviewStatus").value = reviewStatus
        console.log(document.querySelector("#deviceId").value)
        console.log(document.querySelector("#deviceReviewStatus").value)
        document.deviceForm.submit()
    }
    if (!deviceItemSelected && accessoryItemSelected){
        document.querySelector("#accessoryId").value = itemId
        document.querySelector("#accessoryReviewStatus").value = reviewStatus
        document.accessoryForm.submit()
    }
}