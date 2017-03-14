function ArraySizeForArr0(arr)
{
  if(Array.isArray(arr) && !arr.some(isNaN)  && !arr.includes(true) && !arr.includes(false))
  {
    for(var i = 0; i < arr.length; i++)
    {
      if(arr[0] > arr.length)
      {
        console.log('too big');
      }
      else if(arr[0] < arr.length)
      {
        console.log('too small');
      }
      else
      {
        console.log('just right');
      }
    }
  }
  else
  {
    console.log("invalid input");
    return;
  }
}

ArraySizeForArr0([1,2,7,8,2,10]);
ArraySizeForArr0([20,100,7,8,2,10]);
ArraySizeForArr0([-100,-100,7,8,2,10]);
ArraySizeForArr0(['s','d','we']);
ArraySizeForArr0([true, true, true]);
ArraySizeForArr0([false, false, false]);
ArraySizeForArr0([true, 2, true]);
ArraySizeForArr0(true);
ArraySizeForArr0('f');
ArraySizeForArr0([2.3, 42.3, 4.21,233.2]);
