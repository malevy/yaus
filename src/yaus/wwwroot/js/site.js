// Write your Javascript code.

$(function() {
    var $fullUrl = $("#fullUrl");
    var $shortenButton = $("#shortenbutton");
    var $shortenUrl = $("#shortenedUrl");
    var $copyButton = $("#copyButton");

    $shortenButton.on("click", () => {

        $.ajax({
            method: 'post',
            accepts: {
                json: 'application/json'
            },
            contentType: 'application/json',
            url: createUrl,
            data: JSON.stringify( {
                fullUrl: $fullUrl.val()
            })
        })
        .done(function(data) {
                $shortenUrl.val(data.token);
        });
        //TODO - really need to handle errors but...nah

    });

    $fullUrl.on("keyup", () => {
        $shortenButton.prop("disabled", $fullUrl.val() === "");
    });

    $shortenUrl.on("change", () => {
        $copyButton.prop("disabled", $shortenUrl.val() === "");
        //TODO - show the shorten UI component when a token is available
    });



});

