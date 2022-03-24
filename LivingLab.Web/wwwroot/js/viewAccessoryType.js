/* <remarks>*/
/* Author: Team P1-3*/
/* </remarks>*/
$(document).ready(function () {

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
    $(document).on('click', '#addAccessoryBtn', function() {
        clickAdd(this)
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
    $('#AccessoryTypeId').change(function () {
        console.log('click')
        var selectedValue = jQuery(this).val()
        if (selectedValue === "Others") {
            $("#forNewType").removeClass('hidden')
        } else {
            $("#forNewType").addClass('hidden')
        }
    })

});

function clickAdd(e) {
    $.get('/Accessory/AddAccessoryDetails',
        function (data) {
            console.log("Hello!?")
            console.log(data)
            document.getElementById("accessoryId").value = data.accessory.id + 1
            var accessoryTypeDDL = document.getElementById("accessoryType")
            if (accessoryTypeDDL.length === 0) {
                for (var i = 0; i < data.accessoryTypes.length; i++) {
                    var element = document.createElement("option")
                    element.textContent = data.accessoryTypes[i].type
                    element.value = data.accessoryTypes[i].id
                    accessoryTypeDDL.appendChild(element)
                }
                var last = document.createElement("option")
                last.textContent = "Others"
                last.value = "Others"
                accessoryTypeDDL.appendChild(last)
            }
            document.getElementById("labId").value = data.accessory.lab.labId
            document.getElementById("labLocation").value = data.accessory.lab.labLocation
        })
}