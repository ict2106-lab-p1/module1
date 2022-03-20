/* <remarks>*/
/* Author: Team P1-3*/
/* </remarks>*/

$(document).ready(function() {

    const overlay = document.querySelector('#overlay')
    const addBtn = document.querySelector('#addDeviceBtn')
    const closeBtn = document.querySelector('#close-modal')
    const viewMoreBtns = document.querySelectorAll('#viewMoreBtn')

    const toggleModal = () => {
        overlay.classList.toggle('hidden')
        overlay.classList.toggle('flex')
    }

    addBtn.addEventListener('click', toggleModal)

    closeBtn.addEventListener('click', toggleModal)

    const viewwMoreEventHandler = () => {
        console.log("View More Device");
        var deviceType = event.target.parentElement.parentElement.firstElementChild.textContent;
        console.log(deviceType)
        document.postDeviceType.deviceType.value = deviceType
        document.postDeviceType.submit();
    }

    viewMoreBtns.forEach(btn => btn.addEventListener('click', viewwMoreEventHandler))

    $('.btnViewMore').each(function() {
        $(this).on('click', function(evt) {
            $this = $(this);
            var dtRow = $this.parents('tr');
            document.postDeviceType.deviceType.value = dtRow[0].cells[0].innerHTML;
            console.log(document.postDeviceType.deviceType.value)
            document.postDeviceType.submit();
        })
    })
});