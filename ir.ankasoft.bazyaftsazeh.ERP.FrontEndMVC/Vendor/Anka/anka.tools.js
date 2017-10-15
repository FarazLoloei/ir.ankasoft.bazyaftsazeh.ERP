function UpdateQueryString(key, value) {
    var url = window.location.href;
    var finalURL;
    var re = new RegExp("([?&])" + key + "=.*?(&|#|$)(.*)", "gi"),
        hash;

    if (re.test(url)) {
        if (typeof value !== 'undefined' && value !== null)
            finalURL = url.replace(re, '$1' + key + "=" + value + '$2$3');
            //return url.replace(re, '$1' + key + "=" + value + '$2$3');
        else {
            hash = url.split('#');
            url = hash[0].replace(re, '$1$3').replace(/(&|\?)$/, '');
            if (typeof hash[1] !== 'undefined' && hash[1] !== null)
                url += '#' + hash[1];
            finalURL = url;
            //return url;
        }
    }
    else {
        if (typeof value !== 'undefined' && value !== null) {
            var separator = url.indexOf('?') !== -1 ? '&' : '?';
            hash = url.split('#');
            url = hash[0] + separator + key + '=' + value;
            if (typeof hash[1] !== 'undefined' && hash[1] !== null)
                url += '#' + hash[1];
            finalURL = url;
            //return url;
        }
        else
            finalURL = url;
        //return url;
    }
    window.history.pushState(null, document.title, finalURL);
}

function UpdateQueryString(serializedValues) {
    try {
        var href = window.location.href.split('?')[0];
        href += "?" + serializedValues;
        //window.location.href = href;
        window.history.pushState(null, document.title, href);
    } catch (e) {
    }
}
$(document).ready(function () {
    //document.addEventListener('contextmenu', event => event.preventDefault());
});