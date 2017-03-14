// =============================================================================
//                                                                            //
//                             Coding Dojo                                    //
//                    JavaScript 13 Basic Algorithms                          //
//                                                                            //
//                            ~Daniel Imaino                                  //
//                                                                            //
// ===========================================================================//

// 1.) Print all the integers from 1 to 255.
function print1To255()
{
  for(var i = 1; i<= 255; i++)
  {
    console.log(i);
  }
}
// Test Code
print1To255();

// 2.) Print all odd integers from 1 to 255.
function PrintOdds1To255()
{
  for(var i = 1; i <= 255; i+=2)
  {
    console.log(i);
  }
}

// Test Code
PrintOdds1To255();

// 2.) Alternative way
function PrintOdds1To255()
{
  for(var i = 1; i <= 255; i++)
  {
    if(i % 2 !== 0) // Also try (i % 2 === 1)   This also gets all odd numbers.
    {
      console.log(i);
    }
  }
}

// Test Code
PrintOdds1To255();

// 3.) Print integers from 0 to 255, and the sum so far.
function PrintIntsAndSum0To255()
{
  var sum = 0;
  for(var i = 0; i <= 255; i++)
  {
    sum += i;
    console.log(i);
    console.log(sum);
  }
}

// Test Code
PrintIntsAndSum0To255();

// 4.) Print each value in a given array.
function PrintArrayVals(arr)
{
  for(var i = 0; i < arr.length; i++)
  {
    console.log(arr[i]);
  }
}

// Test Code
PrintArrayVals([10,3,-9,0,38]);

// 5.) Print the largest element in a given array.
function PrintMaxOfArray(arr)
{
  var max = arr[0];
  for(var i = 1; i < arr.length; i++)
  {
    if(arr[i] > max)
    {
      max = arr[i];
    }
  }
  console.log(max);
}

//Test Code
PrintMaxOfArray([10,3,-9,0,38]);

// 6.) Analyze an array's values and print the average
function PrintAverageOfArray(arr)
{
  var sum = 0;
 for(var i = 0; i < arr.length; i++)
 {
   sum += arr[i];
 }
 // console.log(sum); Add this line to see that is works.
}

// Test Code
PrintAverageOfArray([10,3,-9,0,38]);

// 7.) Create & return an array with odd integers from 1-255.
function ReturnOddsArray1To255()
{
  var arr = [];
  for(var i = 1; i < 255; i++)
  {
    if(i % 2 !== 0)
    {
      arr.push(i);
    }
  }
  // console.log(arr); Add this line to see that is works.
  return arr;
}

// Test Code
ReturnOddsArray1To255();

// 8.) Given an array, square each value in the array.
function SquareArrayVals(arr)
{
  for(var i = 0; i < arr.length; i++)
  {
    arr[i] *= arr[i];
  }
  // console.log(arr); Add this line to see that is works.
}

// Test Case
SquareArrayVals([10,3,-9,0,38]);

// 9.) Given an array, return the count that is greater than Y.
function ReturnArrayCountGreaterThanY(arr, y)
{
  var count = 0;
  for(var i = 0; i < arr.length; i++)
  {
    if(arr[i] > y)
    {
      count++;
    }
  }
  // console.log(count); Add this line to see that is works.
  return count;
}

// Test Case
ReturnArrayCountGreaterThanY([10,3,-9,0,38], 8);

// 10.) Given an array, set negative values to zero.
function ZeroOutArrayNegativeVals(arr)
{
  for(var i = 0; i < arr.length; i++)
  {
    if(arr[i] < 0)
    {
      arr[i] = 0;
    }
  }
  // console.log(arr); Add this line to see that is works.
}

// Test Case
ZeroOutArrayNegativeVals([1,-4,7,1,-9]);

// 11.) Given an array, print max, min and average values.
function printMaxMinAverageArrayVals(arr)
{
  var max = arr[0];
  var min = arr[0];
  var avg = arr[0];

  for(var i = 1; i < arr.length; i++)
  {
    if(max < arr[i])
    {
      max = arr[i];
    }
    if(min > arr[i])
    {
      min = arr[i];
    }
    avg += arr[i];
  }
  avg = avg/arr.length;
  console.log(max);
  console.log(min);
  console.log(avg);
}

// Test Case
printMaxMinAverageArrayVals([1,4,7,1]);

// 12.) Given an array, shift values forward by one, dropping the first value and leaving an extra '0' value at the end.
function ShiftArrayValsLeft(arr)
{
  var newarr = [];
  for(var i = 1; i < arr.length; i++)
  {
    newarr.push(arr[i]);
  }
  newarr.push(0);
  console.log(newarr);
}

// Alternative way
function ShiftArrayValsLeft(arr)
{
  var newarr = [];
  for(var i = 0; i < arr.length-1; i++)
  {
    newarr[i] = arr[i + 1];
  }
  newarr.push(0);
  console.log(newarr);
}

// Alternative way
function ShiftArrayValsLeft(arr)
{
  for(var i = 1; i < arr.length; i++)
  {
    arr[i - 1] = arr[i];
  }
  arr[arr.length - 1] = 0;
  // console.log(arr); Add this line to see that is works.
  return arr;
}

// Test Case
ShiftArrayValsLeft([12,3,6,2,8,2]);

// 13.) Given an array, replace negative values with 'Dojo'.
function SwapStringForArrayNegativeVals(arr)
{
  for(var i = 0; i < arr.length; i++)
  {
    if(arr[i] < 0)
    {
      arr[i] = 'Dojo';
    }
  }
  // console.log(arr); Add this line to see that is works.
}

SwapStringForArrayNegativeVals([5, 6, -1, -20, 9]);
