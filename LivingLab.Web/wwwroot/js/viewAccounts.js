$(document).ready(function () {
    $(document).on('click', '.deleteUserBtn', function () {
        clickDelete(this)
    });

    $(document).on('click', '.editUserBtn', function () {
        clickEdit(this)
    });
    
    
    function clickEdit(e) {
        $.get('/UserManagement/View/'+e.getAttribute('data-id'),  // url
            function (data, textStatus, jqXHR) {  // success callback
                document.getElementById("user-id").value = data.id
                document.getElementById("user-email").value = data.email
                // document.getElementById("user-faculty").value = data.email
                // document.getElementById("user-lab-access").value = data.email
                
            });
    }
    
    function clickDelete(e) {
        $.get('/UserManagement/View/'+e.getAttribute('data-id'),  // url
            function (data, textStatus, jqXHR) {  // success callback
                document.getElementById("del-user-id").value = data.id
                print('data id'+ data.id)
                document.getElementById("userEmail").innerHTML = data.email
                document.getElementById("del-user-email").value = data.email
            });
    }
})