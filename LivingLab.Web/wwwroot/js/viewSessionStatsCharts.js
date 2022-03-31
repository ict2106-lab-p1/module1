
const ctx = document.getElementById('durationLoggedChart');
const ctx2 = document.getElementById('dataUploadedChart');
const date = getDateUploaded();
const duration = getDuration();

function getDuration(){
    let data = [];
    const $table = $("#table_id");

    const $rows = $table.find("tbody > tr");

    $rows.each(function () {
        //const duration = $(this).find("td.duration").text();
        const login = $(this).find("td.login").text();
        const logout = $(this).find("td.logout").text();

        // find duration based on login and logout timings
        var calDuration = (new Date(logout) - new Date(login)) / 1000 / 60 / 60

        $(this).find("td.duration").text(calDuration);
        console.log(calDuration)

        data.push(
            calDuration
        )
    })
    return data
}
console.log(duration)
function getDataUploaded(){
    let data = [];
    const $table = $("#table_id");

    const $rows = $table.find("tbody > tr");

    $rows.each(function () {
        const dataUploaded = $(this).find("td.dataUploaded").text();

        data.push(
            dataUploaded
        )
    })
    return data
}
const myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: date,
        datasets: [{
            label: 'Duration logged in',
            data: duration,
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            fill: true,
            borderWidth: 1,
        }]
    },
});

const dataUploaded = getDataUploaded();
function getDateUploaded(){
    let data = [];
    const $table = $("#table_id");

    const $rows = $table.find("tbody > tr");

    $rows.each(function () {
        const date = $(this).find("td.date").text();

        data.push(
            date
        )
    })
    return data
}

const myChart2 = new Chart(ctx2, {
    type: 'bar',
    data: {
        labels: date,
        datasets: [{
            label: 'Number of Data Uploaded',
            data: dataUploaded,
            backgroundColor: [
                'rgba(255, 26, 104, 0.2)'
            ],
            borderColor: [
                'rgba(255, 26, 104, 1)'
            ],
            fill: true,
            borderWidth: 1,
        }]
    },
});