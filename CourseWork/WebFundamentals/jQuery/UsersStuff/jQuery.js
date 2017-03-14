$(document).ready(function(){
    $(".add-row").click(function(){
        var firstname = $("#first-name").val();
        var lastname = $("#last-name").val();
        var email = $("#email").val();
        var phoneNumber = $("#phonen").val();
        var markup = "<tr><td>" + firstname + "</td><td>" + lastname + "</td><td>" + email + "</td><td>" + phoneNumber + "</td></tr>";
        $("table tbody").append(markup);
    });
});
