$(document).ready(async function() {
    $(".labDiv").each(async function() {
        const labId = $(this).find(".labId").val();
        const canvas = $(this).find(".lineChart");
        const data = await getData(labId);
        initLineChart(canvas, data);
    })
})

/**
 * Setup the line chart with
 * benchmark and actual usage.
 *
 * @param {Object} data
 */
function initLineChart(ctx, data) {
    new Chart(ctx, {
        type: "line",
        data: {
            labels: getDates(),
            datasets: [{
                label: "Actual Usage",
                data: getLogs(data),
                fill: false,
                borderColor: 'rgb(75, 192, 192)',
                tension: 0.1
            }, {
                label: "Benchmark",
                data: getBenchmark(data),
                fill: false,
                borderColor: 'rgb(255, 99, 132)',
                tension: 0.1
            }]
        }
    })
    hideSpinners();
}

/**
 * Get actual usage logs from data.
 *
 * @param {Object} data
 * @returns {Array} logs
 */
function getLogs(data) {
    const logs = [];
    for (let i = 0; i < data.logs.length; i++) {
        logs.push(data.logs[i].energyUsage);
    }
    return logs;
}

/**
 * Hide all spinners.
 */
function hideSpinners() {
    $(".spinner").each(function() {
        $(this).hide();
    });
}

/**
 * Temporary solution to set a straight line
 * for benchmark.
 *
 * @param {Object} data
 * @returns {Array} benchmarks
 */
function getBenchmark(data) {
    const benchmark = [];
    for (let i = 0; i < getDates().length; i++) {
        benchmark.push(data.lab.energyUsageBenchmark);
    }
    return benchmark;
}

/**
 * Ajax call to get data from the server.
 */
async function getData(labId = 1) {
    const data = {
        labId: labId,
    }
    
    try {
        return await $.ajax({
            url: "/EnergyUsage/GetLabUsage",
            type: "POST",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
        })
    } catch (error) {
        console.log(error)
        Swal.fire({
            title: "Error",
            text: "Lab not found",
            icon: "error",
            confirmButtonText: "Ok"
        })
    }
}

/**
 * Get all dates for current month
 */
function getDates() {
    const dates = [];
    const today = new Date();
    const month = today.getMonth();
    const year = today.getFullYear();
    for (let i = 1; i <= new Date(year, month + 1, 0).getDate(); i++) {
        const date = new Date(year, month, i).toLocaleDateString('en-US', {
            day: 'numeric',
            month: 'short'
        });
        dates.push(date);
    }

    return dates;
}