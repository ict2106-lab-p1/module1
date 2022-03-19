$(document).ready(function () {
    $(document).on('click', '.deleteUserBtn', function () {
        clickDelete(this)
    });
    
    function clickDelete(e) {
        print('TEST')

        $.get('/UserManagement/View/'+e.getAttribute('data-id'),  // url
            function (data, textStatus, jqXHR) {  // success callback
                document.getElementById("del-user-id").value = data.id
                print('data id'+ data.id)
                document.getElementById("userEmail").innerHTML = data.email
                document.getElementById("del-user-email").value = data.email
            });
    }
})