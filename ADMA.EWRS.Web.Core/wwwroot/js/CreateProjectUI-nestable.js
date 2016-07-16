var UINestable = function () {
    "use strict";
    //function to initiate jquery.nestable
    var updateOutput = function (e) {
        //var list = e.length ? e : $(e.target),
        //    output = $('#nestable-output');
        //if (window.JSON) {
        //    output.text(window.JSON.stringify(list.nestable('serialize')));
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