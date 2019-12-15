// Using jQuery and AJAX to pass values from view to the controller
$('#request').click(function() {
    var athlete = $('#athlete').val();
    var event = $('#event').val();

    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: "/Graph/GraphMath",
        data: { 'event': event, 'athlete': athlete },
        success: plotGraph,
        error: errorOnAjax
    });
});

function errorOnAjax() {
    console.log('Error on AJAX return');
}

// this function unchecks the selected radio buttons
$('#refresh').click(function () {
    $('input[type="radio"]').prop('checked', false);
});

function plotGraph(data) {
    // get the information for events
    var dateArray = [];
    for (var i = 0; i < data.length; ++i) {
        dateArray[i] = data[i].EventDate;
    }
    // get the information for results
    var timeArray = [];
    for (var i = 0; i < data.length; ++i) {
        timeArray[i] = data[i].RaceResult;
    }
    var trace = {
        x: dateArray,
        y: timeArray,
        mode: 'lines',
        type: 'scatter',
    };
    var plotData = [trace];
    var layout = {};
    Plotly.newPlot('plot', plotData, layout);
} 