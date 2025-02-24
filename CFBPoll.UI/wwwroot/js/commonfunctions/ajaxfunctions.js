// Function to make a GET Ajax request
function getWithHTMLReturn(url, successCallback, errorCallback) {
    $.ajax({
        url: url,
        type: "GET",
        dataType: "html", // Set the data type to "html" for HTML response
        success: function (data) {
            successCallback(data);
        },
        error: function (error) {
            errorCallback(error);
        },
    });
}

// Function to make a GET Ajax request
function getWithJSONReturn(url, successCallback, errorCallback) {
    $.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        success: function (data) {
            successCallback(data);
        },
        error: function (error) {
            errorCallback(error);
        },
    });
}

// Function to make a POST Ajax request
function postWithHTMLReturn(url, data, successCallback, errorCallback) {
    $.ajax({
        url: url,
        type: "POST",
        data: data, // No need to JSON.stringify for HTML response
        success: function (response) {
            successCallback(response);
        },
        error: function (error) {
            errorCallback(error);
        },
    });
}

// Function to make a POST Ajax request
function postWithJSONReturn(url, data, successCallback, errorCallback) {
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            successCallback(response);
        },
        error: function (error) {
            errorCallback(error);
        },
    });
}