const template = `<tr>
                    <td>{index}</td>
                    <td class="serial-no text-center">{deviceSerialNumber}</td>
                    <td><input class="energy shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" type="number" value=""/></td>
                    <td><input class="interval shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" type="number" value=""/></td>
                    <td><input class="logged-date shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" type="text" value=""/></td>
                    <td><button type="button" class="btn btn-close bg-red-500" data-index="{index}">Delete</button></td>
                </tr>`;


$(document).ready(function (){
    $("#btnAdd").click(appendInputRow);
    $("#btnSave").click(save);
})


function appendInputRow() {
    const deviceSerialNumber = $("#deviceSerialNumber").val();
    const index = $("#logTable tbody tr").length + 1;
    $("#logTable tr:last").after(template.replaceAll("{index}", index).replace("{deviceSerialNumber}", deviceSerialNumber));
}

function save(e) {
    e.preventDefault();
    const $table = $("#logTable");
    const $rows = $table.find("tbody > tr");
    let data = [];
    $rows.each(function () {
        const serialNumber = $(this).find("td.serial-no").text();
        const energyUsage = $(this).find("td > input.energy").val();
        const interval = $(this).find("td > input.interval").val();
        const loggedAt = $(this).find("td > input.logged-date").val();
        data.push({
            serialNumber,
            energyUsage,
            interval,
            loggedAt
        })
    })
    console.log(data)
}