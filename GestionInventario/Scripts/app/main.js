var setLoader = function (enable) {
    if (enable) {
        $('a.btn').attr('disabled', 'disabled');
        $('.progress').show();
    } else {
        $('a.btn').removeAttr('disabled');
        $('.progress').hide();
    }
}
var jsonGet = function (url, doCallBack) {
    setLoader(true);
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
        setLoader(false);
    };

    req.send();
};
var jsonPost = function (url, tmpObj, doCallBack) {
    $.ajax({
        method: 'POST',
        url: url,
        contentType: 'application/json',
        data: JSON.stringify(tmpObj),
    })
    .done(function (msg) {
        doCallBack(JSON.parse(msg));
    });
    /*var req = new XMLHttpRequest();
    req.open('POST', url, true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.send(JSON.stringify(tmpObj));
    if (doCallBack !== undefined)
        doCallBack({ success: true, response: req.response });
        */
};
var jsonDelete = function (url, doCallBack) {
    $.ajax({
        method: 'DELETE',
        url: url
    })
    .done(function () {
        doCallBack({success: true});
    });
};
var htmlGet = function (url, doCallBack) {
    setLoader(true);
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
        setLoader(false);
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
var refreshTable = function () {
    htmlGet("/home/GetElementTable", function (response) {
        $('div.content').html(response.data)
    });
};

$(document).ready(function () { 
    $(document).on('click','div.modal a.submit', function () {
        event.preventDefault();
        data = {
            "Name": $('.form').find('input#name').val(),
            "ExpireDate": $('.form').find('input#fechaCaducidad').val(),
            "Quantity": $('.form').find('input#quantity').val(),
            "Type": $('.form').find('select#Type').val(),
            "Id": $('.form').find('input#Id').val()
        };
        editId = "";
        if (data.Id > 0)
            editId = "/" + data.Id;
        jsonPost('/api/App' + editId, data, function (response) {
            if (!response.success)
                alert(response.message);
            else {
                refreshTable();
                $('.modal').modal('close');
            }
        });
    });
    $(document).on('click', 'div.modal a.delete', function () {
        data = {
            "Name": $('.form').find('input#name').val(),
            "ExpireDate": $('.form').find('input#fechaCaducidad').val(),
            "Quantity": $('.form').find('input#quantity').val(),
            "Type": $('.form').find('select#Type').val(),
            "Id": $('.form').find('input#Id').val()
        };
        if (data.Id > 0)
            editId = "/" + data.Id;
        event.preventDefault();
        jsonDelete('/api/App' + editId, function (response) {
            if (!response.success)
                alert(response.message);
            else {
                refreshTable();
                $('.modal').modal('close');
            }
        });
    });
});