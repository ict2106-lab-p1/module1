/* <remarks>*/
/* Author: Team P1-3*/
/* </remarks>*/
$(document).ready(function() {

    //Add Overlay
    const overlay = document.querySelector('#overlay')
    const viewMoreBtns = document.querySelectorAll('#viewMoreBtn')
    const toggleModal = () => {
        console.log('click')
        overlay.classList.toggle('hidden')
        overlay.classList.toggle('flex')
    }

    $(document).on('click', '#close-modal', function() {
        toggleModal()
    });
    $(document).on('click', "#cancelBtn", function() {
        toggleModal()
    });

    const viewwMoreEventHandler = () => {
        console.log("View More Accessory");
        var accessoryType = event.target.parentElement.parentElement.firstElementChild.textContent;
        console.log(accessoryType);
        document.postAccessoryType.accessoryType.value = accessoryType
        document.postAccessoryType.labLocation.value =
            document.postAccessoryType.submit();
    }
    viewMoreBtns.forEach(btn => btn.addEventListener('click', viewwMoreEventHandler))
    $('#accessoryType').change(function() {
        console.log('click')
        var selectedValue = jQuery(this).val()
        if (selectedValue === "Others") {
            $("#forNewType").removeClass('hidden')
        } else {
            $("#forNewType").addClass('hidden')
        }
    })

});