$(document).ready(function () {
    $(document).on('click', '.editUserBtn', function () {
        clickEditUser(this)
    });
    $(document).on('click', '.deleteUserBtn', function () {

        clickDelete(this)
    });
    
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
            function (data, textStatus, jqXHR) {  
                console.log(" data returned: ", data);
                console.log("Faculty returned: ", data.userFaculty);
                document.getElementById("user-id").value = data.id
                document.getElementById("user-email").value = data.email
                document.getElementById("user-faculty").value = data.userFaculty
                
            });
    }
    function clickDelete(e) {
        $.get('/UserManagement/View/'+e.getAttribute('data-id'),  // url
            function (data, textStatus, jqXHR) {  
                document.getElementById("del-user-id").value = data.id
                document.getElementById("userEmail").innerHTML = data.email
                document.getElementById("del-user-email").value = data.email
            });
    }

   
})