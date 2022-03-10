// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// To toggle navbar 
const btn = document.querySelector(".mobile-menu-button");
const sidebar = document.querySelector(".side-bar");

// add our event listener for the click
btn.addEventListener("click", () => {
    sidebar.classList.toggle("-translate-x-full");
});
