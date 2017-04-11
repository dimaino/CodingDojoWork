$(document).ready(function() {
    $.post("actions", function(response) {
        // Handle the response data
        alert(response);
    });
});