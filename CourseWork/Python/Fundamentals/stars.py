# Create an array/list
x = [4,6,1,3,5,7,25]
# Takes each element and prints out the number of * for the length of each element
def draw_stars(arr):
    # Goes through the length of the array
    for count in range(0, len(arr)):
        s = ""
        # Goes through each element in the array
        for i in range(0, arr[count]):
            s += "*"
        print s
draw_stars(x)


# Create an array/list
y = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]
# Takes each element and prints out the number of * for the length of each element if its a number otherwise prints the first character of other elements
def draw_stars2(arr):
    # Goes through the length of the array
    for count in range(0, len(arr)):
        s = ""
        # Checks to see if the element at arr[count] is a number
        if isinstance(arr[count], (int, long, float, complex)):
            for i in range(0, arr[count]):
                s += "*"
        else: # Every non-number element is here
            for i in range(0, len(arr[count])):
                # Adds the first letter of each element in the array to a string
                s += arr[count][0].lower()
        # Prints the string after the nested for loops
        print s
draw_stars2(y)
