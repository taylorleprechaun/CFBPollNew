function FillWeeks(ddlseason) {
    var seasonID = $(ddlseason).val();
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