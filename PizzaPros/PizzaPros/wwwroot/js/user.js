﻿var dataTable;


$(document).ready(function () {
    loadList();

});

function loadList() {
    dataTable = $('#DT-load').DataTable({

        "ajax": {
            "url": "/api/user",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "fullName", "width": "25%" },
            { "data": "email", "width": "25%" },
            {
                "data": "phoneNumber", render: function (toFormat) {
                    var tPhone;
                    tPhone = toFormat.toString();
                    tPhone = '(' + tPhone.substring(0, 3) + ') ' + tPhone.substring(3, 6) + '-' + tPhone.substring(6, 10);
                    return tPhone
                }, "width": "15%"
            },

            {
                "data": { id: "id", lockoutEnd: "lockoutEnd" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        //current user is locked 
                        return ` <div class="text-center">
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onclick=LockUnlock('${data.id}')>
                                    <i class="fas fa-lock-open"></i> Unlock
                                </a> </div>`;
                    }
                    else {
                        return ` <div class="text-center">
                                <a class="btn btn-success text-white" style="cursor:pointer; width:100px;" onclick=LockUnlock('${data.id}')>
                                    <i class="fas fa-lock"></i> Lock
                                </a> </div>`;
                    }
                }, "width": "10%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}


function LockUnlock(id) {

    $.ajax({
        type: 'POST',
        url: '/api/User',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
            else {
                toastr.error(data.message);
            }
        }
    });

}