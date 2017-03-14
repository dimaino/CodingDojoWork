function removeDuplicates(arr)
{
  var obj={};

  for(var x = 0; x < arr.length; x++)
  {
    obj[arr[x]] = arr[x];
  }
  arr=[];
  for(var i in obj)
  {
    arr.push(i);
  }
  return arr;
}


var newarr = [1,1,1,4,6,7,7,7];
var result = removeDuplicates(newarr);
console.log(result);
