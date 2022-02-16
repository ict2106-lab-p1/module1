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
        reverseButtons: true,
        confirmButtonColor: '#312E81',
        cancelButtonColor: '#C0C0C0',
        confirmButtonText: 'Submit',
    }).then(function (result) {
        if (result.value === "uploadfiles") {
            window.location.href = "ManualLogs/FileUpload";
        } else if (result.value === "addlogs") {
            window.location.href = "ManualLogs/ManualLogUpload";
        }
    })
}

function addLogAlert() {
    Swal.fire({
        title: 'Do you want to add this log?',
        icon: 'warning',
        showCancelButton: true,
        reverseButtons: true,
        confirmButtonColor: '#312E81',
        cancelButtonColor: '#C0C0C0',
        confirmButtonText: 'Yes',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: 'Log Added',
                icon: 'success',
                showDenyButton: true,
                reverseButtons: true,
                confirmButtonColor: '#312E81',
                denyButtonColor: '#C0C0C0',
                confirmButtonText: 'Add New Logs',
                denyButtonText: 'Back to Dashboard'
            }).then((result) => {
                if (result.isConfirmed) {
                    /*redirects to add new logs page (subject to changes)*/
                    window.location.href = "ManualLogs/ManualLogUpload";
                } else if (result.isDenied) {
                    /*redirects to dashboard page (subject to changes)*/
                    window.location.href = "/";
                }
            })
        }
    })
}

function fileUploadedAlert() {
    Swal.fire({
        title: 'File Uploaded',
        icon: 'success',
        showDenyButton: true,
        reverseButtons: true,
        confirmButtonColor: '#312E81',
        denyButtonColor: '#C0C0C0',
        confirmButtonText: 'My Logs',
        denyButtonText: 'Back to Dashboard'
    }).then((result) => {
        if (result.isConfirmed) {
            /*redirects to view my logs page (subject to changes)*/
            window.location.href = "ManualLogs/ManualLogUpload";
        } else if (result.isDenied) {
            /*redirects to dashboard page (subject to changes)*/
            window.location.href = "/";
        }
    })
}