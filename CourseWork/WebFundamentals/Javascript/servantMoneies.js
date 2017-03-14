var numofpenny = 1;
var days = 1;

for(var i = 1; i < 30; i++)
{
  numofpenny *= 2;
  //console.log(i + ".)" + numofpenny);
}
console.log("After 30 days you would have " + numofpenny + " pennies.")
numofpenny = 1;
while(numofpenny < 1000000)
{
  numofpenny *= 2;
  days++;
}

console.log("It will take " + days + " days to make $10,000.");
days = 1;
numofpenny = 1;



while(numofpenny < 100000000000)
{
  //console.log(days + ".) " + numofpenny);
  numofpenny *= 2;
  days++;
}

console.log("It would take " + days + " to be a billion dollars.");
numofpenny = 1;
days = 1;

while(numofpenny < Infinity)
{
  //console.log(days + ".) " + numofpenny);
  numofpenny *= 2;
  days++;
}
console.log("It would take " + days + " to reach the javaScript infinity.");
