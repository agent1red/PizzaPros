﻿


var dataTable;


$(document).ready(function () {
    loadList();

});

function loadList() {
    dataTable = $('#DT-load').DataTable({

        "ajax": {
            "url": "/api/category",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "name", "width": "60%" },
            { "data": "displayOrder", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Admin/category/upsert?id=${data}" disabled class="btn btn-success text-light disabled" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                <a class="btn btn-danger text-light disabled" disabled style="cursor:pointer; width:100px;" onclick=Delete('/api/category/'+${data})>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                             </div>
                           
                           `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%",
        "order": [[1, "asc"]],
        rowReorder: { dataSrc: 'name' }
    });
}


function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
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
    });
}