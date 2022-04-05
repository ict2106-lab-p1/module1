let chart;

$(document).ready(async function() {
    const labLocation = $("#labLocation").val();
    const data = await getData(labLocation);
    if (!data) return;

    initLabLocation(data);
    initLineChart(data);
    initDatepicker();
    $("#filter").click(filter);
    $("#resetFilter").click(resetFilter);
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
    const lablocation = $("#selectLabLocation").val();
    const start = $('#start').val();
    const end = $('#end').val();
    const data = await getData(lablocation, start, end);

    // Update the chart
    chart.destroy()
    chart = getLineChart(data, start, end);
}

/**
 * Reset the filter to the default values.
 *
 * Set start and end date to default and
 * trigger the filter button.
 */
function resetFilter(e) {
    e.preventDefault();
    $('#selectLabLocation').val('')
    $("#start").val('');
    $("#end").val('');
    $("#filter").click();
}

/**
 * Display the lab location.
 *
 * @param {Object} data
 */
function initLabLocation(data) {
    const $labLocation = $("#labLocation");
    $labLocation.text(data.LabLocation);
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
 * @param {String} start
 * @param {String} end
 * @returns {Chart} Chart
 */
function getLineChart(data, start = null, end = null) {
    const ctx = $("#lineChart");
    return new Chart(ctx, {
        type: "line",
        data: {
            labels: getDates(start, end),
            datasets: [{
                label: "Energy Usage",
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
        },
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
    for (let i = 0; i < data.selectedLabEnergyUsage.logs.length; i++) {
        logs.push(data.selectedLabEnergyUsage.logs[i].energyUsage);
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
        benchmark.push(data.selectedLabEnergyUsage.lab.energyUsageBenchmark);
    }
    return benchmark;
}

/**
 * Ajax call to get data from the server.
 */
async function getData(labLocation = null, start = null, end = null) {
    const data = {
        LabLocation: labLocation,
        Start: start,
        End: end
    }

    try {
        return await $.ajax({
            url: "/EnergyUsageAnalysis/ViewUsage",
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
 * Get all dates within a date range.
 * If start and end are not provided, return all dates 30 days before today.
 *
 * @param {String} start
 * @param {String} end
 */
function getDates(start = null, end = null) {
    const dates = [];
    if (!start && !end) {
        const today = new Date();

        // Get 30 days ago from today
        const startDate = new Date(new Date().setDate(today.getDate() - 30));

        while (startDate <= today) {
            dates.push(startDate.toLocaleDateString('en-US', {
                day: 'numeric',
                month: 'short'
            }));
            startDate.setDate(startDate.getDate() + 1);
        }

    } else {
        for (let i = new Date(start); i <= new Date(end); i.setDate(i.getDate() + 1)) {
            const date = i.toLocaleDateString('en-US', {
                day: 'numeric',
                month: 'short'
            });
            dates.push(date);
        }
    }

    return dates;
}