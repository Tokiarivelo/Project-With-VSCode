// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var $buoop = {};
$buoop.ol = window.onload;
window.onload = function () {
    try {
        if ($buoop.ol) {
            $buoop.ol();
        }
    } catch (e) {
        var e = document.createElement("script");
        e.setAttribute("type", "text/javascript");
        e.setAttribute("src", "//browser-update.org/update.js");
        document.appendChild(e);
    }
}
