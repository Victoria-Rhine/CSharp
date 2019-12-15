// function to call custom route to controller
function myFunction(user, repo) {

    $.ajax({
        type: "GET",
        dataType: "json",
        //url: "/Home/commits?user={user}&repo={repo}",
        url: "/Home/commits?user=" + user + "&repo=" + repo,
        data: { 'userName': user, 'repoName': repo },
        success: displayCommits,
        error: errorOnAjax
    });
};

function errorOnAjax() {
    console.log("ERROR in ajax request.");
}

// put repo commits in a table
function displayCommits(data) {
    document.getElementById("commitsTable2").remove();
    $('#commitsTable').append($('<table id=\"commitsTable2\">'));
    $('#commitsTable2').append($('<tr id=\"tableTr\">'));
    $('#tableTr').append($('<td id=\"tdSha\"> <strong> SHA </td>'));
    $('#tableTr').append($('<td id=\"tdCommitter\"> <strong> Committer </td>'));
    $('#tableTr').append($('<td id=\"tdWhen\"> <strong> Timestamp </td>'));
    $('#tableTr').append($('<td id=\"tdMessage\"> <strong> Commit Message </td>'));
    $('#commitsTable2').append($('</tr>'));
    $('#commitsTable').append($('</table>'));

    for (var i = data.length - 1; i >= 0; --i) {
        var rowCount = 1;
        var table = document.getElementById("commitsTable2");
        var row = table.insertRow(rowCount); 
        // make a row 
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        var cell4 = row.insertCell(3);
        // add data to row
        cell1.innerHTML = '<a href="' + data[i].CommitUrl + '">' + data[i].Sha + '</a>';
        cell2.innerHTML = data[i].Committer;
        cell3.innerHTML = data[i].Date;
        cell4.innerHTML = data[i].Message;
        rowCount++; 
    }
}

