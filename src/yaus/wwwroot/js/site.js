// Write your Javascript code.

$(function() {
    var $fullUrl = $("#fullUrl");
    var $shortenButton = $("#shortenbutton");
    var $shortenUrl = $("#shortenedUrl");
    var $copyButton = $("#copyButton");

    $shortenButton.on("click", () => {
       
    });

    $fullUrl.on("keyup", () => {
        $shortenButton.prop("disabled", $fullUrl.val() === "");
    });

    $shortenUrl.on("change", () => {
        $copyButton.prop("disabled", $shortenUrl.val() === "");
    });
});