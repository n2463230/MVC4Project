/* Hide Common Message Region */
setInterval('HideCommonMessageRegion()', 1000);
var valTimer = -1;
function HideCommonMessageRegion() {
    var divCommonErrorRegionHtml = $("#commonErrorRegion").html();
    if (divCommonErrorRegionHtml != "") {
        if (valTimer < 0)
            valTimer = 5000;
    }
    HideMessageRegion();
}

function HideMessageRegion() {
    if (valTimer == 0) {
        $("#commonErrorRegion").html("");
        $("#commonErrorRegion").hide("slow")
        valTimer = -1;
    }
    else {
        valTimer = valTimer - 1000;
    }
}
/* Hide Common Message Region */


function SetValidationSuccessMessage(message) {

    $("#commonErrorRegion").show();

    var messageHtml = "<div style=\"background: none repeat scroll 0 0 lightyellow; border: 1px solid #DADADA; display: block; margin: 10px; padding: 5px 5px 0;\">"
                  + "<ul style=\"list-style: disc; margin-left: 25px; color: green;\">"
                           + "<li>" + message + "</li>"
                  + "</ul>";
    + "</div>";

    $("#commonErrorRegion").html(messageHtml);
}

function SetValidationErrorMessage(message) {

    $("#commonErrorRegion").show();

    var messageHtml = "<div style=\"background: none repeat scroll 0 0 lightyellow; border: 1px solid #DADADA; display: block; margin: 10px; padding: 5px 5px 0;\">"
                     + "<ul style=\"list-style: disc; margin-left: 25px; color: red;\">"
                              + "<li>" + message + "</li>"
                     + "</ul>";
    + "</div>";

    $("#commonErrorRegion").html(messageHtml);
}

function SetMultipleValidationErrorMessage(messages) {

    $("#commonErrorRegion").show();

    var messageHtml = "<div style=\"background: none repeat scroll 0 0 lightyellow; border: 1px solid #DADADA; display: block; margin: 10px; padding: 5px 5px 0;\">";
    messageHtml = messageHtml + "<ul style=\"list-style: disc; margin-left: 25px; color: red;\">";

    $.each(messages, function (index, message) {
        messageHtml = messageHtml + "<li>" + message + "</li>";
    });

    messageHtml = messageHtml + "</ul>";
    messageHtml = messageHtml + "</div>";

    $("#commonErrorRegion").html(messageHtml);
}

function GetTextFromHtml(html) {
    return escapeExpression(html);
}

function escapeExpression(value) {

    var originalValue = value;

    value = value.replace(/([#;&,\+\*\~':"\!\^$\[\]=>\|])/g, "\\$1");

    try {
        var text = $(value).text();
        if (trim(text) == "")
            value = originalValue;
        else
            value = text;
    }
    catch (e) {
        value = originalValue;
    }

    return value;
}