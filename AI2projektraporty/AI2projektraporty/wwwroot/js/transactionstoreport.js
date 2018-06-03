const uri = 'api/reports/addtransactions';
let treports = null;


function editItem(id) {
    $.each(treports, function (key, item) {
        if (item.id === id) {
            $('#edit-name').val(item.name);
            $('#edit-type').val(item.type);
            $('#edit-id').val(item.id);
            $('#edit-isComplete').val(item.isComplete);
        }
    });
    $('#spoiler').css({ 'display': 'block' });
}

$('.my-form').on('submit', function () {
    const item = {
        'name': $('#edit-name').val(),
        'type': $('#edit-type').val(),
        'userId': 1,
        'id': $('#edit-id').val()
    };

    $.ajax({
        url: uri + '/' + $('#edit-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
           
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}
