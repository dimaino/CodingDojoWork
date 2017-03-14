//function(int start, int end, int skip)
function printRange(start, end, skip)
{
  if(typeof skip === "undefined" && typeof end === "undefined")
  {
    for(var i = 0; i<start; i+=1)
    {
      console.log(i);
    }
  }
  else if(typeof skip === "undefined" && typeof end !== "undefined")
  {
    for(start; start<end; start+=1)
    {
      console.log(start);
    }
  }
  else
  {
    for(start; start<end; start+=skip)
    {
      console.log(start);
    }
  }
}

printRange(2, 10, 2);
printRange(-10, -100, 3);
printRange(2, 10);
printRange(4);
