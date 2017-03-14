function arrayShuffle(arr)
{
  if(Array.isArray(arr))
  {

  }
}

function doubleTrouble(arr)
{
  var o = arr.length - 1;
  var count = 0;
  arr.length = arr.length * 2;
  var index = arr.length - 1;

  for(var i = o; i >= 0; i++)
  {
    arr[index] = arr[i];
    index--;
    arr[index] = arr[i];
    index--;
    console.log();
  }

}
var someArray = [1,2,3,4];
console.log(someArray);
doubleTrouble(someArray);


// [1,2,3,4,und,und,und,und];
