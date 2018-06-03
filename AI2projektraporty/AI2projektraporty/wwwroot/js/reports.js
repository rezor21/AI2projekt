const uri = 'api/reports';
let reports = null;

function getCount(data) {
    const el = $('#counter');
    let name = 'report';
    if (data) {
        if (data > 1) {
            name = 'reports';
        }
        el.text(data + ' ' + name);
    } else {
        el.html('No ' + name);
    }
}

$(document).ready(function () {
    getData();

});

function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#reports').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                $('<tr><td> ' + item.name + ' </td>' +
                    '<td> ' + item.type + ' </td>' +
                    '<td><button onclick="deleteItem(' + item.id + ')">Usuń</button></td>' +
                    '</tr>').appendTo($('#reports'));
            });

            reports = data;
            
        }
    });

}

function addItem() {
    const item = {
        'name': $('#add-name').val(),
        'type': $('#add-type').val(),
        'userId': 1
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            getData();
            $('#add-name').val('');
            
            $('#add-type').val('');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getData();
            test = id;
        }
    });
}



function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}
