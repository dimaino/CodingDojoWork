function insertAt(arr, index, val)
{
  var newarr = []
  if(index > 0 && Array.isArray(arr))
{

  for(var i = 0; i < index - 1; i++)
  {
    newarr[i] = arr[i];
  //  console.log("First Part: " + newarr[i] + ". Second Part: " + newarr[i]);
  }
  //console.log("INDEX: " + (index - 1));
  newarr[index - 1] = val;
//  console.log("Third Part: " + newarr[index - 1]);
  for(var i = index-1; i < arr.length; i++)
  {
  ///  console.log("i = " + i);
    newarr.push(arr[i]);
  //  console.log("Fourth Part: " + newarr[i] + ". Fifth Part: " + newarr[i]);
  }
  console.log(newarr);
}
else{
  console.log("error");
}
}
//insertAt([2,5,123,1], 3, 9);
// 2, 5, 3, 123, 1\
insertAt([12], 0, 100);
insertAt([12], 1, 100);
insertAt("hey", 0, 100);
insertAt([12, 23, 43, 1], 10, 100);
