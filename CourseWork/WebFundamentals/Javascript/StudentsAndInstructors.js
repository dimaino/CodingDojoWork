
var students = [
  {first_name: 'Michael', last_name : 'Jordan'},
  {first_name: 'John', last_name: 'Rosales'},
  {first_name: 'Mark', last_name: 'Guillen'},
  {first_name: 'KB', last_name: 'Tonel'}
];

for(var i in students)
{
  console.log(students[i].first_name);
}




var users = {
 'Students': [
     {first_name:  'Michael', last_name : 'Jordan'},
     {first_name : 'John', last_name : 'Rosales'},
     {first_name : 'Mark', last_name : 'Guillen'},
     {first_name : 'KB', last_name : 'Tonel'}
  ],
 'Instructors': [
     {first_name : 'Michael', last_name : 'Choi'},
     {first_name : 'Martin', last_name : 'Puryear'}
  ]
 }

console.log("Students");
  for(var o in users.Students)
  {
    var newStr = users.Students[o].first_name.length + users.Students[o].last_name.length;
    console.log(o + " - " + users.Students[o].first_name + " " + users.Students[o].last_name + " - " + newStr);
  }
  console.log("Instructors");
  for(var n in users.Instructors)
  {
    var newStr = users.Instructors[n].first_name.length + users.Instructors[n].last_name.length;
    console.log(n + " - " + users.Instructors[n].first_name + " " + users.Instructors[n].last_name + " - " + newStr);
  }
