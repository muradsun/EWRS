//===============================================
//Start Project Info Wizard Step :: Step 1
//===============================================
//Validate and Save, return false if want to stay at step

function SaveProjectInfoWizardStep() {
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
//End Project Info Wizard Step :: Step 1
//===============================================