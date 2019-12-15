function myFunction(event) {

    $.ajax({
        type: "GET",
        dataType: "json",     
        url: "/Events/RSVPNumbers",
        data: { 'event': event },
        success: showResults,
        error: errorOnAjax
    });
};

function errorOnAjax() {
    console.log("ERROR in ajax request.");
}

function showResults(data) {
        $('#titleList').append($('<li>' + data.length + '</li>'));
}


var interval = 1000 * 5; // where X is your timer interval in X seconds

window.setInterval(function () { myFunction(event); }, interval);

//window.setInterval(myFunction(event), interval);