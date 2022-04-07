let table;
let prevDate;

$(document).ready(async function() {
    let data = await getData();
    prevDate = data[0].loggedDate;
    initTable(data);
    
    setInterval(async function() {
        data = await getData();
        if (data[0].loggedDate !== prevDate) {
            prevDate = data[0].loggedDate;
            console.log("Refreshing data...");
            table.destroy();
            initTable(data);
        }
    }, 2000);
})

function initTable(data) {
   table = $("#logs").DataTable({
        data: data,
        columns: [
            { data: "device.serialNo" },
            { data: "lab.labLocation" },
            { data: "energyUsage" },
            { data: "loggedDate" }
        ],
        searching: false
    });
}

async function getData() {
    try {
        return await $.ajax({
            url: "/api/energylog/GetLogs/50",
            type: "GET",
        })
    } catch (error) {
        console.log(error);
    }
}