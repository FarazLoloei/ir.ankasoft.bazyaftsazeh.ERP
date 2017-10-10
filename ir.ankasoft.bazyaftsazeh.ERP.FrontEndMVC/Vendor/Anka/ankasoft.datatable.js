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