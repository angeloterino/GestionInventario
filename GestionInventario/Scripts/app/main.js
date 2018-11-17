var jsonGet = function (url, doCallBack) {
    var req = new XMLHttpRequest();
    req.open('GET', url, true);
    req.setRequestHeader('Content-Type', 'application/json');

    req.onload = function () {
        if (req.status >= 200 && req.status < 400) {
            response = { success: true, data: req.responseText };
        } else {
            response = { success: false, message: 'Error en la llamada al método' };
        }
        if (doCallBack !== undefined) doCallBack(response);
    };

    req.send();
};
var jsonPost = function (url, tmpObj, doCallBack) {
    var req = new XMLHttpRequest();
    req.open('POST', url, true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.send(JSON.stringify(tmpObj));
    if (doCallBack !== undefined)
        doCallBack({ success: true });
};
var htmlGet = function (url, doCallBack) {
    var req = new XMLHttpRequest();
    req.open('GET', url, true);
    req.setRequestHeader('Content-Type', 'application/html');

    req.onload = function () {
        if (req.status >= 200 && req.status < 400) {
            response = { success: true, data: req.response };
        } else {
            response = { success: false, message: 'Error en la llamada al método' };
        }
        if (doCallBack !== undefined) doCallBack(response);
    };

    req.send();
};
var viewForm = function (id) {
    htmlGet("/home/GetElementForm?id="+id, function (response) {
        $('#modal.modal').html(response.data);
        $('.modal').modal({
            dismissible: false
        }).modal('open');
    });
};