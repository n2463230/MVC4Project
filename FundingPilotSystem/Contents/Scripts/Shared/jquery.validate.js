/*! jQuery Validation Plugin - v1.10.0 - 9/7/2012
 * https://github.com/jzaefferer/jquery-validation
 * Copyright (c) 2012 Jörn Zaefferer; Licensed MIT */
(function (b) {
    b.extend(b.fn, {
        validate: function (a) {
            if (!this.length) {
                a && a.debug && window.console && console.warn("nothing selected, can't validate, returning nothing");
                return
            }
            var d = b.data(this[0], "validator");
            return d ? d : (this.attr("novalidate", "novalidate"), d = new b.validator(a, this[0]), b.data(this[0], "validator", d), d.settings.onsubmit && (this.validateDelegate(":submit", "click", function (c) {
                d.settings.submitHandler && (d.submitButton = c.target), b(c.target).hasClass("cancel") && (d.cancelSubmit = !0)
            }), this.submit(function (c) {
                function e() {
                    var f;
                    return d.settings.submitHandler ? (d.submitButton && (f = b("<input type='hidden'/>").attr("name", d.submitButton.name).val(d.submitButton.value).appendTo(d.currentForm)), d.settings.submitHandler.call(d, d.currentForm, c), d.submitButton && f.remove(), !1) : !0
                }
                return d.settings.debug && c.preventDefault(), d.cancelSubmit ? (d.cancelSubmit = !1, e()) : d.form() ? d.pendingRequest ? (d.formSubmitted = !0, !1) : e() : (d.focusInvalid(), !1)
            })), d)
        },
        valid: function () {
            if (b(this[0]).is("form")) {
                return this.validate().form()
            }
            var a = !0,
                d = b(this[0].form).validate();
            return this.each(function () {
                a &= d.element(this)
            }), a
        },
        removeAttrs: function (a) {
            var f = {}, e = this;
            return b.each(a.split(/\s/), function (d, c) {
                f[c] = e.attr(c), e.removeAttr(c)
            }), f
        },
        rules: function (r, q) {
            var p = this[0];
            if (r) {
                var o = b.data(p.form, "validator").settings,
                    n = o.rules,
                    m = b.validator.staticRules(p);
                switch (r) {
                    case "add":
                        b.extend(m, b.validator.normalizeRule(q)), n[p.name] = m, q.messages && (o.messages[p.name] = b.extend(o.messages[p.name], q.messages));
                        break;
                    case "remove":
                        if (!q) {
                            return delete n[p.name], m
                        }
                        var l = {};
                        return b.each(q.split(/\s/), function (d, c) {
                            l[c] = m[c], delete m[c]
                        }), l
                }
            }
            var k = b.validator.normalizeRules(b.extend({}, b.validator.metadataRules(p), b.validator.classRules(p), b.validator.attributeRules(p), b.validator.staticRules(p)), p);
            if (k.required) {
                var a = k.required;
                delete k.required, k = b.extend({
                    required: a
                }, k)
            }
            return k
        }
    }), b.extend(b.expr[":"], {
        blank: function (a) {
            return !b.trim("" + a.value)
        },
        filled: function (a) {
            return !!b.trim("" + a.value)
        },
        unchecked: function (c) {
            return !c.checked
        }
    }), b.validator = function (a, d) {
        this.settings = b.extend(!0, {}, b.validator.defaults, a), this.currentForm = d, this.init()
    }, b.validator.format = function (a, d) {
        return arguments.length === 1 ? function () {
            var e = b.makeArray(arguments);
            return e.unshift(a), b.validator.format.apply(this, e)
        } : (arguments.length > 2 && d.constructor !== Array && (d = b.makeArray(arguments).slice(1)), d.constructor !== Array && (d = [d]), b.each(d, function (e, f) {
            a = a.replace(new RegExp("\\{" + e + "\\}", "g"), f)
        }), a)
    }, b.extend(b.validator, {
        defaults: {
            messages: {},
            groups: {},
            rules: {},
            errorClass: "error",
            validClass: "valid",
            errorElement: "label",
            focusInvalid: !0,
            errorContainer: b([]),
            errorLabelContainer: b([]),
            onsubmit: !0,
            ignore: ":hidden",
            ignoreTitle: !1,
            onfocusin: function (d, c) {
                this.lastActive = d, this.settings.focusCleanup && !this.blockFocusCleanup && (this.settings.unhighlight && this.settings.unhighlight.call(this, d, this.settings.errorClass, this.settings.validClass), this.addWrapper(this.errorsFor(d)).hide())
            },
            onfocusout: function (d, c) {
                !this.checkable(d) && (d.name in this.submitted || !this.optional(d)) && this.element(d)
            },
            onkeyup: function (d, c) {
                if (c.which === 9 && this.elementValue(d) === "") {
                    return
                } (d.name in this.submitted || d === this.lastActive) && this.element(d)
            },
            onclick: function (d, c) {
                d.name in this.submitted ? this.element(d) : d.parentNode.name in this.submitted && this.element(d.parentNode)
            },
            highlight: function (a, f, e) {
                a.type === "radio" ? this.findByName(a.name).addClass(f).removeClass(e) : b(a).addClass(f).removeClass(e)
            },
            unhighlight: function (a, f, e) {
                a.type === "radio" ? this.findByName(a.name).removeClass(f).addClass(e) : b(a).removeClass(f).addClass(e)
            }
        },
        setDefaults: function (a) {
            b.extend(b.validator.defaults, a)
        },
        messages: {
            required: "This field is required.",
            remote: "Please fix this field.",
            email: "Please enter a valid email address.",
            url: "Please enter a valid URL.",
            date: "Please enter a valid date.",
            dateISO: "Please enter a valid date (ISO).",
            number: "Please enter a valid number.",
            digits: "Please enter only digits.",
            creditcard: "Please enter a valid credit card number.",
            equalTo: "Please enter the same value again.",
            maxlength: b.validator.format("Please enter no more than {0} characters."),
            minlength: b.validator.format("Please enter at least {0} characters."),
            rangelength: b.validator.format("Please enter a value between {0} and {1} characters long."),
            range: b.validator.format("Please enter a value between {0} and {1}."),
            max: b.validator.format("Please enter a value less than or equal to {0}."),
            min: b.validator.format("Please enter a value greater than or equal to {0}.")
        },
        autoCreateRanges: !1,
        prototype: {
            init: function () {
                function e(g) {
                    var i = b.data(this[0].form, "validator"),
                        h = "on" + g.type.replace(/^validate/, "");
                    i.settings[h] && i.settings[h].call(i, this[0], g)
                }
                this.labelContainer = b(this.settings.errorLabelContainer), this.errorContext = this.labelContainer.length && this.labelContainer || b(this.currentForm), this.containers = b(this.settings.errorContainer).add(this.settings.errorLabelContainer), this.submitted = {}, this.valueCache = {}, this.pendingRequest = 0, this.pending = {}, this.invalid = {}, this.reset();
                var a = this.groups = {};
                b.each(this.settings.groups, function (h, g) {
                    b.each(g.split(/\s/), function (c, i) {
                        a[i] = h
                    })
                });
                var f = this.settings.rules;
                b.each(f, function (c, g) {
                    f[c] = b.validator.normalizeRule(g)
                }), b(this.currentForm).validateDelegate(":text, [type='password'], [type='file'], select, textarea, [type='number'], [type='search'] ,[type='tel'], [type='url'], [type='email'], [type='datetime'], [type='date'], [type='month'], [type='week'], [type='time'], [type='datetime-local'], [type='range'], [type='color'] ", "focusin focusout keyup", e).validateDelegate("[type='radio'], [type='checkbox'], select, option", "click", e), this.settings.invalidHandler && b(this.currentForm).bind("invalid-form.validate", this.settings.invalidHandler)
            },
            form: function () {
                return this.checkForm(), b.extend(this.submitted, this.errorMap), this.invalid = b.extend({}, this.errorMap), this.valid() || b(this.currentForm).triggerHandler("invalid-form", [this]), this.showErrors(), this.valid()
            },
            checkForm: function () {
                this.prepareForm();
                for (var d = 0, c = this.currentElements = this.elements() ; c[d]; d++) {
                    this.check(c[d])
                }
                return this.valid()
            },
            element: function (a) {
                a = this.validationTargetFor(this.clean(a)), this.lastElement = a, this.prepareElement(a), this.currentElements = b(a);
                var d = this.check(a) !== !1;
                return d ? delete this.invalid[a.name] : this.invalid[a.name] = !0, this.numberOfInvalids() || (this.toHide = this.toHide.add(this.containers)), this.showErrors(), d
            },
            showErrors: function (a) {
                if (a) {
                    b.extend(this.errorMap, a), this.errorList = [];
                    for (var d in a) {
                        this.errorList.push({
                            message: a[d],
                            element: this.findByName(d)[0]
                        })
                    }
                    this.successList = b.grep(this.successList, function (c) {
                        return !(c.name in a)
                    })
                }
                this.settings.showErrors ? this.settings.showErrors.call(this, this.errorMap, this.errorList) : this.defaultShowErrors()
            },
            resetForm: function () {
                b.fn.resetForm && b(this.currentForm).resetForm(), this.submitted = {}, this.lastElement = null, this.prepareForm(), this.hideErrors(), this.elements().removeClass(this.settings.errorClass).removeData("previousValue")
            },
            numberOfInvalids: function () {
                return this.objectLength(this.invalid)
            },
            objectLength: function (e) {
                var d = 0;
                for (var f in e) {
                    d++
                }
                return d
            },
            hideErrors: function () {
                this.addWrapper(this.toHide).hide()
            },
            valid: function () {
                return this.size() === 0
            },
            size: function () {
                return this.errorList.length
            },
            focusInvalid: function () {
                if (this.settings.focusInvalid) {
                    try {
                        b(this.findLastActive() || this.errorList.length && this.errorList[0].element || []).filter(":visible").focus().trigger("focusin")
                    } catch (a) { }
                }
            },
            findLastActive: function () {
                var a = this.lastActive;
                return a && b.grep(this.errorList, function (c) {
                    return c.element.name === a.name
                }).length === 1 && a
            },
            elements: function () {
                var a = this,
                    d = {};
                return b(this.currentForm).find("input, select, textarea").not(":submit, :reset, :image, [disabled]").not(this.settings.ignore).filter(function () {
                    return !this.name && a.settings.debug && window.console && console.error("%o has no name assigned", this), this.name in d || !a.objectLength(b(this).rules()) ? !1 : (d[this.name] = !0, !0)
                })
            },
            clean: function (a) {
                return b(a)[0]
            },
            errors: function () {
                var a = this.settings.errorClass.replace(" ", ".");
                return b(this.settings.errorElement + "." + a, this.errorContext)
            },
            reset: function () {
                this.successList = [], this.errorList = [], this.errorMap = {}, this.toShow = b([]), this.toHide = b([]), this.currentElements = b([])
            },
            prepareForm: function () {
                this.reset(), this.toHide = this.errors().add(this.containers)
            },
            prepareElement: function (c) {
                this.reset(), this.toHide = this.errorsFor(c)
            },
            elementValue: function (a) {
                var f = b(a).attr("type"),
                    e = b(a).val();
                return f === "radio" || f === "checkbox" ? b('input[name="' + b(a).attr("name") + '"]:checked').val() : typeof e == "string" ? e.replace(/\r/g, "") : e
            },
            check: function (a) {
                a = this.validationTargetFor(this.clean(a));
                var p = b(a).rules(),
                    o = !1,
                    n = this.elementValue(a),
                    m;
                for (var l in p) {
                    var k = {
                        method: l,
                        parameters: p[l]
                    };
                    try {
                        m = b.validator.methods[l].call(this, n, a, k.parameters);
                        if (m === "dependency-mismatch") {
                            o = !0;
                            continue
                        }
                        o = !1;
                        if (m === "pending") {
                            this.toHide = this.toHide.not(this.errorsFor(a));
                            return
                        }
                        if (!m) {
                            return this.formatAndAdd(a, k), !1
                        }
                    } catch (j) {
                        throw this.settings.debug && window.console && console.log("exception occured when checking element " + a.id + ", check the '" + k.method + "' method", j), j
                    }
                }
                if (o) {
                    return
                }
                return this.objectLength(p) && this.successList.push(a), !0
            },
            customMetaMessage: function (a, f) {
                if (!b.metadata) {
                    return
                }
                var e = this.settings.meta ? b(a).metadata()[this.settings.meta] : b(a).metadata();
                return e && e.messages && e.messages[f]
            },
            customDataMessage: function (a, d) {
                return b(a).data("msg-" + d.toLowerCase()) || a.attributes && b(a).attr("data-msg-" + d.toLowerCase())
            },
            customMessage: function (e, d) {
                var f = this.settings.messages[e];
                return f && (f.constructor === String ? f : f[d])
            },
            findDefined: function () {
                for (var c = 0; c < arguments.length; c++) {
                    if (arguments[c] !== undefined) {
                        return arguments[c]
                    }
                }
                return undefined
            },
            defaultMessage: function (a, d) {
                return this.findDefined(this.customMessage(a.name, d), this.customDataMessage(a, d), this.customMetaMessage(a, d), !this.settings.ignoreTitle && a.title || undefined, b.validator.messages[d], "<strong>Warning: No message defined for " + a.name + "</strong>")
            },
            formatAndAdd: function (a, h) {
                var g = this.defaultMessage(a, h.method),
                    f = /\$?\{(\d+)\}/g;
                typeof g == "function" ? g = g.call(this, h.parameters, a) : f.test(g) && (g = b.validator.format(g.replace(f, "{$1}"), h.parameters)), this.errorList.push({
                    message: g,
                    element: a
                }), this.errorMap[a.name] = g, this.submitted[a.name] = g
            },
            addWrapper: function (c) {
                return this.settings.wrapper && (c = c.add(c.parent(this.settings.wrapper))), c
            },
            defaultShowErrors: function () {
                var e, d;
                for (e = 0; this.errorList[e]; e++) {
                    var f = this.errorList[e];
                    this.settings.highlight && this.settings.highlight.call(this, f.element, this.settings.errorClass, this.settings.validClass), this.showLabel(f.element, f.message)
                }
                this.errorList.length && (this.toShow = this.toShow.add(this.containers));
                if (this.settings.success) {
                    for (e = 0; this.successList[e]; e++) {
                        this.showLabel(this.successList[e])
                    }
                }
                if (this.settings.unhighlight) {
                    for (e = 0, d = this.validElements() ; d[e]; e++) {
                        this.settings.unhighlight.call(this, d[e], this.settings.errorClass, this.settings.validClass)
                    }
                }
                this.toHide = this.toHide.not(this.toShow), this.hideErrors(), this.addWrapper(this.toShow).show()
            },
            validElements: function () {
                return this.currentElements.not(this.invalidElements())
            },
            invalidElements: function () {
                return b(this.errorList).map(function () {
                    return this.element
                })
            },
            showLabel: function (a, f) {
                var e = this.errorsFor(a);
                e.length ? (e.removeClass(this.settings.validClass).addClass(this.settings.errorClass), e.attr("generated") && e.html(f)) : (e = b("<" + this.settings.errorElement + "/>").attr({
                    "for": this.idOrName(a),
                    generated: !0
                }).addClass(this.settings.errorClass).html(f || ""), this.settings.wrapper && (e = e.hide().show().wrap("<" + this.settings.wrapper + "/>").parent()), this.labelContainer.append(e).length || (this.settings.errorPlacement ? this.settings.errorPlacement(e, b(a)) : e.insertAfter(a))), !f && this.settings.success && (e.text(""), typeof this.settings.success == "string" ? e.addClass(this.settings.success) : this.settings.success(e, a)), this.toShow = this.toShow.add(e)
            },
            errorsFor: function (a) {
                var d = this.idOrName(a);
                return this.errors().filter(function () {
                    return b(this).attr("for") === d
                })
            },
            idOrName: function (c) {
                return this.groups[c.name] || (this.checkable(c) ? c.name : c.id || c.name)
            },
            validationTargetFor: function (c) {
                return this.checkable(c) && (c = this.findByName(c.name).not(this.settings.ignore)[0]), c
            },
            checkable: function (c) {
                return /radio|checkbox/i.test(c.type)
            },
            findByName: function (a) {
                return b(this.currentForm).find('[name="' + a + '"]')
            },
            getLength: function (a, d) {
                switch (d.nodeName.toLowerCase()) {
                    case "select":
                        return b("option:selected", d).length;
                    case "input":
                        if (this.checkable(d)) {
                            return this.findByName(d.name).filter(":checked").length
                        }
                }
                return a.length
            },
            depend: function (d, c) {
                return this.dependTypes[typeof d] ? this.dependTypes[typeof d](d, c) : !0
            },
            dependTypes: {
                "boolean": function (d, c) {
                    return d
                },
                string: function (a, d) {
                    return !!b(a, d.form).length
                },
                "function": function (d, c) {
                    return d(c)
                }
            },
            optional: function (a) {
                var d = this.elementValue(a);
                return !b.validator.methods.required.call(this, d, a) && "dependency-mismatch"
            },
            startRequest: function (c) {
                this.pending[c.name] || (this.pendingRequest++, this.pending[c.name] = !0)
            },
            stopRequest: function (a, d) {
                this.pendingRequest--, this.pendingRequest < 0 && (this.pendingRequest = 0), delete this.pending[a.name], d && this.pendingRequest === 0 && this.formSubmitted && this.form() ? (b(this.currentForm).submit(), this.formSubmitted = !1) : !d && this.pendingRequest === 0 && this.formSubmitted && (b(this.currentForm).triggerHandler("invalid-form", [this]), this.formSubmitted = !1)
            },
            previousValue: function (a) {
                return b.data(a, "previousValue") || b.data(a, "previousValue", {
                    old: null,
                    valid: !0,
                    message: this.defaultMessage(a, "remote")
                })
            }
        },
        classRuleSettings: {
            required: {
                required: !0
            },
            email: {
                email: !0
            },
            url: {
                url: !0
            },
            date: {
                date: !0
            },
            dateISO: {
                dateISO: !0
            },
            number: {
                number: !0
            },
            digits: {
                digits: !0
            },
            creditcard: {
                creditcard: !0
            }
        },
        addClassRules: function (a, d) {
            a.constructor === String ? this.classRuleSettings[a] = d : b.extend(this.classRuleSettings, a)
        },
        classRules: function (a) {
            var f = {}, e = b(a).attr("class");
            return e && b.each(e.split(" "), function () {
                this in b.validator.classRuleSettings && b.extend(f, b.validator.classRuleSettings[this])
            }), f
        },
        attributeRules: function (a) {
            var j = {}, i = b(a);
            for (var h in b.validator.methods) {
                var g;
                h === "required" ? (g = i.get(0).getAttribute(h), g === "" && (g = !0), g = !!g) : g = i.attr(h), g ? j[h] = g : i[0].getAttribute("type") === h && (j[h] = !0)
            }
            return j.maxlength && /-1|2147483647|524288/.test(j.maxlength) && delete j.maxlength, j
        },
        metadataRules: function (a) {
            if (!b.metadata) {
                return {}
            }
            var d = b.data(a.form, "validator").settings.meta;
            return d ? b(a).metadata()[d] : b(a).metadata()
        },
        staticRules: function (a) {
            var f = {}, e = b.data(a.form, "validator");
            return e.settings.rules && (f = b.validator.normalizeRule(e.settings.rules[a.name]) || {}), f
        },
        normalizeRules: function (a, d) {
            return b.each(a, function (h, g) {
                if (g === !1) {
                    delete a[h];
                    return
                }
                if (g.param || g.depends) {
                    var c = !0;
                    switch (typeof g.depends) {
                        case "string":
                            c = !!b(g.depends, d.form).length;
                            break;
                        case "function":
                            c = g.depends.call(d, d)
                    }
                    c ? a[h] = g.param !== undefined ? g.param : !0 : delete a[h]
                }
            }), b.each(a, function (f, c) {
                a[f] = b.isFunction(c) ? c(d) : c
            }), b.each(["minlength", "maxlength", "min", "max"], function () {
                a[this] && (a[this] = Number(a[this]))
            }), b.each(["rangelength", "range"], function () {
                a[this] && (a[this] = [Number(a[this][0]), Number(a[this][1])])
            }), b.validator.autoCreateRanges && (a.min && a.max && (a.range = [a.min, a.max], delete a.min, delete a.max), a.minlength && a.maxlength && (a.rangelength = [a.minlength, a.maxlength], delete a.minlength, delete a.maxlength)), a.messages && delete a.messages, a
        },
        normalizeRule: function (a) {
            if (typeof a == "string") {
                var d = {};
                b.each(a.split(/\s/), function () {
                    d[this] = !0
                }), a = d
            }
            return a
        },
        addMethod: function (a, f, e) {
            b.validator.methods[a] = f, b.validator.messages[a] = e !== undefined ? e : b.validator.messages[a], f.length < 3 && b.validator.addClassRules(a, b.validator.normalizeRule(a))
        },
        methods: {
            required: function (a, h, g) {
                if (!this.depend(g, h)) {
                    return "dependency-mismatch"
                }
                if (h.nodeName.toLowerCase() === "select") {
                    var f = b(h).val();
                    return f && f.length > 0
                }
                return this.checkable(h) ? this.getLength(a, h) > 0 : b.trim(a).length > 0
            },
            remote: function (a, l, k) {
                if (this.optional(l)) {
                    return "dependency-mismatch"
                }
                var j = this.previousValue(l);
                this.settings.messages[l.name] || (this.settings.messages[l.name] = {}), j.originalMessage = this.settings.messages[l.name].remote, this.settings.messages[l.name].remote = j.message, k = typeof k == "string" && {
                    url: k
                } || k;
                if (this.pending[l.name]) {
                    return "pending"
                }
                if (j.old === a) {
                    return j.valid
                }
                j.old = a;
                var i = this;
                this.startRequest(l);
                var h = {};
                return h[l.name] = a, b.ajax(b.extend(!0, {
                    url: k,
                    mode: "abort",
                    port: "validate" + l.name,
                    dataType: "json",
                    data: h,
                    success: function (n) {
                        i.settings.messages[l.name].remote = j.originalMessage;
                        var m = n === !0 || n === "true";
                        if (m) {
                            var f = i.formSubmitted;
                            i.prepareElement(l), i.formSubmitted = f, i.successList.push(l), delete i.invalid[l.name], i.showErrors()
                        } else {
                            var e = {}, c = n || i.defaultMessage(l, "remote");
                            e[l.name] = j.message = b.isFunction(c) ? c(a) : c, i.invalid[l.name] = !0, i.showErrors(e)
                        }
                        j.valid = m, i.stopRequest(l, m)
                    }
                }, k)), "pending"
            },
            minlength: function (a, h, g) {
                var f = b.isArray(a) ? a.length : this.getLength(b.trim(a), h);
                return this.optional(h) || f >= g
            },
            maxlength: function (a, h, g) {
                var f = b.isArray(a) ? a.length : this.getLength(b.trim(a), h);
                return this.optional(h) || f <= g
            },
            rangelength: function (a, h, g) {
                var f = b.isArray(a) ? a.length : this.getLength(b.trim(a), h);
                return this.optional(h) || f >= g[0] && f <= g[1]
            },
            min: function (e, d, f) {
                return this.optional(d) || e >= f
            },
            max: function (e, d, f) {
                return this.optional(d) || e <= f
            },
            range: function (e, d, f) {
                return this.optional(d) || e >= f[0] && e <= f[1]
            },
            email: function (d, c) {
                return this.optional(c) || /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i.test(d)
            },
            url: function (d, c) {
                return this.optional(c) || /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i.test(d)
            },
            date: function (e, c) {
                var f = /^(0?[1-9]\/|[12]\d\/|3[01]\/){2}(19|20)\d\d$/;
                return this.optional(c) || f.test(e)
            },
            dateISO: function (d, c) {
                return this.optional(c) || /^\d{4}[\/\-]\d{1,2}[\/\-]\d{1,2}$/.test(d)
            },
            number: function (d, c) {
                return this.optional(c) || /^-?(?:\d+|\d{1,3}(?:,\d{3})+)?(?:\.\d+)?$/.test(d)
            },
            digits: function (d, c) {
                return this.optional(c) || /^\d+$/.test(d)
            },
            creditcard: function (i, h) {
                if (this.optional(h)) {
                    return "dependency-mismatch"
                }
                if (/[^0-9 \-]+/.test(i)) {
                    return !1
                }
                var n = 0,
                    m = 0,
                    l = !1;
                i = i.replace(/\D/g, "");
                for (var k = i.length - 1; k >= 0; k--) {
                    var j = i.charAt(k);
                    m = parseInt(j, 10), l && (m *= 2) > 9 && (m -= 9), n += m, l = !l
                }
                return n % 10 === 0
            },
            equalTo: function (a, h, g) {
                var f = b(g);
                return this.settings.onfocusout && f.unbind(".validate-equalTo").bind("blur.validate-equalTo", function () {
                    b(h).valid()
                }), a === f.val()
            }
        }
    }), b.format = b.validator.format
})(jQuery),
function (e) {
    var d = {};
    if (e.ajaxPrefilter) {
        e.ajaxPrefilter(function (b, i, h) {
            var g = b.port;
            b.mode === "abort" && (d[g] && d[g].abort(), d[g] = h)
        })
    } else {
        var f = e.ajax;
        e.ajax = function (c) {
            var b = ("mode" in c ? c : e.ajaxSettings).mode,
                a = ("port" in c ? c : e.ajaxSettings).port;
            return b === "abort" ? (d[a] && d[a].abort(), d[a] = f.apply(this, arguments)) : f.apply(this, arguments)
        }
    }
}(jQuery),
function (b) {
    !jQuery.event.special.focusin && !jQuery.event.special.focusout && document.addEventListener && b.each({
        focus: "focusin",
        blur: "focusout"
    }, function (a, f) {
        function e(c) {
            return c = b.event.fix(c), c.type = f, b.event.handle.call(this, c)
        }
        b.event.special[f] = {
            setup: function () {
                this.addEventListener(a, e, !0)
            },
            teardown: function () {
                this.removeEventListener(a, e, !0)
            },
            handler: function (c) {
                var g = arguments;
                return g[0] = b.event.fix(c), g[0].type = f, b.event.handle.apply(this, g)
            }
        }
    }), b.extend(b.fn, {
        validateDelegate: function (a, f, e) {
            return this.bind(f, function (g) {
                var d = b(g.target);
                if (d.is(a)) {
                    return e.apply(d, arguments)
                }
            })
        }
    })
}(jQuery);