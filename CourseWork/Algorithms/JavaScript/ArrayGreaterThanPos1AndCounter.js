function ArrayGreaterThanPos1AndCounter(arr)
{
  var counter = 0;
  if(Array.isArray(arr) && !arr.some(isNaN)  && !arr.includes(true) && !arr.includes(false))
  {
    for(var i = 0; i < arr.length; i++)
    {
      if(arr[1] < arr[i])
      {
        console.log(arr[i]);
        counter++;
      }
    }
  }
  else
  {
    console.log("invalid input");
    return;
  }
  return counter;
}

ArrayGreaterThanPos1AndCounter([1,2,7,8,2,10]);
ArrayGreaterThanPos1AndCounter([1,100,7,8,2,10]);
ArrayGreaterThanPos1AndCounter([1,-100,7,8,2,10]);
ArrayGreaterThanPos1AndCounter(['s','d','we']);
ArrayGreaterThanPos1AndCounter([true, true, true]);
ArrayGreaterThanPos1AndCounter([false, false, false]);
ArrayGreaterThanPos1AndCounter([true, 2, true]);
ArrayGreaterThanPos1AndCounter(true);
ArrayGreaterThanPos1AndCounter('f');
ArrayGreaterThanPos1AndCounter([2.3, 42.3, 4.21,233.2]);
