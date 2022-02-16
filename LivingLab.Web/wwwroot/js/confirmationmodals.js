function showAlert() {
    Swal.fire({
        title: 'Select Upload Type',
        input: 'select',
        inputOptions: {
            uploadfiles: 'Upload File',
            addlogs: 'Add Logs (Manually)',
        },
        inputPlaceholder: 'Upload Type',
        showCancelButton: true,
        confirmButtonColor: '#312E81',
        cancelButtonColor: '#C0C0C0',
        confirmButtonText: 'Submit',
        inputValidator: function (value) {
            return new Promise(function (resolve, reject) {
                if (value === 'uploadfiles') {
                    //do something
                    resolve()
                } else {
                    // do something
                    resolve()
                }
            })
        }
    }).then(function (result) {
        if (result.value === "uploadfiles") {
            console.log(window.url);
            window.location.href = "ManualLogs/FileUpload";
        } else if (result.value === "addlogs") {
            console.log(window.url);
            window.location.href = "ManualLogs/ManualLogUpload";
        }
    })
}