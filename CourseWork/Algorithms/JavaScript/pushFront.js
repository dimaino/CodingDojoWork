function pushFront(arr, val)
{
  arr.push(arr[arr.length-1]);
  for(var i = (arr.length-2); i > 0; i--)
  {
    arr[i] = arr[i-1];
  }
  arr[0] = val;
}
var someArray = [2, 6];
pushFront(someArray, 6);
console.log(someArray);
