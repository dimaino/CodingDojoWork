function fancyArray(arr, typ, reversed)
{
  if(reversed === true)
  {
    if(typ === "->")
    {
      for(var i = 0; i < arr.length/2; i++)
      {
        var temp = arr[i];
        arr[i] = arr[arr.length - 1 - i];
        arr[arr.length - 1 - i] = temp;
        console.log(i + " -> " + arr[i]);
      }
      for(var i = arr.length/2; i < arr.length; i++)
      {
        console.log(i + " -> " + arr[i]);
      }
    }
    else if(typ === "=>")
    {
      for(var i = 0; i < arr.length/2; i++)
      {
        var temp = arr[i];
        arr[i] = arr[arr.length - 1 - i];
        arr[arr.length - 1 - i] = temp;
        console.log(i + " => " + arr[i]);
      }
      for(var i = arr.length/2; i < arr.length; i++)
      {
        console.log(i + " => " + arr[i]);
      }
    }
    else if(typ === "::")
    {
      for(var i = 0; i < arr.length/2; i++)
      {
        var temp = arr[i];
        arr[i] = arr[arr.length - 1 - i];
        arr[arr.length - 1 - i] = temp;
        console.log(i + " :: " + arr[i]);
      }
      for(var i = arr.length/2; i < arr.length; i++)
      {
        console.log(i + " :: " + arr[i]);
      }
    }
    else if(typ === "-----")
    {
      for(var i = 0; i < arr.length/2; i++)
      {
        var temp = arr[i];
        arr[i] = arr[arr.length - 1 - i];
        arr[arr.length - 1 - i] = temp;
        console.log(i + " ----- " + arr[i]);
      }
      for(var i = arr.length/2; i < arr.length; i++)
      {
        console.log(i + " ----- " + arr[i]);
      }
    }
  }
  else
  {
    if(typ === "->")
    {
      for(var i = 0; i < arr.length; i++)
      {
        console.log(i + " -> " + arr[i]);
      }
    }
    else if(typ === "=>")
    {
      for(var i = 0; i < arr.length; i++)
      {
        console.log(i + " => " + arr[i]);
      }
    }
    else if(typ === "::")
    {
      for(var i = 0; i < arr.length; i++)
      {
        console.log(i + " :: " + arr[i]);
      }
    }
    else if(typ === "-----")
    {
      for(var i = 0; i < arr.length; i++)
      {
        console.log(i + " ----- " + arr[i]);
      }
    }
  }
}

var arr1 = ["James", "Jill", "Jane", "Jack"];
fancyArray(arr1, "->", true);
