var daysUntilMyBirthday = 60;

while(daysUntilMyBirthday > 0)
{
  console.log(daysUntilMyBirthday--);
  if(daysUntilMyBirthday >= 30)
  {
    console.log("Sad Message.");
  }
  else if(daysUntilMyBirthday < 30 && daysUntilMyBirthday >= 5)
  {
    console.log("Sounds exciting message.")
  }
  else if(daysUntilMyBirthday < 5)
  {
    console.log("SCREAM IT!");
  }
}
