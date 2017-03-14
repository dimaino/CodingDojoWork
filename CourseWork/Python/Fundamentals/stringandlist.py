# print the first instance of the word monkey.
# Create a new string and replace monkey with alligator.
str = "If monkeys like bananas, then I must be a monkey!"
print "String: " + str
print "Print the first instance of monkey: "
print str.find("monkey")
print "Replace monkey with alligator: "
print str.replace("monkey", "alligator")

# print the min and max of an array. Should work for any list
x = [2,54,-2,7,12,98]
print "Array: "
print x
print "Max: "
print max(x)
print "Min: "
print min(x)

# print the first and last value. then create a new list containing only the first and last value.  Should work for any list
x = ["hello",2,54,-2,7,12,98,"world"]
print "Array: "
print x
print "Position 0 of array: "
print x[0]
print "Last Position of array: "
print x[len(x)-1]
y = [x[0], x[len(x)-1]]
print "Print array with first and last position: "
print y

# Sort the list. Split the list in half. Split the first half of the list to position [0]
x = [19,2,54,-2,7,12,98,32,10,-3,6]
print x
x.sort()
print "The list is sorted: "
print x
print "This is the slice being preformed: "
y = x[0:5]
print y
print "This is the slice being preformed again to get the second half of the list"
z = x[5:len(x)]
print z
print "this puts the list in a new array so its a nested list in a list"
zz = [y]
print zz

for i in range(0, len(z)):
    zz.append(z[i]);

print "This adds the second half of the list to the first half using a for loop"
print zz
