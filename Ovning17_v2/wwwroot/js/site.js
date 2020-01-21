// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {         //När dokumentet har laddat klart
    $("#history").click(function () {   //När man klickar på id="history"
        $("form").submit();             //Gör Submit på formuläret
    });
});
