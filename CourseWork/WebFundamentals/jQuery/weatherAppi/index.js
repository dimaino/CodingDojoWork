$(document).ready(function(){

  $(".submitWeather").click(function(e){
    var name = $("#full-name").val();
    //var markup = " " + name + "</div>";
    console.log(name);
    e.preventDefault();
    //$(".newThings").append(more).addClass("showlol");
    var location = name;
    var loName;
    var temp;
    var place = "http://api.openweathermap.org/data/2.5/weather?q=" + location + ",us&&appid=c7a52d9b34287ce6e4702ecf2e21cb8f";
    $.get(place, function(res) {
      console.log(res);
      loName = res.name;
      temp = res.main.temp;
      var newTemp = temp * (9/5) - 459.67;
      $("#container").append("<h1>" + loName + "</h1><p>Temp: " + newTemp + "</p>");
    }, 'json');
  })



});
