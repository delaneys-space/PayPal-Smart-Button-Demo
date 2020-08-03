$(function () {
    $('#chkShowDeleted').change(function () {
        if ($(this).prop('checked')) {
            document.cookie = "ShowDeleted=true";
        }
        else {
            document.cookie = "ShowDeleted=false";
        }
    })
})

function GetCookie(name) {
    name = name + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}


function httpGet(url) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", url, false); // false for synchronous request
    xmlHttp.send(null);
    return xmlHttp.responseText;
}

String.prototype.replaceAll = function (searchStr, replaceStr) {
    var str = this;

    // no match exists in string?
    if (str.indexOf(searchStr) === -1) {
        // return string
        return str;
    }

    // replace and remove first match, and do another recursirve search/replace
    return (str.replace(searchStr, replaceStr)).replaceAll(searchStr, replaceStr);
}