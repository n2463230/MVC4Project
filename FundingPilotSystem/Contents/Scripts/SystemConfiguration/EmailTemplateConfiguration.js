

function DeleteEmailTemplateConfiguration(emailTemplateConfigurationId) {
    var confirmResult = confirm(CommonResource.ConfirmDelete);
    var callUrl = $("#webUrl").val() + "/EmailTemplateConfiguration/Delete";
    if (confirmResult) {
        var dataToSend = { emailTemplateConfigurationId: emailTemplateConfigurationId };
        $.ajax({
            cache: false,
            data: dataToSend,
            type: "POST",
            url: callUrl,
            success: function (msg) {
                //HideLoading();
                if (msg == "True") {
                    alert(CommonResource.DeletedSuccessfully);
                    RebindEmailTemplateConfiguration();
                } else {
                    alert(CommonResource.ErrorPerformingOperation);
                }

            },
            error: function (msg) {
                //HideLoading();
                alert('Error' + msg.toString());
            }
        });
    }
}

function RebindEmailTemplateConfiguration() {
    var EmailTemplateConfigurationGrid = $("#EmailTemplateConfigurationGrid").data("tGrid");
    EmailTemplateConfigurationGrid.rebind();
}