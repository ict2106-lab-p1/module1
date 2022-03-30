/* <remarks>*/
/* Author: Team P1-5*/
/* </remarks>*/

$(document).ready(function() {
    let modal = document.getElementById("my-modal");

    let btn = document.getElementById("SMS-btn");

    let closebtn = document.getElementById("close-btn");

    let submitbtn = document.getElementById("submit-btn");

    let modal2FA = document.getElementById("my-modal2FA");

    let btn2FA = document.getElementById("2FA-btn");

    let closebtn2FA = document.getElementById("close-btn2FA");

    let submitbtn2FA = document.getElementById("submit-btn2FA");
// We want the modal to open when the Open button is clicked
    btn.onclick = function () {
        modal.style.display = "block";
    }

    btn2FA.onclick = function () {
        modal2FA.style.display = "block";
    }
// We want the modal to close when the OK button is clicked
    closebtn.onclick = function () {
        modal.style.display = "none";
    }

    closebtn2FA.onclick = function () {
        modal2FA.style.display = "none";
    }

// We want the modal to close when the OK button is clicked
    submitbtn.onclick = function () {
        modal.style.display = "none";
    }
    submitbtn2FA.onclick = function () {
        modal2FA.style.display = "none";
    }


// We want the modal to open when the Open button is clicked
    btn.onclick = function () {
        modal.style.display = "block";
    }

    btn2FA.onclick = function () {
        modal2FA.style.display = "block";
    }
// The modal will close when the user clicks anywhere outside the modal
    window.onclick = function (event) {
        if (event.target === modal) {
            modal.style.display = "none";
        }
    }
})
        