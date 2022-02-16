$(document).ready(function (){
    $("#btnAdd").click(appendInputRow);
})

const template = `<tr>
                    <td class="text-center">{deviceSerialNumber}</td>
                    <td><input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" type="number" value=""/></td>
                    <td><input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" type="number" value=""/></td>
                    <td><input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" type="number" value=""/></td>
                    <td><button class="btn btn-close bg-red-500">Delete</button></td>
                </tr>`;

function appendInputRow() {
    const deviceSerialNumber = $("#deviceSerialNumber").val();
    $("#logTable tr:last").after(template.replace("{deviceSerialNumber}", deviceSerialNumber));
}