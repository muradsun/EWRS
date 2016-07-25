'use strict';
var UIElements = function () {
    var paginationHandler = function () {
        $("#pagination-UsersGroups").twbsPagination({
            totalPages: 35,
            visiblePages: 8,
            href: '#page={{number}}',
            onPageClick: function (event, page) {
                $("#page-content-2").text('Page ' + page);
            }
        });
    };
    return {
        init: function () {
            //staticPopoverHandler();
            //animatedProgressbarHandler();
            paginationHandler();
            //ratingHandler();
        }
    };
}();
