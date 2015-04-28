/**
 *
 * This code snippet helps to make ajax request using jQuery syntax
 * not finished!
 *
 */
var $ = function () {
    return new $();
}

$.ajax = function (object) {
    var xmlhttp = new (getAjaxConstructor());
    xmlhttp.open(
		object["method"] || getAjaxMethodType,
		object["url"],
		object["async"] || getAjaxAsyncType
		);

    if (getObjectSize(object["data"])) {
        xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        var postString = "";
        var myObj = object["data"];

        for (var param in myObj) {
            postString += param + "=" + myObj[param] + "&";
        }

        postString = postString.substring(0, postString.length - 1);
        xmlhttp.send(postString);
    }
    else {
        xmlhttp.send();
    }

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            object.success(xmlhttp.responseText);
        }
    }
}

/**
 *
 * Helpers
 *
 */
var getAjaxConstructor = function () {
    if (window.XMLHttpRequest) {
        return XMLHttpRequest;
    }
    else {
        return ActiveXObject('Microsoft.XMLHTTP');
    }
}

var getObjectSize = function (obj) {
    if (typeof (obj) != "undefined" && obj.constructor === Object) {
        var size = 0;
        for (var param in obj) {
            if (obj.hasOwnProperty(param))
                size++;
        }

        return size;
    }

    return 0;
}

/**
 *
 * Defaults
 *
 */
var getAjaxMethodType = "GET";
var getAjaxAsyncType = true;