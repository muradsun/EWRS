var UINestable = function () {
    "use strict";
    //function to initiate jquery.nestable
    var updateOutputTemp = function (e) {
        var list = e.length ? e : $(e.target);
        var str = list.nestable('serialize');
        var elmItem;

        for (var i = 0; i < str.length; i++) {
            elmItem = list.find("[data-id='" + str[i].id + "']");
            elmItem.find("#hdnSequenceNo_" + str[i].id).val(i + 1);
        }
    };

    var updateOutputWf = function (e) {
        var list = e.length ? e : $(e.target);
        var str = list.nestable('serialize');
        var elmItem;


        //Skip originator 
        for (var i = 1; i < str.length; i++) {
            elmItem = list.find("[data-id='" + str[i].id + "']");

            elmItem.find(".nstWf_hdnSequenceNo").val(i + 1);
            elmItem.find(".btn-seq").text(i + 1);
        }
    };

    var runNestable = function () {
        //Templates Step
        // activate Nestable for list 1
        $('#nestable').nestable({
            maxDepth: 1
        }).on('change', updateOutputTemp);

        //Workflow Step
        $('#nestableWf').nestable({
            maxDepth: 1
        }).on('change', updateOutputWf);
    };
    return {
        //main function to initiate template pages
        init: function () {
            runNestable();
        }
    };
}();