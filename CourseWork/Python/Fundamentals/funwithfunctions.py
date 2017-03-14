def odd_even(num1,num2):
    for count in range(num1,num2+1):
        if count % 2 == 0:
            print "Number is " + str(count) + ".  This is an even number."
        else:
            print "Number is " + str(count) + ".  This is an odd number."
#odd_even(1,2000)

a =[2,4,10,16]
def multiply(list, multi):
    for count in range(0,len(list)):
        list[count] *= multi
    return list
b = multiply(a,5)
#print b


def layered_multiples(arr):
    # Create 2 Empty arrays/lists
    new_array = list()
    new_array1 = list()
    # Create a for loop to go through each element in the array multiply arr
    for count in range(0, len(arr)):
        # Create a for loop to go through the the value of the array multiply
        for i in range(0, arr[count]):
            # Use the new_array1 to set the value of 1 to each position in the array
            new_array1.insert(i, 1)
        # Insert new_array1 into the number of values are in the multiply array
        new_array.insert(count, new_array1)
        # Reset this array to be able to add it to the other array
        new_array1 = list()
    # return array filled with arrays with values of 1.
    return new_array

x = layered_multiples(multiply([2,4,5],3))
