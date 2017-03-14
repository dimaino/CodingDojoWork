
var someArray = [1, "apple", -3, "orange", 0.5];
function numbersOnly(arr)
{
  var newarr = [];
  for(var i = 0; i < arr.length; i++)
  {
    if(typeof arr[i] === "number")
    {
      newarr.push(arr[i]);
    }
  }
  return newarr;
}
var newArray = numbersOnly(someArray);
console.log(newArray);

function sameolarray(arr)
{
  var count = 0;
  for(var i = 0; i < arr.length; i++)
  {
    if(typeof arr[i] !== "number")
    {
      arr.splice(i, 1);
    }
  }
}
sameolarray(someArray);
console.log(someArray);
