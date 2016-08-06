//===============================================
//Start Project Info Wizard Step :: Step 1
//===============================================
//Validate and Save, return false if want to stay at step

function SaveProjectInfoWizardStep() {
    //Call validation 
    if (!$('#form').valid())
        return false;

    var pData = CollectProjInfoStepInfo();
    $.ajax({
        url: "/Project/SaveProjectWizardStep",
        success: function (result) {
            if (result.success) {
                $("#hdnProjectId").val(result.data);
                _projectId = result.data;

                //Move forward
                $('#wizard').smartWizard("goToStep", 2);
                UINotifications.ShowToast("success", "Your Project [ " + pData.Name + " ] Saved Successful.", "Saved Successful");

            } else {
                //Optimize error codes 
                jQuery.each(result.businessErrors, function (i, val) {
                    result.businessErrors[i].entityName = val.entityName.indexOf("Models.Project") > 0 ? "Project Info Step" : val.entityName;
                    //result.businessErrors[i].errorMessage = 
                    result.businessErrors[i].propertyName = val.propertyName.indexOf("PercentComplete") > 0 ? "Percent Complete" : val.propertyName;
                });

                //Get Error Template and show it on dialog modal 
                var scriptTemplate = kendo.template($("#modal-template").html());
                var subjHTML = scriptTemplate(result.businessErrors);
                FormWizardCommon.ShowAjaxModal(subjHTML);
            }
        },
        cache: false,
        error: function (xhr, status, error) {
            UINotifications.ShowToast("error", "Error Message: [ " + error + " ]", "Save Failed");
        },
        type: "POST",
        data: JSON.stringify(pData),
        contentType: "application/json"
    });

    return false;
}

function CollectProjInfoStepInfo() {
    var projectInfoWizardStepView = {};
    projectInfoWizardStepView.Project_Id = $("#hdnProjectId").val();
    projectInfoWizardStepView.Name = $("#txtName").val();
    projectInfoWizardStepView.Description = $("#txtDescription").val();
    projectInfoWizardStepView.ORGANIZATION_ID = $("#hdnORGANIZATION_ID").val();
    projectInfoWizardStepView.OrganizationHierarchyTree = null;

    return projectInfoWizardStepView;
}

//===============================================
//End 
//===============================================

//===============================================
//Start Template Wizard Step :: Step 2
//===============================================

function validateForm() {
    var valElm = null;
    var isValidForm = true;

    //Call validation 
    if (!$('#form').valid())
        return false;

    //Murad :: TODO fix this reference
    if ($(".txtSubject").length < 1) {
        alert("At least one subject is required");
        return false;
    }

    $(".txtSubject").each(function (index) {
        valElm = $(this);
        if (valElm.val().trim() == "" || $.trim(valElm.val()).length < 3) {
            isValidForm = isValidForm && false;
            valElm.closest(".form-group").addClass("has-error");
            valElm.closest(".form-group").find(".has-error-H").addClass("has-error-S");
        } else {
            isValidForm = isValidForm && true;
            valElm.closest(".form-group").removeClass("has-error").addClass("has-success");
            valElm.closest(".form-group").find(".has-error-H").removeClass("has-error-S");
        }
    });
    return isValidForm;
}

function SaveTemplateWizardStep() {
    debugger;
    if (!validateForm())
        return false;

    var pData = CollectTempStepInfo();
    $.ajax({
        url: "/Project/SaveTemplateWizardStep",
        success: function (result) {
            debugger;
            if (result.success) {
                $("#hdnTemplateId").val(result.data.template_Id); //Template_Id
                $.each(result.data.subjects, function (index, value) {
                    $("#hdnSubjectId_" + value.sequenceNo).val(value.subject_Id);
                });

                //Move forward
                $('#wizard').smartWizard("goToStep", 3);
                UINotifications.ShowToast("success", "Your Template [ " + result.data.name + " ] Saved Successful.", "Saved Successfully");

            } else {
                //Optimize error codes 
                jQuery.each(result.businessErrors, function (i, val) {
                    result.businessErrors[i].entityName = val.entityName.indexOf("Models.Project") > 0 ? "Project Info Step" : val.entityName;
                    //result.businessErrors[i].errorMessage = 
                    result.businessErrors[i].propertyName = val.propertyName.indexOf("PercentComplete") > 0 ? "Percent Complete" : val.propertyName;
                });

                //Get Error Template and show it on dialog modal 
                var scriptTemplate = kendo.template($("#modal-template").html());
                var subjHTML = scriptTemplate(result.businessErrors);
                FormWizardCommon.ShowAjaxModal(subjHTML);
            }


        },
        cache: false,
        error: function (xhr, status, error) {
            UINotifications.ShowToast("error", "Error Message: [ " + error + " ]", "Save Failed");
        },
        type: "POST",
        data: JSON.stringify(pData),
        contentType: "application/json"
    });

    return true;

}

