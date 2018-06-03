const turi = 'api/transactions';
let transactions = null;

function getCountt(data) {
    const el = $('#countert');
    let name = 'transaction';
    if (data) {
        if (data > 1) {
            name = 'transactions';
        }
        el.text(data + ' ' + name);
    } else {
        el.html('No ' + name);
    }
}

$(document).ready(function () {
    getTransactions();

});

function getTransactions() {
    $.ajax({
        type: 'GET',
        url: turi,
        success: function (tdata) {
            $('#transactions').empty();
            getCountt(tdata.length);
            $.each(tdata, function (key, transaction) {
                $('<tr><td> ' + transaction.title + ' </td>' +
                    '<td> ' + transaction.date + ' </td>' +
                    '<td> ' + transaction.amount + ' </td>' +
                    '<td><button onclick="editTransaction(' + transaction.id + ')">Edytuj</button></td>' +
                    '<td><button onclick="deleteTransaction(' + transaction.id + ')">Usuń</button></td>' +
                    '</tr>').appendTo($('#transactions'));
            });

            transactions = tdata;

        }
    });

}

function addTransaction() {
    const transaction = {
        'title': $('#add-title').val(),
        'amount': $('#add-amount').val(),
        'date': 1
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: turi,
        contentType: 'application/json',
        data: JSON.stringify(transaction),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            getTransactions();
            $('#add-name').val('');

            $('#add-type').val('');
        }
    });
}

function deleteTransaction(id) {
    $.ajax({
        url: turi + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getTransactions();
            test = id;
        }
    });
}

function editTransaction(id) {
    $.each(reports, function (key, transaction) {
        if (transaction.id === id) {
            $('#edit-name').val(transaction.name);
            $('#edit-type').val(transaction.type);
            $('#edit-id').val(transaction.id);
            $('#edit-isComplete').val(transaction.isComplete);
        }
    });
    $('#spoilert').css({ 'display': 'block' });
}

$('.my-form').on('submit', function () {
    const transaction = {
        'name': $('#edit-name').val(),
        'type': $('#edit-type').val(),
        'userId': 1,
        'id': $('#edit-id').val()
    };

    $.ajax({
        url: turi + '/' + $('#edit-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(transaction),
        success: function (result) {
            getTransactions();
        }
    });

    closeInputt();
    return false;
});

function closeInputt() {
    $('#spoiler').css({ 'display': 'none' });
}
