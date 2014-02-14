function OnPageSpecificPlaceholderEdit(pageSpecificPlaceholderId, moduleId, moduleName,
                                topFrameHTML, leftFrameHTML, rightFrameHTML, bottomFrameHTML) {

    $("#hdnPageSpecificPlaceholderId").val(pageSpecificPlaceholderId);
    $("#hdnModuleId").val(moduleId);
    $("#hdnModuleName").val(moduleName);
    $("#hdnTopFrameHTML").val(topFrameHTML);
    $("#hdnLeftFrameHTML").val(leftFrameHTML);
    $("#hdnRightFrameHTML").val(rightFrameHTML);
    $("#hdnBottomFrameHTML").val(bottomFrameHTML);

    $("#dvHtmlContentDetails").show();
    $("#dvModuleName").html(moduleName);

    if (topFrameHTML == "") {
        $("#uplodTopFrameHtml").show();
        $("#dvTopFrameHtml").hide();

        ResetUpload("uplodTopFrameHtml");

        if ($("#TopFrameHTMLTemplateUpload").parent().hasClass("t-upload-button-disabled"))
        {
            $("#TopFrameHTMLTemplateUpload").prop("disabled", false);
            $("#TopFrameHTMLTemplateUpload").parent().removeClass("t-upload-button-disabled");
        }
    }
    else {
        $("#uplodTopFrameHtml").hide();
        $("#spanTopFrameHtml").html(topFrameHTML);
        $("#dvTopFrameHtml").show();
    }

    if (leftFrameHTML == "") {
        $("#uplodLeftFrameHtml").show();
        $("#dvLeftFrameHtml").hide();

        ResetUpload("uplodLeftFrameHtml");

        if ($("#LeftFrameHTMLTemplateUpload").parent().hasClass("t-upload-button-disabled")) {
            $("#LeftFrameHTMLTemplateUpload").prop("disabled", false);
            $("#LeftFrameHTMLTemplateUpload").parent().removeClass("t-upload-button-disabled");
        }
    }
    else {
        $("#uplodLeftFrameHtml").hide();
        $("#spanLeftFrameHtml").html(leftFrameHTML);
        $("#dvLeftFrameHtml").show();
    }

    if (rightFrameHTML == "") {
        $("#uplodRightFrameHtml").show();
        $("#dvRightFrameHtml").hide();

        ResetUpload("uplodRightFrameHtml");

        if ($("#RightFrameHTMLTemplateUpload").parent().hasClass("t-upload-button-disabled")) {
            $("#RightFrameHTMLTemplateUpload").prop("disabled", false);
            $("#RightFrameHTMLTemplateUpload").parent().removeClass("t-upload-button-disabled");
        }
    }
    else {
        $("#uplodRightFrameHtml").hide();
        $("#spanRightFrameHtml").html(rightFrameHTML);
        $("#dvRightFrameHtml").show();
    }

    if (bottomFrameHTML == "") {
        $("#uplodBottomFrameHtml").show();
        $("#dvBottomFrameHtml").hide();

        ResetUpload("uplodBottomFrameHtml");

        if ($("#BottomFrameHTMLTemplateUpload").parent().hasClass("t-upload-button-disabled")) {
            $("#BottomFrameHTMLTemplateUpload").prop("disabled", false);
            $("#BottomFrameHTMLTemplateUpload").parent().removeClass("t-upload-button-disabled");
        }
    }
    else {
        $("#uplodBottomFrameHtml").hide();
        $("#spanBottomFrameHtml").html(bottomFrameHTML);
        $("#dvBottomFrameHtml").show();
    }
}

function OnPlaceholderConfigDelete(pageSpecificPlaceholder, divId) {
    var confirmResult = confirm(CommonResource.ConfirmDelete);
    var pageSpecificPlaceholderId = parseInt($("#hdnPageSpecificPlaceholderId").val());
    var callUrl = $("#webUrl").val() + "/SystemConfiguration/HTMLTemplateManager/Delete";
    var fileName;

    switch (divId) {
        case "Top":
            fileName = $("#hdnTopFrameHTML").val();
            break;
        case "Left":
            fileName = $("#hdnLeftFrameHTML").val();
            break;
        case "Right":
            fileName = $("#hdnRightFrameHTML").val();
            break;
        case "Bottom":
            fileName = $("#hdnBottomFrameHTML").val();
            break;
    }

    var moduleName = $("#hdnModuleName").val();

    if (confirmResult) {
        var dataToSend = { fileNames: fileName, pageSpecificPlaceholderId: pageSpecificPlaceholderId, pageSpecificPlaceholder: pageSpecificPlaceholder, moduleName: moduleName };

        $.ajax({
            cache: false,
            data: dataToSend,
            type: "POST",
            url: callUrl,
            success: function (data) {
                if (data.Success == true) {
                    alert(CommonResource.DeletedSuccessfully);
                    var uploadDivId = "#uplod" + divId + "FrameHtml";
                    var conttentDivId = "#dv" + divId + "FrameHtml";
                    $(uploadDivId).show();
                    $(conttentDivId).hide();

                    $("#" + divId + "FrameHTMLTemplateUpload").prop("disabled", false);
                    $("#" + divId + "FrameHTMLTemplateUpload").parent().removeClass("t-upload-button-disabled");
                    $("#hdn" + divId + "FrameHTML").val("");
                    ResetUpload("uplod" + divId + "FrameHtml");

                    RefreshGrid();
                } else {
                    alert(CommonResource.ErrorPerformingOperation);
                }
            },
            error: function (msg) {
                alert('Error' + msg.toString());
            }
        });
    }
}

