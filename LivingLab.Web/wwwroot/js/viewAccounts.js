$(document).ready(function () {
    $(document).on('click', '.deleteUserBtn', function () {
        clickDelete(this)
    });
    $(document).on('click', '.editUserBtn', function () {
        clickEdit(this)
    });
    function clickEdit(e) {
        $.get('/UserManagement/View/'+e.getAttribute('data-id'),  // url
            function (data, textStatus, jqXHR) {  // success 
                print("what is this data" + data)
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
                document.getElementById("userEmail").innerHTML = data.email
                document.getElementById("del-user-email").value = data.email
            });
    }
})