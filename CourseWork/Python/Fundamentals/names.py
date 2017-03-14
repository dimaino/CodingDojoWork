students = [
    {"first_name": "Micheal", "last_name": "Jordan"},
    {"first_name": "John", "last_name": "Rosales"},
    {"first_name": "Mark", "last_name": "Guillen"},
    {"first_name": "KB", "last_name": "Tonel"}
]
print "Part 1"
for count in range(0,len(students)):
    print students[count]["first_name"]
print ""
users = {
    'Students':[
        {"first_name": "Micheal", "last_name": "Jordan"},
        {"first_name": "John", "last_name": "Rosales"},
        {"first_name": "Mark", "last_name": "Guillen"},
        {"first_name": "KB", "last_name": "Tonel"}
    ],
    'Instructors':[
        {"first_name": "Michael", "last_name": "Choi"},
        {"first_name": "Martin", "last_name": "Puryear"}
    ]
}
print "Part 2 - first way"
str1 = ""
print "Students"
for count in range(0, len(users["Students"])):
    size = len(users["Students"][count]["first_name"]) + len(users["Students"][count]["last_name"])
    str1 += str(count + 1) + " - " + str(users["Students"][count]["first_name"]) + " " + str(users["Students"][count]["last_name"]) + " - " + str(size)
    print str1
    str1 = ""
print "Instructors"
for count in range(0, len(users["Instructors"])):
    size = len(users["Instructors"][count]["first_name"]) + len(users["Instructors"][count]["last_name"])
    str1 += str(count + 1) + " - " + str(users["Instructors"][count]["first_name"]) + " " + str(users["Instructors"][count]["last_name"] + " - " + str(size))
    print str1
    str1 = ""

print ""
print "Part 2 - second way"
count = 1
for key, data in users.items():
    print key
    for value in data:
        size = len(value["first_name"]) + len(value["last_name"])
        print str(count), "-", value["first_name"], value["last_name"], "-", str(size)
        count += 1
    count = 1
