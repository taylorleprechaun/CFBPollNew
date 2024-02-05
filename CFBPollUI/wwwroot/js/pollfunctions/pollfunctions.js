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

function FillRatingsGrid() {
    var seasonID = document.getElementById('ddlSeasons').value;
    var weekID = document.getElementById('ddlWeeks').value;
    var urlString = $('#BaseURL').val() + '/Poll/FillRatingsGrid?season=' + seasonID + '&week=' + weekID;

    getWithHTMLReturn(urlString,
        function (response) {
            $('#ratingsGridDiv').html(response);
        },
        function (error) {
            console.error(error);
        }
    );
}