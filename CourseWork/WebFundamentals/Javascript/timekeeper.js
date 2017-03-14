var HOUR = 8;
var MINUTE = 29;
var PERIOD = "PM";

if(HOUR == 0 && MINUTE == 0)
{
  newHour = 0;
  console.log("Midnight");
}
else if(HOUR > 0 && HOUR < 6 && PERIOD == "AM")
{
  console.log("Dusk");
}
else if(HOUR >= 6 && HOUR < 12 && PERIOD == "AM")
{
  console.log("Morning");
}
else if(HOUR == 12 && PERIOD == "PM" && MINUTE == 0)
{
  console.log("Noon");
}
else if(HOUR > 0 && HOUR <= 6 && PERIOD == "PM")
{
  console.log("Afternoon");
}
else if(HOUR > 6 && HOUR < 12 && PERIOD == "PM")
{
  console.log("Evening");
}


if(MINUTE == 5)
{
  console.log("5 after");
}
else if(MINUTE == 15)
{
  console.log("Quarter after");
}
else if(MINUTE == 30)
{
  console.log("Half passed");
}
else if(MINUTE > 30)
{
  console.log("Just after");
}
else if(MINUTE < 30)
{
  console.log("Almost the next hour");
}
