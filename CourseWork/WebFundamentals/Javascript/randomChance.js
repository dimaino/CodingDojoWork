function randomchance(quarters, totalWon)
{
  var winningNumber = 99;
  if(typeof totalWon !== "undefined")
  {
    while(quarters > 0 && quarters < totalWon)
    {
      var num = Math.floor(Math.random() * 100) + 1;
      if(winningNumber === num)
      {
        var num2 = Math.floor(Math.random() * 50) + 50;
        console.log("Winner");
        console.log("Quarters left: " + quarters + ". Random num won: " + num2);
        quarters = quarters + num2;
      }
      else
      {
      }
      quarters--;
    }
    if(quarters >= totalWon)
    {
      console.log("You got the amount you wanted!");
    }
    return 0;
  }
  else
  {
    while(quarters > 0)
    {
      var num = Math.floor(Math.random() * 100) + 1;
      if(winningNumber === num)
      {
        var num2 = Math.floor(Math.random() * 50) + 50;
        quarters = quarters + num2;
        console.log(quarters);
        return quarters;
      }
      else
      {

      }
      quarters--;
    }
    return 0;
  }
}

randomchance(100, 140);
