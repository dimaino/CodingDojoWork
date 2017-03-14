# Part 1
for count in range(1,1000): # For loops goes through the values 1-1000
    if count % 2==1:    # Checks for odd values
        print count     # Prints odd values
# Part 2
for count in range(5,1000005):  # Goes through elements 5 - 1000005
    if count % 5==0:    # Checks for multiples of 5
        print count     # Prints multiples of 5
# Part 3
a = [1,2,5,10,255,3] # Creates an array/list
sum = 0; # Creates a varaible sum and set to 0
for element in range(0, len(a)): # Goes through every element in the array/list
    sum += a[element];  # Gets the value of each element in the array and sets its equal to the sum plus the last element
print sum   #prints the sum
avg = sum/len(a)    # calculates the avg of sum divide by the length of the array/list
print avg   # prints the avg variable
