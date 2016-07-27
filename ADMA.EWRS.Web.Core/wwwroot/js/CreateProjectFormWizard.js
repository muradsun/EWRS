var FormWizard = function () {
    "use strict";
    var wizardContent = $('#wizard');
    var wizardForm = $('#form');
    var numberOfSteps = $('.swMain > ul > li').length;
    var initWizard = function () {
        // function to initiate Wizard Form
        wizardContent.smartWizard({
            // Check this: jquery.smartWizard.js https://github.com/mstratman/jQuery-Smart-Wizard/blob/master/README.md
            selected: 0, // Selected Step, 0 = first step   
            keyNavigation: false,
            onLeaveStep: leaveAStepCallback, // triggers when leaving a step
            onShowStep: onShowStep // triggers when showing a step
            //onFinish: null,  // triggers when Finish button is clicked
            //includeFinishButton: true,   // Add the finish button
            //reverseButtonsOrder: false //shows buttons ordered as: prev, next and finish    
        });
        var numberOfSteps = 0;
        initValidator();
    }; //end initWizard

    var initValidator = function () {
        //Modify default settings for validation. See : https://jqueryvalidation.org/jQuery.validator.setDefaults
        $.validator.setDefaults({
            errorElement: "span", // contain the error msg in a span tag
            errorClass: 'help-block',
            ignore: ':hidden',
            rules: {
                Name: {
                    minlength: 3,
                    required: true
                },
                TemplateName: {
                    minlength: 3,
                    required: true
                    //,email: true
                },
                txtSubject_1: {
                    minlength: 3,
                    required: true
                },
                txtSubject_2: {
                    minlength: 3,
                    required: true
                },
                txtSubject_3: {
                    minlength: 3,
                    required: true
                }
                //password: {
                //    minlength: 6,
                //    required: true
                //},
                //password2: {
                //    required: true,
                //    minlength: 5,
                //    equalTo: "#password"
                //}
            },
            messages: {
                Name: "Project Name is required, minimum 3 characters",
                TemplateName: "Project Name is required, minimum 3 characters",
                txtSubject: "Subject Name is required, minimum 3 characters"
            },
            highlight: function (element) {
                $(element).closest('.help-block').removeClass('valid');
                // display OK icon
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error').find('.symbol').removeClass('ok').addClass('required');
                // add the Bootstrap error class to the control group
            },
            unhighlight: function (element) { // revert the change done by hightlight
                $(element).closest('.form-group').removeClass('has-error');
                // set error class to the control group
            },
            success: function (label, element) {
                label.addClass('help-block valid');
                // mark the current input as valid and display OK icon
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success').find('.symbol').removeClass('required').addClass('ok');
            }
        });
    };

    var displayConfirm = function () {
        $('.display-value', form).each(function () {
            var input = $('[name="' + $(this).attr("data-display") + '"]', form);
            if (input.attr("type") == "text" || input.attr("type") == "email" || input.is("textarea")) {
                $(this).html(input.val());
            } else if (input.is("select")) {
                $(this).html(input.find('option:selected').text());
            } else if (input.is(":radio") || input.is(":checkbox")) {

                $(this).html(input.filter(":checked").closest('label').text());
            } else if ($(this).attr("data-display") == 'card_expiry') {
                $(this).html($('[name="card_expiry_mm"]', form).val() + '/' + $('[name="card_expiry_yyyy"]', form).val());
            }
        });
    };

    var onShowStep = function (obj, context) {
        if (context.toStep == numberOfSteps) {
            $('.anchor').children("li:nth-child(" + context.toStep + ")").children("a").removeClass('wait');
            displayConfirm();
        }
        $(".next-step").unbind("click").click(function (e) {
            e.preventDefault();
            wizardContent.smartWizard("goForward");
        });
        $(".back-step").unbind("click").click(function (e) {
            e.preventDefault();
            wizardContent.smartWizard("goBackward");
        });
        $(".go-first").unbind("click").click(function (e) {
            e.preventDefault();
            wizardContent.smartWizard("goToStep", 1);
        });
        $(".finish-step").unbind("click").click(function (e) {
            e.preventDefault();
            onFinish(obj, context);
        });
    };

    var leaveAStepCallback = function (obj, context) {
        var isValidStep = validateSteps(context.fromStep, context.toStep);

        if (isValidStep & context.fromStep == 1 & context.toStep == 2)
            return SaveProjectInfoWizardStep();


        if (isValidStep & context.fromStep == 2 & context.toStep == 3)
            return SaveTemplateWizardStep();


        return isValidStep;
        // return false to stay on step and true to continue navigation
    };

    var onFinish = function (obj, context) {
        if (validateAllSteps()) {
            alert('form submit function');
            $('.anchor').children("li").last().children("a").removeClass('wait').removeClass('selected').addClass('done').children('.stepNumber').addClass('animated tada');
            //wizardForm.submit();
        }
    };

    var validateSteps = function (stepnumber, nextstep) {
        var isStepValid = false;
        if (numberOfSteps >= nextstep && nextstep > stepnumber) {

            // cache the form element selector
            if (wizardForm.valid()) { // validate the form
                wizardForm.validate().focusInvalid();
                for (var i = stepnumber; i <= nextstep; i++) {
                    $('.anchor').children("li:nth-child(" + i + ")").not("li:nth-child(" + nextstep + ")").children("a").removeClass('wait').addClass('done').children('.stepNumber').addClass('animated tada');
                }
                //focus the invalid fields
                isStepValid = true;
                return true;
            };
        } else if (nextstep < stepnumber) {
            for (i = nextstep; i <= stepnumber; i++) {
                $('.anchor').children("li:nth-child(" + i + ")").children("a").addClass('wait').children('.stepNumber').removeClass('animated tada');
            }

            return true;
        }
    };

    var validateAllSteps = function () {
        var isStepValid = true;
        // all step validation logic
        return isStepValid;
    };

    return {
        init: function () {
            initWizard();

        }
    };
}();

//MYasin
//Adding the Add new row button logic

jQuery(document).ready(function () {
    Main.init();

    FormWizard.init();
    UINotifications.init();
    UINestable.init();

    //var scriptTemplate = kendo.template($("#subjects-template").html());
    //$.each(subjectsArray, function (index, value) {
    //    //alert(index + ": " + value);
    //    $("#TextBoxesGroup").append(scriptTemplate(value));
    //});

    //$("#addButton").click(function () {
    //    var data = { SubjectName: " << New Subject >> " };
    //    $("#TextBoxesGroup").append(scriptTemplate(data));
    //});
});

//function removeSubject(itemClicked) {
//    if (window.confirm("Are you sure wallah ?"))
//        $(itemClicked).closest('.row').detach();
//}