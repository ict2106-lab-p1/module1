let chart;

$(document).ready(async function() {
    const labId = $("#labId").val();
    const data = await getData(labId);
    if (!data) return;
    
    initLabLocation(data);
    initMedian(data);
    initLineChart(data);
    initDatepicker();
    $("#filter").click(filter);
    $("#resetFilter").click(resetFilter);
    $("#resetZoom").click(resetZoom);
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
    chart = getLineChart(data, start, end);
    initMedian(data);
}

/**
 * Reset the filter to the default values.
 * 
 * Set start and end date to default and 
 * trigger the filter button.
 */
function resetFilter(e) {
    e.preventDefault();
    $("#start").val('');
    $("#end").val('');
    $("#filter").click();
}

/**
 * Display count up animation on the median value.
 * @param {Object} data 
 */
function initMedian(data) {
    const median = data.median;
    const $median = $("#median");
    $({ countNum: 0}).animate({ countNum: median }, {
        duration: 1500,
        easing: 'linear',
        step: function() {
            $median.text(Math.floor(this.countNum).toFixed(2));
        },
        complete: function() {
            $median.text(median.toFixed(2));
        }
    });
}

/**
 * Display the lab location.
 * 
 * @param {Object} data
 */
function initLabLocation(data) {
    const $labLocation = $("#labLocation");
    $labLocation.text(data.lab.labLocation);
}

/**
 * Setup the line chart with
 * benchmark and actual usage.
 * 
 * @param {Object} data
 */
function initLineChart(data) {
    hideSpinner();
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
                label: "Actual Usage (kWh)",
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
        options: {
            plugins: {
                zoom: getZoomOptions(),
                scales: {
                    x: {
                        min: 100
                    }
                }
            },
            responsive: true
        }
    })
}

/**
 * Get zoom options for the chart.
 * @returns zoom options
 */
function getZoomOptions() {
    return {
        pan: {
            enabled: true,
            mode: 'xy',
        },
        zoom: {
            wheel: {
                enabled: true,
                modifierKey: 'ctrl',
                speed: 0.02 ,
            },
            pinch: {
                enabled: true
            },
            mode: 'x',
        }
    }
}

function resetZoom(e) {
    chart.resetZoom();
}

/**
 * Hide all spinners.
 */
function hideSpinner() {
    $("#spinner").hide();
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