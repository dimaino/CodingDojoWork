$(document).ready(function(){

  $("button").hover(function(){
    switch($("button").index(this))
    {
      case 0:
        $("#black").css("background-image", "url(beach.jpg)");
        break;
      case 1:
        $("#black").css("background-image", "url(earth.jpg)");
        break;
      case 2:
        $("#black").css("background-image", "url(dojo.jpg)");
        break;
      case 3:
        $("#black").css("background-image", "url(forest.jpg)");
        break;
      case 4:
        $("#black").css("background-image", "url(matrix.jpg)");
        break;
      case 5:
        $("#black").css("background-image", "url(snow.jpg)");
        break;
    }
  },
  function(){
    $("#black").css("background-image", "");
  })
  /* CLICK FUNTIONS  */
  $("button").click(function(){
    $(this).unbind();
    $("button").hide();
    $("h1").hide();
    $("#selectArena").append("<h1>Select Players</h1>");
    $("#buttons").addClass("newClass");
    $("#buttons").append("<select id='selected1'><option value='selectNinja'>Select Ninja</option><option value='ninja1'>Ninja 1</option><option value='ninja2'>Ninja 2</option></select><select  id='selected2'><option value='selectNinja'>Select Ninja</option><option value='ninja3'>Ninja 1</option><option value='ninja4'>Ninaj 2</option></select>");
  })

  $(document).on('change', '#selected1', function(){
    var target = $("#selected1").val();
    if(target === 'ninja1')
    {
        $("#image_left1").show();
        $("#image_left2").hide();
    }
    else if(target === 'ninja2')
    {
      $("#image_left2").show();
      $("#image_left1").hide();
    }
  });
  $(document).on('click', '#selected2', function(){
    var target1 = $("#selected2").val();
    if(target1 === 'ninja3')
    {
    $("#image_right3").show();
    $("#image_right4").hide();
    }
    else if(target1 === 'ninja4')
    {
    $("#image_right3").hide();
    $("#image_right4").show();
    }
  });
});
