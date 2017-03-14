import random
def cointosses():
    print "Starting the program..."
    counthead = 0
    counttail = 0
    for count in range(1, 5001):
        random_num = round(random.random())

        if random_num > 0:
            counthead += 1
            print "Attempt #" + str(count) + ": Throwing a coin... It's a head! ... Got " + str(counthead) + " head(s) so far and " + str(counttail) + " tails(s) so far"
        else:
            counttail += 1
            print "Attempt #" + str(count) + ": Throwing a coin... It's a tail! ... Got " + str(counthead) + " head(s) so far and " + str(counttail) + " tails(s) so far"
cointosses()
