function FillWeeks() {
    //var seasonID = $(ddlseason).val();
    var seasonID = document.getElementById('ddlSeasons').value;
    var urlString = $('#BaseURL').val() + '/Poll/FillWeeks?season=' + seasonID;

    getWithHTMLReturn(urlString,
        function (response) {
            $('#selectionsContainer').html(response);
        },
        function (xhr, status, error) {
            console.log('Error status:', status);
            console.log('Error message:', error);
        }
    );
}

function FillRankingsGrid() {
    var seasonID = document.getElementById('ddlSeasons').value;
    var weekID = document.getElementById('ddlWeeks').value;
    var urlString = $('#BaseURL').val() + '/Poll/FillRankingsGrid?season=' + seasonID + '&week=' + weekID;

    getWithHTMLReturn(urlString,
        function (response) {
            $('#rankingsContainer').html(response);
        },
        function (xhr, status, error) {
            console.log('Error status:', status);
            console.log('Error message:', error);
        }
    );
}