let chart;

$(document).ready(async function() {
    const labId = $("#labId").val();
    const data = await getData(labId);
    if (!data) return;
    
    initLineChart(data);
    initDatepicker();
    $("#filter").click(filter);
})

/**
 * Initialize the datepicker
 */
function initDatepicker() {
    const $start = $('#start');
    const $end = $('#end');
    const today = new Date();
    const firstDay = new Date(today.getFullYear(), today.getMonth(), 1);
    const oneMonthAgo = new Date(today.getFullYear(), today.getMonth() - 1, today.getDate());
    
    $start.datepicker({
        defaultDate: firstDay,
        minDate: oneMonthAgo,
        maxDate: today,
        onSelect: function(dateText) {
            $end.datepicker("option", "minDate", dateText);
        }
    })
    
    $end.datepicker({
        defaultDate: today,
        maxDate: today,
        onSelect: function(dateText) {
            $start.datepicker("option", "maxDate", dateText);
        }
    });
}

/**
 * Filter the data.
 */
async function filter(e) {
    e.preventDefault();
    const labId = $("#labId").val();
    const start = $('#start').val();
    const end = $('#end').val();
    const data = await getData(labId, start, end);
    
    // Update the chart
    chart.destroy()
    chart = getLineChart(data);
}

/**
 * Setup the line chart with
 * benchmark and actual usage.
 * 
 * @param {Object} data
 */
function initLineChart(data) {
    chart = getLineChart(data);
}

/**
 * Get the line chart.
 * 
 * @param {Object} data
 * @returns {Chart} Chart
 */
function getLineChart(data) {
    const ctx = $("#lineChart");
    return new Chart(ctx, {
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
async function getData(labId = 1, start = null, end = null) {
    const data = {
        labId: labId,
        Start: start,
        End: end
    }
    
    try {
        return await $.ajax({
            url: "/EnergyUsage/ViewUsage",
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