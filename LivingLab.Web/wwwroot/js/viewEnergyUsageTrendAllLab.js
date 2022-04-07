let allEnergyUsageTrendChart;

$(document).ready(async function () {
    const data = await getDataAllEnergyUsageTrend();
    if (!data) return;

    initLineChartAllEnergyUsageTrend(data);
    initDatepickerAllEnergyUsageTrend();
    $("#filterAllEnergyUsageTrend").click(filterAllEnergyUsageTrend);
    $("#resetFilterAllEnergyUsageTrend").click(resetFilterAllEnergyUsageTrend);
})

/**
 * Initialize the datepicker
 */
function initDatepickerAllEnergyUsageTrend() {
    const $startAllEnergyUsageTrend = $('#startAllEnergyUsageTrend');
    const $endAllEnergyUsageTrend = $('#endAllEnergyUsageTrend');
    const todayAllEnergyUsageTrend = new Date();
    const firstDayAllEnergyUsageTrend = new Date(todayAllEnergyUsageTrend.getFullYear(), todayAllEnergyUsageTrend.getMonth(), 1);
    const oneMonthAgoAllEnergyUsageTrend = new Date(todayAllEnergyUsageTrend.getFullYear(), todayAllEnergyUsageTrend.getMonth() - 1, todayAllEnergyUsageTrend.getDate());

    $startAllEnergyUsageTrend.datepicker({
        defaultDate: firstDayAllEnergyUsageTrend,
        minDate: oneMonthAgoAllEnergyUsageTrend,
        maxDate: todayAllEnergyUsageTrend,
        onSelect: function (dateText) {
            $endAllEnergyUsageTrend.datepicker("option", "minDate", dateText);
        }
    })

    $endAllEnergyUsageTrend.datepicker({
        defaultDate: todayAllEnergyUsageTrend,
        maxDate: todayAllEnergyUsageTrend,
        onSelect: function (dateText) {
            $startAllEnergyUsageTrend.datepicker("option", "maxDate", dateText);
        }
    });
}

/**
 * Filter the data.
 */
async function filterAllEnergyUsageTrend(e) {
    e.preventDefault();
    const startAllEnergyUsageTrend = $('#startAllEnergyUsageTrend').val();
    const endAllEnergyUsageTrend = $('#endAllEnergyUsageTrend').val();
    const dataAllEnergyUsageTrend = await getDataAllEnergyUsageTrend(startAllEnergyUsageTrend, endAllEnergyUsageTrend);

    // Update the chart
    allEnergyUsageTrendChart.destroy()
    allEnergyUsageTrendChart = getLineChartAllEnergyUsageTrend(dataAllEnergyUsageTrend, startAllEnergyUsageTrend, endAllEnergyUsageTrend);
}

/**
 * Reset the filter to the default values.
 *
 * Set start and end date to default and
 * trigger the filter button.
 */
function resetFilterAllEnergyUsageTrend(e) {
    e.preventDefault();
    $("#startAllEnergyUsageTrend").val('');
    $("#endAllEnergyUsageTrend").val('');
    $("#filterAllEnergyUsageTrend").click();
}

/**
 * Setup the line chart with
 * benchmark and actual usage.
 *
 * @param {Object} data
 */
function initLineChartAllEnergyUsageTrend(data) {
    allEnergyUsageTrendChart = getLineChartAllEnergyUsageTrend(data);
}

/**
 * Get the line chart.
 *
 * @param {Object} data
 * @param {String} start
 * @param {String} end
 * @returns {Chart} Chart
 */
function getLineChartAllEnergyUsageTrend(data, start = null, end = null) {
    const ctx = $("#lineChartAllEnergyUsageTrend");
    return new Chart(ctx, {
        type: "line",
        data: {
            labels: getDatesAllEnergyUsageTrend(start, end),
            datasets: [{
                label: "Energy Usage",
                data: getLogsAllEnergyUsageTrend(data),
                fill: false,
                borderColor: 'rgb(75, 192, 192)',
                tension: 0.1
            }, {
                label: "Benchmark",
                data: getBenchmarkAllEnergyUsageTrend(data),
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
function getLogsAllEnergyUsageTrend(data) {
    const logsAllEnergyUsageTrend = [];
    // for (let i = 0; i < data.logs.length; i++) {
    for (let i = 0; i < data.allLabEnergyUsage.logs.length; i++) {
        logsAllEnergyUsageTrend.push(data.allLabEnergyUsage.logs[i].energyUsage);
    }
    return logsAllEnergyUsageTrend;
}

/**
 * Temporary solution to set a straight line
 * for benchmark.
 *
 * @param {Object} data
 * @returns {Array} benchmarks
 */
function getBenchmarkAllEnergyUsageTrend(data) {
    const benchmarkAllEnergyUsageTrend = [];
    for (let i = 0; i < getDatesAllEnergyUsageTrend().length; i++) {
        benchmarkAllEnergyUsageTrend.push(1003);
        // benchmarkAllEnergyUsageTrend.push(data.allLabEnergyUsage.lab.energyUsageBenchmark);
    }
    return benchmarkAllEnergyUsageTrend;
}

/**
 * Ajax call to get data from the server.
 */
async function getDataAllEnergyUsageTrend(start = null, end = null) {
    const data = {
        StartAllEnergyUsageTrend: start,
        EndAllEnergyUsageTrend: end
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
function getDatesAllEnergyUsageTrend(start = null, end = null) {
    const datesAllEnergyUsageTrend = [];
    if (!start && !end) {
        const todayAllEnergyUsageTrend = new Date();

        // Get 30 days ago from today
        const startDate = new Date(new Date().setDate(todayAllEnergyUsageTrend.getDate() - 30));

        while (startDate <= todayAllEnergyUsageTrend) {
            datesAllEnergyUsageTrend.push(startDate.toLocaleDateString('en-US', {
                day: 'numeric',
                month: 'short'
            }));
            startDate.setDate(startDate.getDate() + 1);
        }

    } else {
        for (let i = new Date(start); i <= new Date(end); i.setDate(i.getDate() + 1)) {
            const dateAllEnergyUsageTrend = i.toLocaleDateString('en-US', {
                day: 'numeric',
                month: 'short'
            });
            datesAllEnergyUsageTrend.push(dateAllEnergyUsageTrend);
        }
    }

    return datesAllEnergyUsageTrend;
}