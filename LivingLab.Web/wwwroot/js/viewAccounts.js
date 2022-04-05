$(document).ready(function () {
    $(document).on('click', '.editUserBtn', function () {
        clickEditUser(this)
    });
    $(document).on('click', '.deleteUserBtn', function () {

        clickDelete(this)
    });



    // let closebtn2FA = document.getElementById("close-btn2FA");

    $(document).on('click', '.modal-open', function () {
        document.write("clicked")
        let modal2FA = document.getElementById("modal-box");
        modal2FA.style.display = "none";

    });
    let modal = document.getElementById("modal");

    window.onclick = function (event) {
        if (event.target === modal) {
            modal.style.display = "none";
        }
    }

    function clickEditUser(e) {
        $.get('/UserManagement/View/'+e.getAttribute('data-id'),  // url
            function (data, textStatus, jqXHR) {  // success 
                document.getElementById("user-id").value = data.id
                document.getElementById("user-email").value = data.email
                // document.getElementById("user-faculty").value = data.faculty
                // document.getElementById("user-lab-access").value = data.LabAccess
            });
    }
    function clickDelete(e) {
        $.get('/UserManagement/View/'+e.getAttribute('data-id'),  // url
            function (data, textStatus, jqXHR) {  // success callback
                document.getElementById("del-user-id").value = data.id
                // document.getElementById("userEmail").innerHTML = data.email
                document.getElementById("del-user-email").value = data.email
            });
    }


})