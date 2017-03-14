function popFront(arr)
{
  for(var i = 1; i < arr.length; i++)
  {
    arr[i] = arr[i + 1];
  }
  if(arr.length === 1)
  {
    arr =[];
  }
}
