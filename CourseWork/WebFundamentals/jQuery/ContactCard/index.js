$(document).ready(function(){


  $(".add-stickynote").click(function(e){
    var name = $("#full-name").val();
    var email = $("#emailAdd").val();
    var message = $("#messageString").val();
    var more = "<h6>" + message + "</h6>";
    var markup = "<div class='newThings'><p>Name: " + name + "<br>Email: " + email + "</p>" + more + "</div>";

    e.preventDefault();
    $("#sticky").append(markup).addClass(".stickyNote");
    //$(".newThings").append(more).addClass("showlol");
  })

  $(document).on("click", ".newThings", function(){
    //$(".newThings > h6").show();
    //$(".newThings > p").hide();
    //console.log("clicked");
    $(this).children().toggle();
  })

});
