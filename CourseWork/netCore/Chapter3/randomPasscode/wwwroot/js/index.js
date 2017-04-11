$(document).ready(function() {
    $.get("hey", function(response) {
        // Handle the response data
        $("#aCount").text = response.count;
        $("#aString").text = response.someString;
    });
});