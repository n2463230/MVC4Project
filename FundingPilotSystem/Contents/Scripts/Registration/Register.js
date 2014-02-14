$(document).ready(function () {
    if (parseInt($("#hdnRegistrationId").val()) > 0) {
        $("#btnSubmit").hide();
    }
});

$('form').submit(function () {

    if ($(this).valid()) {
        if ($("#hdnConfirmedEmail").val() == "false" || $("#hdnConfirmedEmail").val() == "") {
            $('#alertModal').modal('show');
            return false;
        }
        else if ($("#hdnConfirmedEmail").val() == "true") {
            $('#alertModal').modal('hide')
            return true;
        }
        return false;

    }
    else {
        return false;
    }
});

function OnHideAlertModal() {

    $("#hdnConfirmedEmail").val("false");
    $('#alertModal').modal('hide')

}
function OnOkAlertModal() {

    $("#hdnConfirmedEmail").val("true");
    $('form').submit();

}

