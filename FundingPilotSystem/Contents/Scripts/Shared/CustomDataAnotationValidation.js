if ($.validator && $.validator.unobtrusive) {

    $.validator.unobtrusive.adapters.addSingleVal("customstringlength", "maximumlength");
    $.validator.addMethod("customstringlength", function (value, element, maximumLength) {
        if (value) {
            if (value.trim().length > maximumLength) {
                return false;
            }
        }
        return true;
    });

    $.validator.unobtrusive.adapters.addSingleVal("customregularexpression", "pattern");
    $.validator.addMethod("customregularexpression", function (value, element, pattern) {
        if (value) {
            var characterReg = new RegExp(pattern.trim());
            if (!characterReg.test(value.trim())) {
                return false;
            }
        }
        return true;
    });

    $.validator.unobtrusive.adapters.addSingleVal("customrange", "range");
    $.validator.addMethod("customrange", function (value, element, range) {
        if (value) {
            var rangeValues = range.trim().split('~');
            var min = parseFloat(rangeValues[0]);
            var max = parseFloat(rangeValues[1]);
            if (value.trim() >= min && value.trim() <= max) {
                return true;
            }
            else {
                return false;
            }
        }
    });
}