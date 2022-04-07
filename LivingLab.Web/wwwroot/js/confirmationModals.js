// const form = document.getElementById('fileuploadform')

function showAlert() {
    Swal.fire({
        title: 'Choose Upload Type',
        input: 'select',
        inputOptions: {
            uploadfiles: 'Upload File',
            addlogs: 'Add Logs (Manually)',
        },
        inputPlaceholder: 'Upload Type',
        showCancelButton: true,
        reverseButtons: true,
       confirmButtonColor: '#4B6BFB',
        cancelButtonColor: '#C0C0C0',
        customClass: {
            confirmButton: 'btn btn-primary',
            cancelButton: 'btn btn-ghost'
        },
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
        confirmButtonColor: '#363740',
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
                confirmButtonColor: '#363740',
                denyButtonColor: '#C0C0C0',
                confirmButtonText: 'Add New Logs',
                denyButtonText: 'Back to Dashboard'
            }).then((result) => {
                if (result.isConfirmed) {
                    /*redirects to add new logs page (subject to changes)*/
                    window.location.href = "ManualLogUpload";
                } else if (result.isDenied) {
                    /*redirects to dashboard page (subject to changes)*/
                    window.location.href = "/";
                }
            })
        }
    })
}

/*
function fileUploadedAlert() {
    Swal.fire({
        title: 'File Submitted',
        icon: 'success',
        showDenyButton: true,
        reverseButtons: true,
        confirmButtonColor: '#312E81',
        denyButtonColor: '#C0C0C0',
        confirmButtonText: 'Proceed',
        denyButtonText: 'Upload New File'
    }).then((result) => {
        if (result.isConfirmed) {
            /*redirects to view my logs page (subject to changes)*/
            //window.location.href = "ManualLogUpload";
          /*  $('#form').submit();
        } else if (result.isDenied) {
            /*redirects to add new file page (subject to changes)*/
          /*  window.location.href = "FileUpload";
        }
    })
}*/

/*function openfileUploadedAlert() {
    form.addEventListener('submit', (e) => {
        e.preventDefault()
        fileUploadedAlert()
    })
}*/






$(document).on('click', '#btn-submit', function(e) {
    e.preventDefault();
    Swal.fire({
        title: 'File Submitted',
        icon: 'success',
        showDenyButton: true,
        reverseButtons: true,
        confirmButtonColor: '#363740',
        denyButtonColor: '#C0C0C0',
        confirmButtonText: 'Proceed',
        denyButtonText: 'Upload New File'
    }).then(function (result) {
        if (result.isConfirmed) {
            $('#fileuploadform').submit();
        } else if (result.isDenied) {
            /*redirects to add new file page (subject to changes)*/
            window.location.href = "FileUpload";
        }
    });
});