const template = `<tr class="whitespace-nowrap">
                    <td class="text-center">{index}</td>
                    <td class="deviceCategory text-center shadow appearance-none border text-gray-700 leading-tight focus:outline-none focus:shadow-outline">
                        <select>
                            <option>Microprocessors</option>
                            <option>AR/VR Devices</option>
                            <option>Smart Sensors</option>
                            <option>Robotics</option>
                            <option>Meters and Monitoring Systems</option>
                            <option>Others</option>
                        </select>
                    </td>
                    <td><input class="deviceId text-center shadow appearance-none border w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" name="Serial Number" id="deviceId" type="text" placeholder="Enter Device Serial No." /></td>
                        <td><input class="energyUsage text-center shadow appearance-none border w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" name="Energy Usage" type="number" value="energyUsage" placeholder="Enter Energy Usage (J)" required/></td>
                        <td><input class="duration text-center shadow appearance-none border w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" name="Interval" type="number" value="duration" placeholder="Enter Interval (min)" required/></td>
                        <td><input class="loggedAt text-center shadow appearance-none border w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" name="Logged At" type="datetime-local" value="loggedAt" placeholder="Enter Logged At Datetime" required/></td>
                        <td><button type="button" class="delete m-2 px-4 py-1 text-lg text-white bg-red-400 rounded" data-index="{index}">Delete</button></td>
                </tr>`;

/**
 * When DOM is ready for JS code to execute.
 */
$(document).ready(function (){
    $("#btnAdd").click(appendRow);
    $(this).on('click', '.delete', deleteRow);
    $("#btnSave").click(save);

})

/**
 * Appends a row of input at the bottom of the table.
 */
function appendRow() {
    const index = $("#logTable tbody tr").length + 1;
    $("#logTable tr:last").after(template.replaceAll("{index}", index));
}

/**
 * Remove the selected row from the table
 * and update the row number accordingly.
 */
function deleteRow() {
    $(this).closest("tr").remove();

    $("#logTable tbody tr").each(function(i) {
        $(this).find("td:first").text(i + 1);
    })
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
                data: {logs: data},
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
 * Retrieve values from each row in the table.
 *
 * @returns Array of objects containing the data.
 */
function getData() {
    let data = [];
    const $table = $("#logTable");
    const $rows = $table.find("tbody > tr");

    $rows.each(function () {
        const deviceCategory = $(this).find("td.deviceCategory").find(":selected").text();
        const deviceId = $(this).find("td > input.deviceId").val();
        const energyUsage = $(this).find("td > input.energyUsage").val();
        const interval = $(this).find("td > input.energyUsage").val();
        const loggedAt = $(this).find("td > input.loggedAt").val();

        data.push({
            DeviceCategory: deviceCategory,
            DeviceSerialNo: deviceId,
            Interval: parseFloat(interval),
            EnergyUsage: parseFloat(energyUsage),
            LoggedDate: loggedAt
        })
    })
    return data;
}