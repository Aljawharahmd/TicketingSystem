$("#getJsonSrc").click(function () {
    $("#dataTable thead").show();
    var $table = $("#dataTable"),
        $startDate = new Date($("#dateFrom").val()),
        $endDate = new Date($("#dateTo").val()),
        $jsonSrc = "https://s3-us-west-2.amazonaws.com/s.cdpn.io/77979/demo.json";

    var my_array;
    $.getJSON($jsonSrc).success(function (data) {
        my_array = [];

        for (var i = 0; i < data.length; i++) {
            var this_date = new Date(data[i].date);
            if ((this_date >= $startDate) && (this_date <= $endDate)) {
                my_array.push(data[i]);

            }
        }
        my_array = JSON.stringify(my_array);
        alert(my_array);
    });
    $table.bootstrapTable("load", my_array);
});

function filterTicket() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("ticketSearch");
    filter = input.value.toUpperCase();
    table = document.getElementById("dataTable");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function filterClient() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("clientSearch");
    filter = input.value.toUpperCase();
    table = document.getElementById("dataTable");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function filterProduct() {
    var input, filter, table, tr, td, i;
    input = document.getElementById("productList");
    filter = input.value.toUpperCase();
    table = document.getElementById("dataTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[2];
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            }
            else if (filter === "PRODUCT") {
                tr[i].style.display = "";
            }
            else {
                tr[i].style.display = "none";
            }
        }
    }
}