function CollectTempStepInfo() {
    var subjElm = null;
    var seqNo = 0;
    var chkMandatory = null;
    var dueDate = null;

    var templateWizardStepView = {};
    templateWizardStepView.Template_Id = $("#hdnTemplateId").val();
    templateWizardStepView.Project_Id = $("#hdnProjectId").val();
    templateWizardStepView.Name = $("#txtTemplateName").val();
    templateWizardStepView.Subjects = [];

    $(".txtSubject").each(function (index) {
        subjElm = $(this);
        seqNo = subjElm.attr("id").split("_")[1];
        //$("[id^=chkMandatory]").
        chkMandatory = $("#chkMandatory_" + seqNo);
        dueDate = subjElm.parentsUntil(".dd-item");
        dueDate = $(dueDate[dueDate.length - 1]).find(".datepickerElm");

        templateWizardStepView.Subjects[index] = {};
        templateWizardStepView.Subjects[index].Template_Id = templateWizardStepView.Template_Id;
        templateWizardStepView.Subjects[index].Subject_Id = $("#hdnSubjectId_" + seqNo).val();
        templateWizardStepView.Subjects[index].Name = subjElm.val();
        templateWizardStepView.Subjects[index].DueDate = $(dueDate[1]).val();
        templateWizardStepView.Subjects[index].IsMandatory = chkMandatory.is(':checked');
        templateWizardStepView.Subjects[index].SequenceNo = $("#hdnSequenceNo_" + seqNo).val();
    });

    return templateWizardStepView;
}

function GetDefualtSubjectWizardStepView(maxSeq) {
    var subjectWizardStepView = {};
    subjectWizardStepView.Template_Id = $("#txtTemplateName").val();
    subjectWizardStepView.Subject_Id = 0;
    subjectWizardStepView.Name = "";
    subjectWizardStepView.IsMandatory = true;
    subjectWizardStepView.SequenceNo = maxSeq;
    subjectWizardStepView.DueDate = null;

    return subjectWizardStepView;
}

function removeSubject(ctrl) {
    if (window.confirm("Are you sure you want to delete this subject ?"))
        $(ctrl).closest('.dd-item').detach();
}

function bindDatePicker(isNew) {
    if (isNew == false)
        $(".datepickerElm").kendoDatePicker({ format: "dd-MMMM-yyyy" });
    else {
        $(".datepickerElmNew").kendoDatePicker({ format: "dd-MMMM-yyyy" });
        $(".datepickerElmNew").removeClass("datepickerElmNew").addClass("datepickerElm");
    }
}

$(document).ready(function () {
    $('#wizard').smartWizard("goToStep", 2);

    bindDatePicker(false);

    $("#btnstep2AddSubj").click(function () {
        //Calculate Max Seq
        var maxSeq = 0;
        var subSeq = 0;
        var x = $(".dd-item input[type=checkbox]").each(function (index) {
            subSeq = $(this).attr('id').split("_")[1];
            if (maxSeq < subSeq)
                maxSeq = parseInt(subSeq);
        });
        maxSeq += 1;

        //Get JSON Defualt Object
        var subObj = GetDefualtSubjectWizardStepView(maxSeq);

        //bind JSON to template
        var scriptTemplate = kendo.template($("#subjects-template").html());
        $(".dd-list").append(scriptTemplate(subObj));

        //Bind DataPiacker
        bindDatePicker(true);

    });

    $(".txtSubject").focusout(function () {
        //$(".txtSubject").each(function (index) {
        //    valElm = $(this);
        //    if (valElm.val().trim() == "" || valElm.val().trim().length <= 3) {
        //        valElm.closest(".form-group").addClass("has-error");
        //        valElm.closest(".form-group").find(".has-error-H").addClass("has-error-S");
        //    } else {
        //        valElm.closest(".form-group").removeClass("has-error").addClass("has-success");
        //        valElm.closest(".form-group").find(".has-error-H").removeClass("has-error-S");
        //    }
        //});
    })

});


//===============================================
//End 
//===============================================


