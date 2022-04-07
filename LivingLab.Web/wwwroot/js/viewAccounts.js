/// <remarks>
/// Author: Team P1-5
/// </remarks>
$(document).ready(function () {
    $(document).on('click', '.editUserBtn', function () {
        clickEditUser(this)
    });
    $(document).on('click', '.deleteUserBtn', function () {

        clickDelete(this)
    });

    function clickEditUser(e) {
        $.get('/UserManagement/View/'+e.getAttribute('data-id'), 
            function (data, textStatus, jqXHR) {  // success 
                document.getElementById("user-id").value = data.id
                document.getElementById("user-email").value = data.email
                document.getElementById("user-faculty").value = data.userFaculty
            });
    }
    function clickDelete(e) {
        $.get('/UserManagement/View/'+e.getAttribute('data-id'),  
            function (data, textStatus, jqXHR) {  
                document.getElementById("del-user-id").value = data.id
                document.getElementById("userEmail").innerHTML = data.email
                document.getElementById("del-user-email").value = data.email
            });
    }

})