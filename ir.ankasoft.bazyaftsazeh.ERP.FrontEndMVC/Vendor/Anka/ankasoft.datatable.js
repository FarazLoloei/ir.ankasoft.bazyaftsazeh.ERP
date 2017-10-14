﻿$(document).ready(function () {
    $('table.anka_dataTable').find('thead tr th').each(function (e) {
        var aTag = $(this).find('a');
        aTag.bind('click', function () { toggleSortIcon(aTag); });
    })
});

function managePagination(_currentPage) {
    var page = $('input[name=page]');
    var pageVal = page.val();
    switch (_currentPage) {
        case '+':
            pageVal++;
            break;
        case '-':
            pageVal--;
            break;
        case '>>':
            pageVal = 1;
            break;
        default:
            pageVal = _currentPage;
    }
    page.val(pageVal);
    $('#dataTable').submit();
};

function toggleSortIcon(header) {
    var $header = $(header);
    var i = $header.parent().find('i');
    if (i.hasClass('fa-sort')) {
        i.removeClass('fa-sort');
        i.addClass('fa-sort-amount-desc');
    }
    i.toggleClass('fa-sort-amount-desc fa-sort-amount-asc');

    var thead = $('table.anka_dataTable').find('thead');
    console.info(thead);
    $('#sortBy').val($header.data('column'));
    var sortType = 1;
    if (i.hasClass('fa-sort-amount-desc'))
        sortType = 2;
    $('#sortType').val(sortType);

    $('#dataTable').submit();
}