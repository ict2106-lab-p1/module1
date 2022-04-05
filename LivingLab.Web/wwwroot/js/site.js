// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $.ajax({
        type: "Get",
        url: "/Home/GetLabs",
        success: function (data) {
            //update the page content.

            $('#returnlabs').empty(); //clear the content
            $('#returnlabs').append(data); //add the latest data.
        },
        error: function (response) {
            console.log(response.responseText);
        }
    });
    $.ajax({
        type: "Get",
        url: "/Home/GetReviewEquipment",
        success: function (data) {
            //update the page content.

            $('#returnequipment').empty(); //clear the content
            $('#returnequipment').append(data); //add the latest data.
        },
        error: function (response) {
            console.log(response.responseText);
        }
    });
});

// To toggle navbar 
const btn = document.querySelector(".mobile-menu-button");
const sidebar = document.querySelector(".side-bar");

// add our event listener for the click
btn.addEventListener("click", () => {
    sidebar.classList.toggle("-translate-x-full");
});
