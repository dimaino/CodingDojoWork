function reverseArray(arr)
{
  var newarr = [];
  for(var i = 0; i < arr.length; i++)
  {
    newarr[arr.length - i] = arr[i];
  }
  console.log(newarr);
}
reverseArray([3,5,1,6,3,6]);
