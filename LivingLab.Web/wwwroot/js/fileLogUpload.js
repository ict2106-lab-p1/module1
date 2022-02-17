const template = `<tr class="whitespace-nowrap">
                    <td class="text-center">{index}</td>
                    <td class="serial-no text-center">{deviceSerialNumber}</td>
                    <td><input class="energy text-center shadow appearance-none border w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" type="number" value="" required/></td>
                    <td><input class="interval text-center shadow appearance-none border w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" type="number" value="" required/></td>
                    <td><input class="logged-date text-center shadow appearance-none border w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" type="datetime-local" value="" required/></td>
                    <td><button type="button" class="delete px-4 py-1 text-sm text-white bg-red-400 rounded" data-index="{index}">Delete</button></td>
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
    const deviceSerialNumber = $("#deviceSerialNumber").val();
    const index = $("#logTable tbody tr").length + 1;
    $("#logTable tr:last").after(template.replaceAll("{index}", index).replace("{deviceSerialNumber}", deviceSerialNumber));
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
    const data = getData();
    console.log(data);
    $.ajax({
        url: "/ManualLogs/Save",
        type: "POST",
        data: {logs: data},
        success: function(response) {
            Swal.fire({
                title: "Success!",
                text: "Logs saved successfully!",
                icon: "success",
                confirmButtonColor: '#363740'
            }).then(function() {
                window.location.href = "/ManualLogs/FileUpload";
            })
        },
        error: function(response) {
            Swal.fire({
                title: "Error!",
                text: "Something went wrong!",
                icon: "error"
            })
        }
    });
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
        const serialNumber = $(this).find("td.serial-no").text();
        const energyUsage = $(this).find("td > input.energy").val();
        const interval = $(this).find("td > input.interval").val();
        const loggedAt = $(this).find("td > input.logged-date").val();

        data.push({
            DeviceSerialNo: serialNumber,
            EnergyUsage: parseFloat(energyUsage),
            Interval: parseFloat(interval),
            LoggedDate: loggedAt
        })
    })
    return data;
}