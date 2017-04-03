function flattenInPlace(arr){
  for(var i = arr.length - 1; i >= 0; i--){
    if(arr[i].constructor === Array){  //Check if arr[i] is an Array, passes True if it is.
      flattenInPlace(arr[i]); // Call the function recursively.
      Array.prototype.splice.apply(arr, [i, 1].concat(arr[i])); //Converts This into an array.
      // Array.prototype.splice.apply
    }
  }
  return arr;
}


var x = [[[2.3], 4], 5, [6, 7]]

console.log(flattenInPlace(x));