function OnPageSpecificPlaceholderUpload(e) {
    var pageSpecificPlaceholderId = $("#hdnPageSpecificPlaceholderId").val();
    var moduleId = $("#hdnModuleId").val();
    var moduleName = $("#hdnModuleName").val();
    var topFrameHTML = $("#hdnTopFrameHTML").val();
    var leftFrameHTML = $("#hdnLeftFrameHTML").val();
    var rightFrameHTML = $("#hdnRightFrameHTML").val();
    var bottomFrameHTML = $("#hdnBottomFrameHTML").val();

    e.data = {
        'pageSpecificPlaceholderId': parseInt(pageSpecificPlaceholderId)
        , 'moduleId': parseInt(moduleId)
        , 'moduleName': moduleName
        , 'topFrameHTML': topFrameHTML
        , 'leftFrameHTML': leftFrameHTML
        , 'rightFrameHTML': rightFrameHTML
        , 'bottomFrameHTML': bottomFrameHTML
    };
}

function OnPageSpecificPlaceholderRemove(e) {

    var pageSpecificPlaceholderId = $("#hdnPageSpecificPlaceholderId").val();
    var moduleName = $("#hdnModuleName").val();

    e.data = {
        'pageSpecificPlaceholderId': parseInt(pageSpecificPlaceholderId)
        , 'moduleName': moduleName
    };
}

function OnPageSpecificPlaceholderUploadSuccess(e) {

    var uploadId = e.response.pageSpecificPlaceholder + "FrameHTMLTemplateUpload";
    if (e.response.IsDelete != undefined && e.response.IsDelete) {
        $("#" + uploadId).prop("disabled", false);
        $("#" + uploadId).parent().removeClass("t-upload-button-disabled");

        switch (e.response.pageSpecificPlaceholder) {
            case "Top":
                $("#hdnTopFrameHTML").val("");
                break;
            case "Left":
                $("#hdnLeftFrameHTML").val("");
                break;
            case "Right":
                $("#hdnRightFrameHTML").val("");
                break;
            case "Bottom":
                $("#hdnBottomFrameHTML").val("");
                break;
        }
    }
    else {
        $("#" + uploadId).prop("disabled", true);
        $("#" + uploadId).parent().addClass("t-upload-button-disabled");
        var pageSpecificPlaceholderId = parseInt($("#hdnPageSpecificPlaceholderId").val());

        if (isNaN(pageSpecificPlaceholderId) == false || pageSpecificPlaceholderId == 0) {
            $("#hdnPageSpecificPlaceholderId").val(e.response.PageSpecificPlaceholderId);
        }

        $("#hdnTopFrameHTML").val(e.response.TopFrameHTML);
        $("#hdnLeftFrameHTML").val(e.response.LeftFrameHTML);
        $("#hdnRightFrameHTML").val(e.response.RightFrameHTML);
        $("#hdnBottomFrameHTML").val(e.response.BottomFrameHTML);
    }
    RefreshGrid();
}

function RefreshGrid() {
    var pageSpecificPlaceholderConfigGrid = $("#PageSpecificPlaceholderConfigGrid").data("t-Grid");
    pageSpecificPlaceholderConfigGrid.rebind();
}

function ResetUpload(controlId) {
    if ($("#" + controlId).files != undefined) {
        $("#" + controlId).files[0] = null;
    }
    $("#" + controlId).find('ul').remove();
}

function OnPageSpecificPlaceholderSelect(e) {
    var ext = e.files[0].extension.toLowerCase();

    if ($.inArray(ext, ['.html', '.htm']) == -1) {
        alert(SystemConfigurationResources.OnlyHtmlFileSupported);
        e.preventDefault();
        return false;
    }
    return true;
}