//===============================================
//Start Team Model Wizard Step :: Step 3
//===============================================
var activeElm = null;
var mainWindow = null;

$(document).ready(function () {
    MixDataUp();

    $("#dilgWndow").kendoWindow({
        width: "1024px",
        height: "500px",
        title: "Search for Users/Groups",
        visible: false,
        content: "/Account/SearchUsersGroups",
        actions: [
            "Maximize",
            "Close"
        ],
        modal: true,
        close: onWinClose,
        iframe: true
    });

    //Cache it
    mainWindow = $("#dilgWndow").data("kendoWindow");

    //Unit Test 1
    //var data = [];
    //for (var i = 0; i < 20; i++) {
    //    data[i] = {};
    //    data[i].ItemId = i;
    //    data[i].ItemType = i == 0 ? 1 : 2;
    //    data[i].Name = "Murad " + i;
    //    data[i].Icon = "/images/form/User_male.png";
    //}
    //loadAddedUsersGroups(data);
});

function onWinClose() {
}

function MixDataUp() {
    $('#TeamContainer').mixItUp({
        animation: {
            enable: false
        },
        layout: {
            display: 'inline'
        },
        callbacks: {
            onMixLoad: function () {
                $(this).mixItUp('setOptions', {
                    animation: {
                        enable: true
                    },
                });
            }
        }
    });
}

function loadAddedUsersGroups(addUsersGroupsView) {
    var teamCont = $('#TeamContainer');

    if (teamCont.find(".panel-heading").length > 0)
        teamCont.html("");

    $('#TeamContainer').mixItUp('destroy');
    var scriptTemplate = kendo.template($("#team-template").html());

    //Construct Data Object
    var data = [];
    $.each(addUsersGroupsView, function (index, value) {
        data[index] = {};
        data[index].TeamModel_Id = 0;
        if (value.ItemType == 1) //"chkUser" ? 1
        {
            data[index].User_Id = value.ItemId;
        } else {
            data[index].Group_Id = value.ItemId;
        }
        data[index].IsUpdater = false;
        data[index].UpdateText = "viewer"; //viewer OR updater
        data[index].SequenceNo = index;
        data[index].Project_Id = 0;
        data[index].IsProjectLevel = true;
        data[index].SubjectsArray = "aaaa";
        data[index].Icon = value.Icon;
        data[index].Name = value.Name;
    });

    var addedElm = $(scriptTemplate(data));
    $("#TeamContainer").append(addedElm);

    //Reload Custom selected
    addedElm.find('.cs-select').each(function (index) {
        var el = $(this)
        new SelectFx(el[0], {
            stickyPlaceholder: false,
            onChange: function (val) {
                selectChange(el, val);
            }
        });
    });

    addedElm.find('[data-toggle="popover"]').popover();

    MixDataUp();

    var myWindow = null;

    if (mainWindow)
        myWindow = mainWindow;
    else
        myWindow = $("#dilgWndow").data("kendoWindow");

    //Main.init();

    myWindow.close();
}

function selectChange(eld, val) {
    var xElm = $(eld).closest('.mix');
    if (val == "Updater") {
        xElm.removeClass("viewer").addClass("updater");
        xElm.find(".thumbnail").removeClass("thumbnail-viewer").addClass("thumbnail-updater");
    } else {
        xElm.removeClass("updater").addClass("viewer");
        xElm.find(".thumbnail").removeClass("thumbnail-updater").addClass("thumbnail-viewer");
    }
}

function deleteTM(itemClicked) {
    if (window.confirm("Are you sure you want to delete this Team Model item?")) {
        var xElm = $(itemClicked).closest('.mix');
        xElm.fadeOut('slow');
        setTimeout(function () { xElm.detach(); }, 1000);
    }
}

function loadSubj4TeamModel(elm, seqNo) {
    var jElm = $(elm);
    activeElm = jElm;
    //var rElm = jElm.closest(".radio").find("input");

    //bind JSON to template
    var scriptTemplate = kendo.template($("#teamSubjects-template").html());
    var subjHTML = scriptTemplate({});

    jElm.attr("data-content", subjHTML);
}

function tmSubjectSelect() {
    //data-TMSubjects

}

function showAddDlg() {
    var myWindow = null;

    if (mainWindow)
        myWindow = mainWindow;
    else
        myWindow = $("#dilgWndow").data("kendoWindow");

    myWindow.center().open();
}

//===============================================
//End 
//===============================================
