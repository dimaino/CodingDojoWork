# problem 1
def print1to255():
    for i in range(1,255+1):
        print i
#print1to255()

# problem 2
def printOdds1to255():
    for i in range(1,257,2):
        print i
#printOdds1to255()

# problem 3
def printIntsAndSums():
    sum = 0
    for i in range(0,256):
        print i
        sum += i
        print sum
#printIntsAndSums()

# problem 4
def iterPrintArray(arr):
    for i in range(0, len(arr)):
        print arr[i]
#iterPrintArray([1,5,3,-9,32])

# problem 5
def printMax(arr):
    max = arr[0]
    for i in range(1, len(arr)):
        if max < arr[i]:
            max = arr[i]
    print max
#printMax([-12,24,45,1,0,-23])

# problem 6
def printAvg(arr):
    avg = arr[0]
    for i in range(1, len(arr)):
        avg += arr[i]
    avg = avg/len(arr)
    print avg
#printAvg([3,134,34,1,-29,0])

# problem 7
def arrayOdds():
    arr = list()
    for i in range(1, 257):
        if i % 2 == 1:
            arr.append(i)
    print arr
#arrayOdds()

# problem 8
def squareVals(arr):
    for i in range(0, len(arr)):
        arr[i] *= arr[i]
    print arr
#squareVals([1,3,34,12,-23])

# problem 9
def greaterThanY(arr, y):
    count = 0
    for i in range(0, len(arr)):
        if arr[i] > y:
            count += 1
    print count
#greaterThanY([1,15,9,19,-21], 9)

# problem 10
def zeroOutNegNum(arr):
    for i in range(0, len(arr)):
        if arr[i] < 0:
            arr[i] = 0
    print arr
#zeroOutNegNum([12,43,123,6,-1,0,-234])

# problem 11
def maxMinAvg(arr):
    myMax = arr[0]
    myMin = arr[0]
    myAvg = arr[0]
    for i in range(1, len(arr)):
        if arr[i] < myMax:
            myMax = arr[i]
        if arr[i] > myMin:
            myMin = arr[i]
        myAvg += arr[i]
    myAvg = myAvg/len(arr)
    print myMax, myMin, myAvg
#maxMinAvg([-111,111,23,4324,123,1])

# problem 12
def shiftArrayVals(arr):
    for i in range(1, len(arr)):
        arr[i-1] = arr[i]
    arr[len(arr) - 1] = 0
    print arr
def shiftArrayVals1(arr):
    for i in range(-1):
        print i
        arr[i-1] = arr[i]
    arr[len(arr) - 1] = 0
    print arr
shiftArrayVals1([213,432,1,453,-23,365,-3])

#problem 13
def swapStrForNegs(arr):
    for i in range(0, len(arr)):
        if arr[i] < 0:
            arr[i] = "dojo"
    print arr
#swapStrForNegs([123,-123,1,0,-23,-3])
