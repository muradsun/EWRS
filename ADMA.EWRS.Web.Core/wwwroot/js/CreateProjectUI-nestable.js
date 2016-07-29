var UINestable = function () {
    "use strict";
    //function to initiate jquery.nestable
    var updateOutput = function (e) {
      
        var list = e.length ? e : $(e.target);
        var str = list.nestable('serialize');
        var elmItem;

        for (var i = 0; i < str.length; i++) {
            elmItem = list.find("[data-id='" + str[i].id + "']");
            elmItem.find("#hdnSequenceNo_" + str[i].id).val(i + 1);
        }
        //    output = $('#nestable-output');
        //if (window.JSON) {
        //    output.text(window.JSON.stringify());
        //    //, null, 2));
        //} else {
        //    output.text('JSON browser support required for this demo.');
        //}
    };

    var runNestable = function () {
        // activate Nestable for list 1
        $('#nestable').nestable({
            maxDepth: 1
        }).on('change', updateOutput);

    };
    return {
        //main function to initiate template pages
        init: function () {
            runNestable();
        }
    };
}();