
/*      piechart-TicketsPerProduct */
// Draw the chart and set the chart values
// Load google charts
google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);
function drawChart() {
    var ticketValues = getValues();
    var data = google.visualization.arrayToDataTable(ticketValues);

    // Optional; add a title and set the width and height of the chart
    var options = {

        'width': 630, 'height': 400,
        colors: ['#1c84c6', '#1ab394', '#f8ac59', '#a3e1d4', '#80c1d7'], backgroundColor: 'transparent', is3D: true

    };

    // Display the chart inside the <div> element with id="piechart-TicketsPerProduct"
    var chart = new google.visualization.PieChart(document.getElementById('piechart-TicketsPerProduct'));
    chart.draw(data, options);
}


/*      piechart-NoOfTickets */
// Draw the chart and set the chart values
// Load google charts
google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart1);
function drawChart1() {
    var tickets = getTicketsStatus();
    var data = google.visualization.arrayToDataTable(tickets);

    // Optional; add a title and set the width and height of the chart
    var options = {
        'width': 630, 'height': 400,
        colors: ['#1c84c6', '#1ab394', '#f8ac59', '#a3e1d4', '#80c1d7'], backgroundColor: 'transparent', is3D: true
    };

    // Display the chart inside the <div> element with id="piechart-NoOfTickets"
    var chart = new google.visualization.PieChart(document.getElementById('piechart-NoOfTickets'));
    chart.draw(data, options);
}



/*      Bar-Productivity */
google.charts.load('current', { packages: ['corechart', 'bar'] });
google.charts.setOnLoadCallback(drawMaterial);

function drawMaterial() {//Chart for NumberOfTicketsPerStaff

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Staff Name');
    data.addColumn('number', 'Open Tickets');
    data.addColumn('number', 'Closed Tickets');

    var ticketsPerStaff = getTicketsPerStaff();
    data.addRows(ticketsPerStaff);

    var options = {
        hAxis: {
            title: 'Staff Name',
        },
        vAxis: {
            title: 'Number of Tickets'
        },
        colors: ['#f8ac59', '#1ab394']
    };

    var materialChart = new google.charts.Bar(document.getElementById('productivity'));
    materialChart.draw(data, options);
}



//This function for getting number of tickets for each product in the systemm
function getValues() {
    var result = [];
    debugger;
    result.push(['Product', 'Number of Tickets']);
    if (numberOfTickets != "undefiend" && numberOfTickets != null) {
        numberOfTickets.forEach(function (o) {
            result.push([o.ProductName, o.NumberOfTickets])
        })
    }
    return result;
}


//This function for getting the data that showing the precentage of each ticket status
function getTicketsStatus() {
    var result = [];
    debugger;
    result.push(['Status', 'Number of Tickets']);
    if (numberOfTicketsStatus != "undefiend" && numberOfTicketsStatus != null) {
        numberOfTicketsStatus.forEach(function (o) {
            var status;
            if (o.Status == "0")
                status = "Open";
            if (o.Status == "1")
                status = "Inprogress";
            if (o.Status == "2")
                status = "Close";
            if (o.Status == "3")
                status = "Solved";

            result.push([status, o.Count])
        })
    }
    return result;
}

//This function for getting all closed and open tickets for each staff member
function getTicketsPerStaff() {
    var result = [];
    debugger;
    if (numberOfTicketsPerStaff != "undefiend" && numberOfTicketsPerStaff != null) {
        numberOfTicketsPerStaff.forEach(function (o) {
            result.push([o.StaffName, o.Open, o.Closed])
        })
    }
    return result;
}
