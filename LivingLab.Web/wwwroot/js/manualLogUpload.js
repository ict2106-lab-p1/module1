const template = `<div class="log-div mt-5 flex flex-col bg-white p-5 shadow-lg rounded gap-4">
                    <div class="flex justify-end">
                        <button type="button" class="delete text-red-500 hover:bg-red-100 hover:scale-125 rounded-full p-2 ease-in-out duration-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="inherit" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <line x1="18" y1="6" x2="6" y2="18"></line>
                                <line x1="6" y1="6" x2="18" y2="18"></line>
                            </svg>
                        </button>
                    </div>
                <div class="flex flex-col justify-between lg:flex-row lg:space-x-3">
                <div class="flex flex-row lg:flex-col justify-center lg:space-y-2">
                <h3 class="text-center text-gray-600 m-auto lg:m-0">Lab Location</h3>
                    <select class="labs select w-full max-w-xs select-bordered"></select>
                    </div>
                    <div class="flex flex-row lg:flex-col justify-center lg:space-y-2">
                        <h3 class="text-center text-gray-600 m-auto lg:m-0">Device Category</h3>
                        <select class="deviceCategory select w-full max-w-xs select-bordered">
                            <option>Microprocessors</option>
                            <option>AR/VR Devices</option>
                            <option>Smart Sensors</option>
                            <option>Robotics</option>
                            <option>Meters and Monitoring Systems</option>
                            <option>Others</option>
                        </select>
                    </div>
                    <div class="flex flex-row lg:flex-col justify-center lg:space-y-2">
                        <h3 class="text-center text-gray-600 m-auto lg:m-0">Serial No.</h3>
                        <input class="deviceId input input-bordered w-full max-w-xs" name="Serial Number" id="deviceId" type="text" placeholder="Enter Device Serial No." />
                    </div>
                    <div class="flex flex-row lg:flex-col justify-center lg:space-y-2">
                        <h3 class="text-center text-gray-600 m-auto lg:m-0">Energy Usage (W)</h3>
                        <input class="energyUsage input input-bordered w-full max-w-xs" name="Energy Usage" type="number" value="energyUsage" placeholder="Enter Energy Usage (W)" required/>
                    </div>
                    <div class="flex flex-row lg:flex-col justify-center lg:space-y-2">
                        <h3 class="text-center text-gray-600 m-auto lg:m-0">Interval (min)</h3>
                        <input class="interval input input-bordered w-full max-w-xs" name="Interval" type="number" value="interval" placeholder="Enter Interval (min)" required/>
                    </div>
                    <div class="flex flex-row lg:flex-col justify-center lg:space-y-2">
                        <h3 class="text-center text-gray-600 m-auto lg:m-0">Logged At</h3>
                        <input class="loggedAt input input-bordered w-full max-w-xs" name="Logged At" type="datetime-local" value="loggedAt" placeholder="Enter Logged At Datetime" required/>
                    </div>
                </div>
                </div>`

/**
 * When DOM is ready for JS code to execute.
 */
$(document).ready(function (){
    $("#btnAdd").click(appendRow);
    $(this).on('click', '.delete', deleteRow);
    $("#btnSave").click(save);
})

/**
 * Appends a new div for input.
 */
function appendRow() {
    const $form = $("#manualLogForm");
    let labOptions = "";
    for (let i = 0; i < labs.length; i++) {
        labOptions += `<option>${labs[i].labLocation}</option>`
    }
    if ($form.find("div.log-div").length === 0)
        $form.prepend(template);
    else 
        $form.find("div.log-div:last").after(template);
    $form.find("div.log-div:last").find(".labs").append(labOptions)
}

/**
 * Remove the selected row from the table
 * and update the row number accordingly.
 */
function deleteRow() {
    $(this).closest("div.log-div").remove();
}

/**
 * Ajax call to save all logs into db.
 *
 * @param e: Target button
 */
function save(e) {
    e.preventDefault();
    if (validate() === false) return
    
    const data = getData();
    console.log(data);

    Swal.fire({
        title: 'Do you want to add this log?',
        icon: 'warning',
        showCancelButton: true,
        reverseButtons: true,
        confirmButtonColor: '#363740',
        cancelButtonColor: '#C0C0C0',
        confirmButtonText: 'Yes',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/ManualLogs/Save",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                success: function(response) {
                    Swal.fire({
                        title: 'Log Added',
                        icon: 'success',
                        showDenyButton: true,
                        reverseButtons: true,
                        confirmButtonColor: '#363740',
                        denyButtonColor: '#C0C0C0',
                        confirmButtonText: 'Add New Logs',
                        denyButtonText: 'Back to Dashboard'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            /*redirects to add new logs page (subject to changes)*/
                            window.location.href = "ManualLogUpload";
                        } else if (result.isDenied) {
                            /*redirects to dashboard page (subject to changes)*/
                            window.location.href = "/";
                        }
                    })
                },
                error: function(response) {
                    Swal.fire({
                        title: "Error!",
                        text: "Something went wrong!",
                        type: "error"
                    })
                }
            });
        }
    })
}

/**
 * Retrieve values from each row in the form.
 *
 * @returns Array of objects containing the data.
 */
function getData() {
    let data = [];
    const $form = $("#manualLogForm");
    const $rows = $form.find("div.log-div");

    $rows.each(function () {
        const labLocation = $(this).find("select.labs").find(":selected").text();
        const deviceCategory = $(this).find("select.deviceCategory").find(":selected").text();
        const deviceId = $(this).find("input.deviceId").val();
        const energyUsage = $(this).find("input.energyUsage").val();
        const interval = $(this).find("input.interval").val();
        const loggedAt = $(this).find("input.loggedAt").val();

        data.push({
            LabLocation: labLocation,
            DeviceCategory: deviceCategory,
            DeviceSerialNo: deviceId,
            Interval: parseFloat(interval),
            EnergyUsage: parseFloat(energyUsage),
            LoggedDate: loggedAt
        })
    })
    return data;
}