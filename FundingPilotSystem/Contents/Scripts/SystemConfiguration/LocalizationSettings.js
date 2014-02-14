
function OnCultureChange(e) {
    LoadResourceFile();
}

function OnModuleChange(e) {
    LoadResourceFile();
}

function LoadResourceFile() {
    var cultureCombo = $("#SelectedCulture").data('tComboBox');
    var moduleCombo = $("#SelectedModule").data('tComboBox');
    var resourceGrid = $("#grdResourceData").data("tGrid");
    resourceGrid.dataBind("");

    var culture = cultureCombo.value();
    var moduleId = parseInt(moduleCombo.value());

    if (culture != "0" && culture.toString().length > 1
            && isNaN(moduleId) == false && moduleId > 0) {
        CheckIsResourceFileExists(culture, moduleId);
    }
}

function CheckIsResourceFileExists(culture, module) {
    var resourceGrid = $("#grdResourceData").data("tGrid");
    var url = $("#webUrl").val() + "/SystemConfiguration/LocalizationSettings/CheckIsResourceFileExists?culture=" + culture + "&moduleId=" + module;
    $.ajax({
        cache: false,
        url: url,
        type: "POST",
        data: null,
        dataType: 'text',
        success: function (result) {
            if (result == "FOUND") {
                resourceGrid.rebind({ moduleId: module, selectedCulture: culture });
            }
            else if (result == "NOTFOUND") {
                CreateNewResourceFile();
            }
            else {
                return;
            }
        },
        error: function (msg) {
            alert('Error' + msg.toString());
        }
    });
}

function CreateNewResourceFile() {
    var moduleCombo = $("#SelectedModule").data('tComboBox');
    var resourceGrid = $("#grdResourceData").data("tGrid");
    var cultureCombo = $("#SelectedCulture").data('tComboBox');

    if (resourceGrid.data == undefined) {
        return;
    }
    var toCreateNewFile = confirm(SystemConfigurationResources.msgConfirmResourceFileCreation);
    if (toCreateNewFile) {
        var url = $("#webUrl").val() + "/SystemConfiguration/LocalizationSettings/CreateNewResourceFile?culture=" + cultureCombo.value() + "&moduleId=" + moduleCombo.value();
        $.ajax({
            cache: false,
            url: url,
            type: "POST",
            data: null,
            dataType: 'text',
            success: function (result) {
                if (result == "DFNF") {
                    SetValidationErrorMessage(SystemConfigurationResources.msgErrorInResourceFileCreation);
                }
                else {
                    resourceGrid.rebind({ moduleId: moduleCombo.value(), selectedCulture: cultureCombo.value() });
                }
            },
            error: function (msg) {
                alert('Error' + msg.toString());
            }
        });
    }
    else {
        setTimeout(function () {
            $("#SelectedModule").data("tComboBox").value(0);
        }, 100);
    }
}


function OnGrdResourceDataDataBinding(args) {
    var cultureValue = $("#SelectedCulture").data('tComboBox').value();
    var moduleValue = $("#SelectedModule").data('tComboBox').value();
    args.data = $.extend(args.data, { moduleId: moduleValue, selectedCulture: cultureValue });
}

function onSaveComplete(e) {
    if (e.name == "submitChanges") {
        SetValidationSuccessMessage(SystemConfigurationResources.ResourceFileSavedSuccessfully);
    }
}