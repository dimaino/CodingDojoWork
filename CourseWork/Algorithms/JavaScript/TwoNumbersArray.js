function TwoNumberArray(num1, num2)
{
  var arr = [];
  //if(typeof (num1 && num2) === "number" && num1 >= 0 && typeof num1 !== "boolean" && Number.isInteger(num1))
  if(num1 >= 0 && Number.isInteger(num1) && Number.isInteger(num2))
  {
    for(var i = 0; i < num1; i++)
    {
      arr[i] = num2;
    }
  }
  else {
    console.log("invalid input");
    return;
  }
  console.log(arr);
  return arr;
}

TwoNumberArray(5, 7);
TwoNumberArray(0, 6);
TwoNumberArray(5, 't');
TwoNumberArray('r', 7);
TwoNumberArray(true, 8);
TwoNumberArray(true, false);
TwoNumberArray(true, true);
TwoNumberArray(false, false);
TwoNumberArray(-2, 7);
TwoNumberArray(2.4, 6);
