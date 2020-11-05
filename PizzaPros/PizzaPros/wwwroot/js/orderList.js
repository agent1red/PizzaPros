


$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("cancelled")) {
        loadList("cancelled");
    }
    else {
        if (url.includes("completed")) {
            loadList("completed");
        }
        else {
            loadList("");
        }
    }
});

function loadList(param) {
    dataTable = $('#DT-load').DataTable({

        "ajax": {
            "url": "/api/order?status="+ param,
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "orderHeader.id", "autoWidth": true },
            { "data": "orderHeader.pickupName", "autoWidth": true },
            { "data": "orderHeader.applicationUser.email", "autoWidth": true },
            { "data": "orderHeader.orderDate", "render": function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
            }, "autoWidth": true },
            {
                "data": "orderHeader.orderTotal", render: $.fn.dataTable.render.number(',', '.', 2, '$'),  "width": "20%"},
            {
                "data": "orderHeader.id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Admin/Order/OrderDetails?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Details
                                </a>
                             </div>
                           
                           `;
                }, "autoWidth": true
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%",
        "order": [[3, "asc"]]
    });
}

