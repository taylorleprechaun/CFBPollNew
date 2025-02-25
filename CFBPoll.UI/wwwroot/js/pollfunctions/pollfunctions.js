function FillWeeks() {
    //var seasonID = $(ddlseason).val();
    var seasonID = document.getElementById('ddlSeasons').value;
    var urlString = $('#BaseURL').val() + '/Poll/FillWeeks?season=' + seasonID;

    getWithHTMLReturn(urlString,
        function (response) {
            $('#selectionsPartial').html(response);
        },
        function (error) {
            console.error(error);
        }
    );
}

function FillRankingsGrid() {
    var seasonID = document.getElementById('ddlSeasons').value;
    var weekID = document.getElementById('ddlWeeks').value;
    var urlString = $('#BaseURL').val() + '/Poll/FillRankingsGrid?season=' + seasonID + '&week=' + weekID;

    getWithHTMLReturn(urlString,
        function (response) {
            $('#rankingsPartial').html(response);
        },
        function (error) {
            console.error(error);
        }
    );
}